using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.Pages
{
    public class Employeespage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            //Click on the Create Button

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"container\"]/p/a", 3);

            IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createButton.Click();

            //Enter Name

            wait.waittobevisible(driver, "Id", "Name", 3);

            IWebElement nametextBox = driver.FindElement(By.Id("Name"));
            nametextBox.SendKeys("ajay");

            //Enter User name

            IWebElement userNameTextBox = driver.FindElement(By.Id("Username"));
            userNameTextBox.SendKeys("Testajay");

            //Click edit contact button

            IWebElement editContactButton = driver.FindElement(By.Id("EditContactButton"));

            editContactButton.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Frame(0);

            //Get parent and child window handles

            /* ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

             string mainWindow = windowHandles[0];

             string editWindow = windowHandles[1];

             driver.SwitchTo().Window(editWindow);*/


            //driver.SwitchTo().Window(driver.WindowHandles.Last());

            //driver.SwitchTo().Window(driver.WindowHandles[1]);

            Thread.Sleep(3000);

            // Enter contact details

          // wait.waittobevisible(driver, "Id", "FirstName", 5);

            IWebElement firstNameTextBox = driver.FindElement(By.Id("FirstName"));
            firstNameTextBox.SendKeys("TestContactFirst");

            IWebElement lastNameTextBox = driver.FindElement(By.Id("LastName"));
            lastNameTextBox.SendKeys("TestContactlast");

            IWebElement phoneTextBox = driver.FindElement(By.Id("Phone"));
            phoneTextBox.SendKeys("1234567890");

            IWebElement saveContactButton = driver.FindElement(By.Id("submitButton"));
            saveContactButton.Click();

            driver.SwitchTo().DefaultContent();

            //driver.SwitchTo().Window(mainWindow);



            //Enter Password

            wait.waittobevisible(driver, "Id", "Password", 3);

            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("Test@1234");

            IWebElement retypePWTextBox = driver.FindElement(By.Id("RetypePassword"));
            retypePWTextBox.SendKeys("Test@1234");

            //Click on Save button

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(7000);
            

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"container\"]/div/a", 3);


            //Verify if the Employee record is saved successfully

            IWebElement backToListlink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")); // //*[@id="container"]/div/a
            backToListlink.Click();

            Thread.Sleep(2000);

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 3);
            
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));////*[@id="usersGrid"]/div[4]/a[4]/span
            goToLastPageButton.Click();
            Thread.Sleep(2000);
            wait.waittobevisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            IWebElement name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(name.Text == "ajay", "Employee record not created");


}
        public void EditEmployee(IWebDriver driver)
        {

        }

        public void DeleteEmployee(IWebDriver driver)
        {

        }
    }
}
