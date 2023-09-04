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
    public class EmployeesPage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            //Click on the Create Button

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/p/a", 3);

            IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createButton.Click();

            //Enter Name

            Wait.WaitToBeVisible(driver, "Id", "Name", 3);

            IWebElement nametextBox = driver.FindElement(By.Id("Name"));
            nametextBox.SendKeys("Ajay1");

            //Enter User name

            IWebElement userNameTextBox = driver.FindElement(By.Id("Username"));
            userNameTextBox.SendKeys("Ajaynew123");

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

            Wait.WaitToBeVisible(driver, "Id", "FirstName", 5);

            IWebElement firstNameTextBox = driver.FindElement(By.Id("FirstName"));
            firstNameTextBox.SendKeys("TestContactFirst");

            IWebElement lastNameTextBox = driver.FindElement(By.Id("LastName"));
            lastNameTextBox.SendKeys("TestContactlast");

            IWebElement pNTextBox = driver.FindElement(By.Id("PreferedName"));
            pNTextBox.SendKeys("TeastDataPFN");

           IWebElement phoneTextBox = driver.FindElement(By.Id("Phone"));
            phoneTextBox.SendKeys("1234567890");

            IWebElement mobileTextBox = driver.FindElement(By.Id("Mobile"));
            mobileTextBox.SendKeys("456677888");

            IWebElement emailTextBox = driver.FindElement(By.Id("email"));
            emailTextBox.SendKeys("abc@gmail.com");

            IWebElement faxTextBox = driver.FindElement(By.Id("Fax"));
            faxTextBox.SendKeys("1234567");

            IWebElement streetTextBox = driver.FindElement(By.Id("Street"));
            streetTextBox.SendKeys("abc street");

            IWebElement cityTestBox = driver.FindElement(By.Id("City"));
            cityTestBox.SendKeys("Wellington");

            IWebElement postcodeTextBox = driver.FindElement(By.Id("Postcode"));
            postcodeTextBox.SendKeys("5011");

            IWebElement countryTextBox = driver.FindElement(By.Id("Country"));
            countryTextBox.SendKeys("NewZealand");

            IWebElement saveContactButton = driver.FindElement(By.Id("submitButton"));
            saveContactButton.Click();

            driver.SwitchTo().DefaultContent();

          
            //Enter Password

            Wait.WaitToBeVisible(driver, "Id", "Password", 3);

            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("Test@1234");

            IWebElement retypePWTextBox = driver.FindElement(By.Id("RetypePassword"));
            retypePWTextBox.SendKeys("Test@1234");

            IWebElement isAdminCheckBox = driver.FindElement(By.Id("IsAdmin"));
            isAdminCheckBox.Click();

            Thread.Sleep(3000);

            IWebElement selectElement = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]/input"));//*[@id="UserEditForm"]/div/div[8]/div/div/div[1]/input
            //IWebElement selectElement = driver.FindElement(By.Id("groupList"));
            selectElement.Click();

            /* var selectOption = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]"));
            var select = new SelectElement(selectOption);
            select.SelectByText("sda"); */

            Thread.Sleep(3000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"groupList_listbox\"]/li[6]", 8);
            IWebElement optionDropdown = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[6]"));
            optionDropdown.Click();

            Thread.Sleep(3000);
            
            

            //Click on Save button

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(7000);
            

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/div/a", 3);


            //Verify if the Employee record is saved successfully

            IWebElement backToListlink = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")); // //*[@id="container"]/div/a
            backToListlink.Click();

            Thread.Sleep(2000);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 3);
            
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));////*[@id="usersGrid"]/div[4]/a[4]/span
            goToLastPageButton.Click();
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            IWebElement name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(name.Text == "Ajay1", "Employee record not created");


}
        public void EditEmployee(IWebDriver driver)
        {
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            lastPageButton.Click();

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            //Edit Name

            IWebElement editNameTextBox = driver.FindElement(By.Id("Name"));
            editNameTextBox.Clear();
            editNameTextBox.SendKeys("AjayNew");


            //Edit User name

            IWebElement editUserNameTextBox = driver.FindElement(By.Id("Username"));
            editUserNameTextBox.Clear();
            editUserNameTextBox.SendKeys("Testarjunsar");

            //Click edit contact button

            IWebElement editContactButton = driver.FindElement(By.Id("EditContactButton"));

            editContactButton.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Frame(0);

            Wait.WaitToBeVisible(driver, "Id", "FirstName", 5);

            IWebElement editFNTextBox = driver.FindElement(By.Id("FirstName"));
            editFNTextBox.Clear();
            editFNTextBox.SendKeys("TestContactFN");

            IWebElement editLNTextBox = driver.FindElement(By.Id("LastName"));
            editLNTextBox.Clear();
            editLNTextBox.SendKeys("TestContactLN");

            IWebElement pNTextBox1 = driver.FindElement(By.Id("PreferedName"));
            pNTextBox1.Clear();
            pNTextBox1.SendKeys("TeastDataPFNnew");

            IWebElement editPhTextBox = driver.FindElement(By.Id("Phone"));
            editPhTextBox.Clear();
            editPhTextBox.SendKeys("6789947890");

            IWebElement editMobileTextBox = driver.FindElement(By.Id("Mobile"));
            editMobileTextBox.Clear();
            editMobileTextBox.SendKeys("4566455688");

            IWebElement editEmailTextBox = driver.FindElement(By.Id("email"));
            editEmailTextBox.Clear();
            editEmailTextBox.SendKeys("abc@gmail.com");

            IWebElement editFaxTextBox = driver.FindElement(By.Id("Fax"));
            editFaxTextBox.Clear();
            editFaxTextBox.SendKeys("1234567");

            IWebElement editStreetTextBox = driver.FindElement(By.Id("Street"));
            editStreetTextBox.Clear();
            editStreetTextBox.SendKeys("abc street");

            IWebElement editCityTestBox = driver.FindElement(By.Id("City"));
            editCityTestBox.Clear();
            editCityTestBox.SendKeys("Wellington");

            IWebElement editPostcodeTextBox = driver.FindElement(By.Id("Postcode"));
            editPostcodeTextBox.Clear();
            editPostcodeTextBox.SendKeys("5011");

            IWebElement editCountryTextBox = driver.FindElement(By.Id("Country"));
            editCountryTextBox.Clear();
            editCountryTextBox.SendKeys("NewZealand");




            IWebElement saveContactButton1 = driver.FindElement(By.Id("submitButton"));
            saveContactButton1.Click();

            driver.SwitchTo().DefaultContent();

            Wait.WaitToBeVisible(driver, "Id", "Password", 3);

            IWebElement editPWTextBox = driver.FindElement(By.Id("Password"));
            editPWTextBox.Clear();
            editPWTextBox.SendKeys("Data@123");

            IWebElement editRTPWTextBox = driver.FindElement(By.Id("RetypePassword"));
            editRTPWTextBox.Clear();
            editRTPWTextBox.SendKeys("Data@123");

            IWebElement selectElement = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]/input"));
            selectElement.Click();
            
            //selectElement.Clear();
            Thread.Sleep(3000);
            //selectElement.Click();

            //Thread.Sleep(3000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"groupList_listbox\"]/li[2]", 5);
            IWebElement optionDropdown = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[2]"));
            optionDropdown.Click();

            Thread.Sleep(3000);


            //Click on Save button

            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();



            Thread.Sleep(7000);


            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/div/a", 3);

            IWebElement backToListlink1 = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")); // //*[@id="container"]/div/a
            backToListlink1.Click();

            Thread.Sleep(2000);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span", 3);

            IWebElement goToLastPageButtonEd = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));////*[@id="usersGrid"]/div[4]/a[4]/span
            goToLastPageButtonEd.Click();
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            IWebElement name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(name.Text == "AjayNew", "Employee record not edited");


        }

        public void DeleteEmployee(IWebDriver driver)
        {
            IWebElement lPButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span")); ////*[@id="usersGrid"]/div[4]/a[4]/span
            lPButton.Click();

            Thread.Sleep(3000);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]", 5);

            IWebElement  deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]")); ////*[@id="usersGrid"]/div[3]/table/tbody/tr[3]/td[3]/a[2]
            deleteButton.Click();

            Thread.Sleep(3000);

            driver.SwitchTo().Alert().Accept();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            Thread.Sleep(4000);
            IWebElement deletedName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));////*[@id="usersGrid"]/div[3]/table/tbody/tr[3]/td[1]
            Assert.That(deletedName.Text != "AjayNew", "Employee record not deleted");


        }
    }
}
