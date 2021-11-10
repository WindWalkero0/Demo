package com.ruihe.dt.controller;

import com.ruihe.dt.request.InvitationImportPageRequest;
import com.ruihe.dt.service.InvitationImportService;
import com.ruihe.common.profile.BufferedProfile;
import com.ruihe.common.response.Response;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

/**
 * @author fly
 */
@RestController
@RequestMapping("/dt/admin/inv/import")
@Api(description = "会员邀约任务")
public class InvitationImportController {

    @Autowired
    private InvitationImportService invitationImportService;

    /**
     * 会员邀约分页查询
     */
    @BufferedProfile(begin = true, minTime = 200)
    @ApiOperation(value = "会员邀约分页查询")
    @PostMapping("/page_list")
    public Response pageList(@RequestBody InvitationImportPageRequest request) {
        return invitationImportService.pageList(request);
    }

    /**
     * 会员邀约明细分页查询
     */
    @BufferedProfile(begin = true, minTime = 200)
    @ApiOperation(value = "会员邀约明细分页查询")
    @PostMapping("/item_page_list")
    public Response itemPageList(@RequestBody InvitationImportPageRequest request) {
        return invitationImportService.itemPageList(request);
    }

    /**
     * 会员邀约excel导入
     */
    @ApiOperation(value = "会员邀约excel导入")
    @PostMapping("/invitation_plan_import")
    public Response invitationPlanImport(@RequestPart(value = "file") MultipartFile file,
                                         @RequestParam(value = "importName") String importName,
                                         @RequestParam(value = "startTime") String startTime,
                                         @RequestParam(value = "endTime") String endTime) {
        DateTimeFormatter df = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
        return invitationImportService.invitationPlanImport(file, importName, LocalDateTime.parse(startTime, df), LocalDateTime.parse(endTime, df));

    }

    /**
     * 会员邀约excel导入
     */
    @ApiOperation(value = "会员邀约excel导入补充")
    @PostMapping("/import_supplement")
    public Response importSupplement(@RequestPart(value = "file") MultipartFile file,
                                     @RequestParam(value = "planNo") String planNo) {
        return invitationImportService.importSupplement(file, planNo);
    }
}
