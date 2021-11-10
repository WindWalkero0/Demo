package com.ruihe.dt.service;

import com.baomidou.dynamic.datasource.annotation.DS;
import com.baomidou.mybatisplus.core.conditions.query.LambdaQueryWrapper;
import com.baomidou.mybatisplus.core.toolkit.Wrappers;
import com.baomidou.mybatisplus.extension.plugins.pagination.Page;
import com.google.common.base.Joiner;
import com.google.common.collect.Lists;
import com.ruihe.common.constant.DBConst;
import com.ruihe.common.exception.BizException;
import com.ruihe.common.pojo.PageVO;
import com.ruihe.common.pojo.context.holder.AdminUserContextHolder;
import com.ruihe.common.response.Response;
import com.ruihe.common.utils.BeanUtil;
import com.ruihe.common.utils.IdGenerator;
import com.ruihe.dt.invitation.InvitationAvlInviteeStatusEnum;
import com.ruihe.dt.invitation.InvitationImportStatusEnum;
import com.ruihe.dt.mapper.InvitationAvlInviteeMapper;
import com.ruihe.dt.mapper.InvitationImportItemMapper;
import com.ruihe.dt.mapper.InvitationImportMapper;
import com.ruihe.dt.mapper.InvitationTaskMapper;
import com.ruihe.dt.po.*;
import com.ruihe.dt.po.query.InvitationImportItemDTO;
import com.ruihe.dt.request.InvitationImportPageRequest;
import com.ruihe.dt.response.InvitationImportResponse;
import com.ruihe.dt.response.InvitationInviteeResponse;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.apache.poi.ss.usermodel.*;
import org.springframework.aop.framework.AopContext;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.Period;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

/**
 * @author fly
 */
@Slf4j
@Service
@RequiredArgsConstructor
@EnableAspectJAutoProxy(exposeProxy = true, proxyTargetClass = true)
public class InvitationImportService {
    private final InvitationImportMapper invitationImportMapper;
    private final InvitationImportItemMapper invitationImportItemMapper;
    private final InvitationAvlInviteeMapper invitationAvlInviteeMapper;
    private final InvitationTaskMapper invitationTaskMapper;
    private final InvitationQueryService invitationQueryService;

    @Value("${file-upload.disk-root-path}")
    private String diskRootPath;

    @DS(DBConst.MASTER)
    public Response invitationPlanImport(MultipartFile file, String importName, LocalDateTime startTime, LocalDateTime endTime) {
        //最近的一份过期之前不能添加新的
        List<InvitationImportPo> invitationImportPos = invitationImportMapper.selectList(Wrappers.<InvitationImportPo>lambdaQuery()
                .and(wrapper -> wrapper.le(InvitationImportPo::getStartTime, startTime).ge(InvitationImportPo::getEndTime, endTime)).or()
                .between(InvitationImportPo::getEndTime, startTime, endTime).or().between(InvitationImportPo::getStartTime, startTime, endTime));
        if (!(invitationImportPos == null || invitationImportPos.isEmpty())) {
            return Response.errorMsg("上一份名单还未过期!");
        }
        //名称2 -10个字
        //结束时间不能大于开始时间
        if (importName.length() > 20 || importName.length() < 2) {
            return Response.errorMsg("不合法的名称！");
        }
        if (startTime.isAfter(endTime)) {
            return Response.errorMsg("结束时间不能早于开始时间！");
        }
        if (Period.between(startTime.toLocalDate(), endTime.toLocalDate()).getDays() > 30) {
            return Response.errorMsg("周期最长不能超过1个月！");
        }
        Boolean decide = false;
        //导入之前先保存一份
        String planNo = IdGenerator.getPromotionCouponId("IN");
        try (Workbook workbook = WorkbookFactory.create(file.getInputStream())) {
            if (workbook.getNumberOfSheets() == 0) {
                return Response.errorMsg("文件格式不正确，没有sheet！");
            }

            if (workbook.getSheetAt(0).getLastRowNum() > 50000) {
                return Response.errorMsg("Excel行数不得超过5w！");
            }

            List<InvitationTaskPo> invitationTaskPos = invitationTaskMapper.selectLastMemberTask(null);
            Map<String, InvitationTaskPo> collect = new HashMap<>();
            if (invitationTaskPos != null && !invitationTaskPos.isEmpty()) {
                collect = invitationTaskPos.stream().collect(Collectors.toMap(InvitationTaskPo::getMemberPhone, e -> e));
            }
            Map<String, InvitationTaskPo> finalCollect = collect;
            Map<String, CounterInformation> counterMap = invitationQueryService.getCounterIdMap();
            Map<String, MemberLevel> memberLevelMap = invitationQueryService.getMemberLevelMap();

            decide = true;
//            InvitationImportService o1 = (InvitationImportService) AopContext.currentProxy();

            // 只要基本校验通过，主表就记录，即便子表没有数据，也可以通过补充添加
            final InvitationImportPo invitationImportPo = this.buildInvitationPlan(planNo, importName, startTime, endTime);
            int rows = invitationImportMapper.insert(invitationImportPo);
            if (rows == 0) {
                return Response.errorMsg("会员邀约导入失败！");
            }
            //异步解析
//            new Thread(() ->
            extractSheet(planNo, workbook, counterMap, memberLevelMap, finalCollect);
//            ).start();
        } catch (Exception e) {
            if (decide) {
                return Response.errorMsg(e.getMessage());
            } else {
                log.error("InvitationPlanService.extractSheet.sheet.error,", e);
                return Response.errorMsg("导入异常，文件格式不正确！");
            }
        }
        return Response.successMsg("导入完成！");
    }

