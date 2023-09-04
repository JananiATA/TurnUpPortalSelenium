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
    public class EmployeesTests : CommonDriver
    {
        [SetUp]
        public void EmployeesSetUp()
        {
            driver = new ChromeDriver();

            //login page object initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeesPage(driver);
        }

        [Test, Order(1)]
        public void CreateEmployeeTest()
        {
            EmployeesPage employeesPageObj = new EmployeesPage();
            employeesPageObj.CreateEmployee(driver);
        }

        [Test, Order(2)]
        public void EditEmployeeTest()
        {
            EmployeesPage employeesPageObj = new EmployeesPage();
            employeesPageObj.EditEmployee(driver);
        }

        [Test, Order(3)]

        public void DeleteEmployeeTest()
        {
            EmployeesPage employeePageObj = new EmployeesPage();
            employeePageObj.DeleteEmployee(driver);
        }

        [TearDown]

      public void TearDown()

        {
            driver.Quit();
        }


    }
}
