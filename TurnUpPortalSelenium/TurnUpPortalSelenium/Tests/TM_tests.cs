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
    [TestFixture]
    public class TM_tests : Commondriver 
    {
        [SetUp]
        public void Setuptest()
        {
            driver = new ChromeDriver();

            //login page object initialization and Definition
            Loginpage loginpageobj = new Loginpage();
            loginpageobj.loginactions(driver);

            //Home page object initialization and definition
            Homepage homepageobj = new Homepage();
            homepageobj.GotoTimeandMaterialpage(driver);
        }
        [Test]
        public void Createtimetest()
        {
            TimeandMaterialpage tmoageobj = new TimeandMaterialpage();
            tmoageobj.Createtimerecord(driver);
        }
        [Test]
        public void Edittimetest()
        {
            TimeandMaterialpage tmoageobj = new TimeandMaterialpage();
            tmoageobj.edittimerecord(driver);
        }
        [Test]
        public void Deletetimetest()
        {
            TimeandMaterialpage tmoageobj = new TimeandMaterialpage();
            tmoageobj.deletetimerecord(driver);
        }
        [TearDown]
        public void closetest()
        {
            driver.Quit();
        }
            
    }
}