    /**
     * 构建新的list 并一起提交
     *
     * @param itemList
     * @param counterMap
     * @param memberLevelMap
     * @param finalCollect
     * @return
     */
    @Transactional(rollbackFor = Exception.class)
    public List<InvitationAvlInviteePo> subCommit(List<InvitationImportItemPo> itemList, Map<String, CounterInformation> counterMap, Map<String, MemberLevel> memberLevelMap, Map<String, InvitationTaskPo> finalCollect) {
        List<InvitationAvlInviteePo> list = new ArrayList<>();
        // 通过 in 条件在数据库中查重，获取到重复的数据
        List<InvitationImportItemDTO> importItemDTOList = invitationImportItemMapper.checkRepeatList(itemList.stream()
                .map(u -> new InvitationImportItemDTO(u.getPlanNo(), u.getMemberPhone(), u.getTag()))
                .collect(Collectors.toList()));
        // 转换成Map容器
        Map<String, InvitationImportItemDTO> tempMap = importItemDTOList.parallelStream()
                .distinct()
                .collect(Collectors.toMap(e -> Joiner.on("").join(e.getPlanNo(), e.getMemberPhone(), e.getTag()), Function.identity()));
        // 去重
        List<InvitationImportItemPo> useImportItemList = itemList.stream().filter(e -> {
            String key = Joiner.on("").join(e.getPlanNo(), e.getMemberPhone(), e.getTag());
            return !tempMap.containsKey(key);
        }).collect(Collectors.toList());
        if (!useImportItemList.isEmpty()) {
            useImportItemList.forEach(itemPo -> {
                InvitationTaskPo invitationTaskPo = finalCollect.get(itemPo.getMemberPhone());
                CounterInformation counterInformation = counterMap.get(itemPo.getCounterId());
                MemberLevel memberLevel = memberLevelMap.get(itemPo.getMemberLevelName());
                //填充新的类   查询他的任务表中的邀约结果 时间插入
                list.add(InvitationAvlInviteePo.builder()
                        .id(IdGenerator.getLongSerialNo())
                        .status(InvitationAvlInviteeStatusEnum.UNCHECK.getCode())
                        .birthday(itemPo.getBirthday())
                        .cardIssueTime(itemPo.getCardIssueTime())
                        .counterId(itemPo.getCounterId())
                        .counterName(itemPo.getCounterName())
                        .baCode(itemPo.getBaCode())
                        .baName(itemPo.getBaName())
                        .createTime(LocalDateTime.now())
                        .updateTime(LocalDateTime.now())
                        .integralQty(itemPo.getIntegralQty())
                        .invResult(invitationTaskPo == null ? null : invitationTaskPo.getInvResult())
                        .lastestArrTime(invitationTaskPo == null ? null : invitationTaskPo.getSigninTime())
                        .lastestArrStatus(invitationTaskPo == null ? null : invitationTaskPo.getStatus())
                        .lastestInvTime(invitationTaskPo == null ? null : invitationTaskPo.getUpdateTime())
                        .lastestTrxTime(itemPo.getLastestTrxTime())
                        .levelChangeTime(itemPo.getLevelChangeTime())
                        .memberLevelCode(memberLevel.getLevelCode())
                        .memberLevelName(itemPo.getMemberLevelName())
                        .memberName(itemPo.getMemberName())
                        .memberPhone(itemPo.getMemberPhone())
                        .memberSex(itemPo.getMemberSex())
                        .orgAreaCode(counterInformation == null ? "" : counterInformation.getOrgAreaId())
                        .orgAreaName(itemPo.getOrgAreaName())
                        .orgOfficeCode(counterInformation == null ? "" : counterInformation.getOrgOfficeId())
                        .orgOfficeName(counterInformation == null ? "" : counterInformation.getOrgOfficeName())
                        .orgPrincipalCode(counterInformation == null ? "" : counterInformation.getOrgMasterId())
                        .orgPrincipalName(counterInformation == null ? "" : counterInformation.getOrgMasterName())
                        .planNo(itemPo.getPlanNo())
                        .addInformation(itemPo.getAddInformation())
                        .tag(itemPo.getTag())
                        .build());
            });
            invitationImportItemMapper.batchInsert(useImportItemList);
            invitationAvlInviteeMapper.batchInsert(list);
        }
        return list;
    }

