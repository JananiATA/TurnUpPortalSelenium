using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSelenium.Pages;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.Tests
{
    [Parallelizable]
    [TestFixture]
    public class EmployeesTests : Commondriver
    {
        [SetUp]
        public void EmployeesSetUp()
        {
            driver = new ChromeDriver();

            //login page object initialization and Definition
            Loginpage loginpageobj = new Loginpage();
            loginpageobj.loginactions(driver);

            //Home page object initialization and definition
            Homepage homepageobj = new Homepage();
            homepageobj.GoToEmployeesPage(driver);
        }

        [Test, Order(1)]
        public void CreateEmployeeTest()
        {
            Employeespage employeesPageObj = new Employeespage();
            employeesPageObj.CreateEmployee(driver);
        }

        [Test, Order(2)]
        public void EditEmployeeTest()
        {
            Employeespage employeesPageObj = new Employeespage();
            employeesPageObj.EditEmployee(driver);
        }

        [Test, Order(3)]

        public void DeleteEmployeeTest()
        {
            Employeespage employeePageobj = new Employeespage();
            employeePageobj.DeleteEmployee(driver);
        }

        [TearDown]

      public void TearDown()

        {
            driver.Quit();
        }


    }
}
