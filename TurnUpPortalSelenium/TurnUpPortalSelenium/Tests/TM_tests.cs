using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSelenium.Pages;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TM_tests : CommonDriver 
    {
        [SetUp]
        public void Setuptest()
        {
            driver = new ChromeDriver();

            //login page object initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GotoTimeandMaterialPage(driver);
        }
        [Test, Order(1)]
        public void CreateTimeTest()
        {
            TimeAndMaterialPage tmPageObj = new TimeAndMaterialPage();
            tmPageObj.CreateTimeRecord(driver);
        }
        [Test, Order(2)]
        public void EditTimeTest()
        {
            TimeAndMaterialPage tmPageObj = new TimeAndMaterialPage();
            tmPageObj.EditTimeRecord(driver, "desc");
        }
        [Test, Order(3)]
        public void DeleteTimeTest()
        {
            TimeAndMaterialPage tmPageObj = new TimeAndMaterialPage();
            tmPageObj.DeleteTimeRecord(driver);
        }
        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
            
    }
}