    private InvitationImportPo buildInvitationPlan(String planNo, String importName, LocalDateTime startTime, LocalDateTime endTime) {
        var userInformation = AdminUserContextHolder.get();
        return InvitationImportPo.builder()
                .planNo(planNo)
                .planName(importName)
                .startTime(startTime)
                .endTime(endTime)
                .optId(userInformation == null ? "admin" : userInformation.getEmpId())
                .optName(userInformation == null ? "admin" : userInformation.getName())
                .createTime(LocalDateTime.now())
                .updateTime(LocalDateTime.now())
                .build();
    }

    /**
     * 补充名单
     *
     * @param file
     * @param planNo
     * @return
     */
    @DS(DBConst.MASTER)
    public Response importSupplement(MultipartFile file, String planNo) {
        InvitationImportPo invitationImportPo = invitationImportMapper.selectOne(Wrappers.<InvitationImportPo>lambdaQuery().eq(InvitationImportPo::getPlanNo, planNo));
        if (invitationImportPo == null) {
            return Response.errorMsg("不存在的导入名单!");
        }
        if (invitationImportPo.getEndTime().compareTo(LocalDateTime.now()) < 0) {
            return Response.errorMsg("改名单已过期无法补充!");
        }

        List<InvitationTaskPo> invitationTaskPos = invitationTaskMapper.selectLastMemberTask(null);
        Map<String, InvitationTaskPo> collect = new HashMap<>();
        if (invitationTaskPos != null && !invitationTaskPos.isEmpty()) {
            collect = invitationTaskPos.stream().collect(Collectors.toMap(InvitationTaskPo::getMemberPhone, e -> e));
        }
        Map<String, InvitationTaskPo> finalCollect = collect;
        Map<String, CounterInformation> counterMap = invitationQueryService.getCounterIdMap();
        Map<String, MemberLevel> memberLevelMap = invitationQueryService.getMemberLevelMap();
        Boolean decide = false;
        try (Workbook workbook = WorkbookFactory.create(file.getInputStream())) {

            //导入之前先保存一份
            if (workbook.getNumberOfSheets() == 0) {
                return Response.errorMsg("文件格式不正确，没有sheet！");
            }
            decide = true;
//            InvitationImportService o1 = (InvitationImportService) AopContext.currentProxy();
            //异步解析
//            new Thread(() ->
            extractSheet(planNo, workbook, counterMap, memberLevelMap, finalCollect);
//            ).start();
        } catch (Exception e) {
            if (decide) {
                return Response.errorMsg(e.getMessage());
            } else {
                log.error("InvitationPlanService.importSupplement.sheet.error,", e);
                return Response.errorMsg("导入异常，文件格式不正确！");
            }
        }
        return Response.successMsg("导入完成！");
    }

    /**
     * 解析Excel
     *
     * @param planId
     * @param workbook
     * @param counterMap
     * @param memberLevelMap
     * @param finalCollect
     */
    public void extractSheet(String planId, Workbook workbook, Map<String, CounterInformation> counterMap, Map<String, MemberLevel> memberLevelMap, Map<String, InvitationTaskPo> finalCollect) {
        
        InvitationImportService o1 = (InvitationImportService) AopContext.currentProxy();
        //excel去重
        IntStream.range(0, workbook.getNumberOfSheets()).parallel().forEach(e -> {
            HashSet<String> hs = new HashSet<>();
            List<InvitationImportItemPo> itemList = Lists.newArrayList();
            Sheet sheet = workbook.getSheetAt(e);
            for (Row row : sheet) {
                if (row.getRowNum() < 1) {
                    continue;
                }
                InvitationImportItemPo item = this.extractRow(planId, row, counterMap);
                if (item == null) {
                    continue;
                }
                //判断是否存在
                String checkField = Joiner.on("").join(item.getPlanNo(), item.getMemberPhone(), item.getTag()).trim();
                if (hs.contains(checkField)) {
                    continue;
                }
                hs.add(checkField);
                itemList.add(item);
                //分段提交
                if (itemList.size() == 10000) {
                    o1.subCommit(itemList, counterMap, memberLevelMap, finalCollect);
                    //然后置空
                    itemList.clear();
                    hs.clear();
                }
            }
            //没有1000个时也提交
            if(!itemList.isEmpty()){
                o1.subCommit(itemList, counterMap, memberLevelMap, finalCollect);
            }
        });
    }

