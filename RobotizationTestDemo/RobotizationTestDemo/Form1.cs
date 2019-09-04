using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotizationTestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            IWebDriver browser = new ChromeDriver();
            browser.Navigate().GoToUrl("https://www.baidu.com");

            browser.FindElement(By.XPath("//*[@id=\"kw\"]")).SendKeys("甲骨文超级码");
            browser.FindElement(By.XPath("//*[@id=\"su\"]")).Click();
            //browser.Close();
        }
    }
}
