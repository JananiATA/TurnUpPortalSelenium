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
        [Test, Order(1)]
        public void Createtimetest()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.Createtimerecord(driver);
        }
        [Test, Order(2)]
        public void Edittimetest()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.edittimerecord(driver, "desc");
        }
        [Test, Order(3)]
        public void Deletetimetest()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.deletetimerecord(driver);
        }
        [TearDown]
        public void closetest()
        {
            driver.Quit();
        }
            
    }
}