    /**
     * 构造积分导入明细
     *
     * @param planNo
     * @param row
     * @return
     */
    public InvitationImportItemPo extractRow(String planNo, Row row, Map<String, CounterInformation> counterMap) {
        InvitationImportItemPo item = InvitationImportItemPo.builder().id(IdGenerator.getLongSerialNo()).planNo(planNo).status(true).build();
        try {
            List<String> cellValues = Lists.newArrayList();
            for (Cell cell : row) {
                String value = cell.getCellTypeEnum() == CellType.NUMERIC
                        ? Long.toString(((long) cell.getNumericCellValue()))
                        : cell.getStringCellValue();
                cellValues.add(value);
            }
            DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
            //如果整行数据为空则跳过
            String concat = org.apache.commons.lang3.StringUtils.join(cellValues.iterator(), org.apache.commons.lang3.StringUtils.EMPTY);
            if (org.apache.commons.lang3.StringUtils.isBlank(concat)) {
                return null;
            }
            int flag = 0;
            StringBuilder sb = new StringBuilder();
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                String counterId = cellValues.get(flag).trim();
                CounterInformation counterInformation = counterMap.get(counterId);
                if (counterInformation != null) {
                    item.setCounterId(cellValues.get(flag).trim());
                } else {
                    throw new BizException("柜台编码不正确");
                }
            } else {
                throw new BizException("柜台编码不正确");
//                sb.append("柜台不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setCounterId(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                String counterId = cellValues.get(flag - 1).trim();
                CounterInformation counterInformation = counterMap.get(counterId);
                String counterName = counterInformation.getCounterName();
                if (counterName.equals(cellValues.get(flag).trim())) {
                    item.setCounterName(cellValues.get(flag).trim());
                } else {
                    throw new BizException("柜台名称不正确");
                }
            } else {
                throw new BizException("柜台名称不正确");
//                sb.append("柜台不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setCounterName(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setBaName(cellValues.get(flag).trim());
            } else {
                throw new BizException("ba名称不正确");
//                sb.append("ba名称不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setBaName(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setBaCode(cellValues.get(flag).trim());
            } else {
                throw new BizException("ba编号不正确");
//                sb.append("ba编码不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setCounterName(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setMemberLevelName(cellValues.get(flag).trim());
            } else {
                throw new BizException("会员等级不正确");
//                sb.append("会员等级不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setMemberLevelName(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setMemberName(cellValues.get(flag).trim());
            } else {
                sb.append("会员名称不正确");
                item.setStatus(Boolean.FALSE);
                item.setMemberName(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setMemberSex(cellValues.get(flag).trim());
            } else {
                throw new BizException("会员性别不正确");
//                sb.append("会员性别不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setMemberSex(cellValues.get(flag));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag)) && cellValues.get(flag).trim().length() == 11) {
                item.setMemberPhone(cellValues.get(flag).trim());
            } else {
                throw new BizException("手机号【%s】格式不正确");
//                sb.append(String.format("手机号【%s】格式不正确", cellValues.get(flag)));
//                item.setStatus(Boolean.FALSE);
//                item.setMemberPhone(cellValues.get(flag));
            }
            flag++;
            try {
                if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                    item.setBirthday(LocalDate.parse(cellValues.get(flag).trim()));
                }
            } catch (Exception e) {
                throw new BizException("会员生日【%s】不正确，格式YYYY-MM-DD");
//                item.setStatus(Boolean.FALSE);
//                sb.append(String.format("会员生日【%s】不正确，格式YYYY-MM-DD", cellValues.get(flag)));
            }
            flag++;
            if (org.apache.commons.lang3.StringUtils.isNotBlank(cellValues.get(flag))) {
                item.setTag(cellValues.get(flag).trim());
            } else {
                throw new BizException("会员标签不正确");
//                sb.append("会员标签不正确");
//                item.setStatus(Boolean.FALSE);
//                item.setTag(cellValues.get(flag));
            }
            flag++;
            item.setAddInformation(cellValues.get(flag).trim());
            item.setRemark(item.getStatus() ? "导入成功" : sb.toString());
        } catch (Exception e) {
            log.error("InvitationImportService.extractSheet.row.error,", e);
//            item.setStatus(Boolean.FALSE);
            int rows = row.getRowNum() + 1;
            String errMsg = "导入异常，" + e.getMessage() + "，行：" + rows;
//            item.setRemark(errMsg);
            throw new BizException(errMsg);
        }
        return item;
    }

    private String saveFile(MultipartFile file, String imOrderNo) throws Exception {
        //2020年5月14日10:09:01 换文件夹名字
        String filePath = "int_imp";
        if (file == null) {
            throw new BizException("未选择上传文件");
        }
        //判断目录有没有创建
        File fileDir = new File(diskRootPath + filePath);
        boolean flag = true;
        if (!fileDir.exists()) {
            flag = fileDir.mkdirs();
        }
        if (!flag) {
            throw new BizException("创建失败！");
        }
        //上传开始
        try {
            String fileName = imOrderNo + "." + org.springframework.util.StringUtils.getFilenameExtension(file.getOriginalFilename());
            file.transferTo(new File(fileDir.getAbsolutePath(), fileName));
            return (String.join("/", filePath, fileName));
        } catch (IOException e) {
            log.error(String.format(this.getClass().getName() + "上传文件失败.e=%s", e.toString()));
            throw new BizException("上传文件失败");
        }
    }

    /**
     * 主表分页查询
     *
     * @param request
     * @return
     */
    @DS(DBConst.SLAVE)
    public Response pageList(InvitationImportPageRequest request) {
        Page<InvitationImportPo> page = new Page<>(request.getPageNumber(), request.getPageSize());
        LambdaQueryWrapper<InvitationImportPo> queryWrapper = Wrappers.<InvitationImportPo>lambdaQuery();
        if (request.getStartTime() != null) {
            queryWrapper.ge(InvitationImportPo::getCreateTime, request.getStartTime());
        }
        if (request.getEndTime() != null) {
            queryWrapper.lt(InvitationImportPo::getCreateTime, request.getEndTime().plusDays(1));
        }
        if (request.getName() != null && !"".equals(request.getName())) {
            queryWrapper.like(InvitationImportPo::getPlanName, request.getName());
        }
        queryWrapper.orderByDesc(InvitationImportPo::getCreateTime);
        Page<InvitationImportPo> invitationImportPoPage = invitationImportMapper.selectPage(page, queryWrapper);
        List<InvitationImportResponse> invitationImportResponses = BeanUtil.copyListProperties(invitationImportPoPage.getRecords(), InvitationImportResponse.class);
        invitationImportResponses.forEach(e -> {
            //过期状态  当前时间与过期时间做对比
            if (LocalDateTime.now().isBefore(e.getStartTime())) {
                e.setStatus(InvitationImportStatusEnum.UN_START.getCode());
            } else if (LocalDateTime.now().isBefore(e.getEndTime())) {
                e.setStatus(InvitationImportStatusEnum.STARTING.getCode());
            } else {
                e.setStatus(InvitationImportStatusEnum.END.getCode());
            }
        });
        PageVO pageVO = PageVO.<InvitationImportResponse>builder()
                .list(invitationImportResponses)
                .pages(invitationImportPoPage.getPages())
                .total(invitationImportPoPage.getTotal())
                .pageSize(invitationImportPoPage.getSize())
                .pageNum(invitationImportPoPage.getCurrent()).build();
        return Response.success(pageVO);
    }


    /**
     * 子表分页查询
     *
     * @param request
     * @return
     */
    @DS(DBConst.SLAVE)
    public Response itemPageList(InvitationImportPageRequest request) {
        Page<InvitationImportItemPo> page = new Page<>(request.getPageNumber(), request.getPageSize());
        Page<InvitationImportItemPo> invitationImportItemPoPage = invitationImportItemMapper.selectPage(page, Wrappers.<InvitationImportItemPo>lambdaQuery()
                .eq(InvitationImportItemPo::getPlanNo, request.getPlanNo())
                .orderByDesc(InvitationImportItemPo::getId));
        PageVO pageVO = PageVO.<InvitationInviteeResponse>builder()
                .list(BeanUtil.copyListProperties(invitationImportItemPoPage.getRecords(), InvitationInviteeResponse.class))
                .pages(invitationImportItemPoPage.getPages())
                .total(invitationImportItemPoPage.getTotal())
                .pageSize(invitationImportItemPoPage.getSize())
                .pageNum(invitationImportItemPoPage.getCurrent()).build();
        return Response.success(pageVO);
    }

}
