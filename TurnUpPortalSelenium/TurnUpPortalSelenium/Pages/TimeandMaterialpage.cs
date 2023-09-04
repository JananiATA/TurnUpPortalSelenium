using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.Pages
{
    public class TimeAndMaterialPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on the Create new button

            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select the typecode

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 3);

            IWebElement timeTypeCode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            //Thread.Sleep(1000);
            timeTypeCode.Click();

            //Enter the code

            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("123");

            //Enter the description

            IWebElement descTextBox = driver.FindElement(By.Id("Description"));
            descTextBox.SendKeys("Testdata");

            //Enter the price
            IWebElement priceTextBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextBox.SendKeys("20");

            //Click on the save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(3000);

            //Check if new record has been created successfully

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            Assert.That(newCode.Text == "123", "New record is not Created");

            /* if (newcode.Text == "123")
             {
                 Assert.Pass("New record is created");
             }
             else
             {
                 Assert.Fail("New record is not created");
             } */

        } 
        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }
        public void EditTimeRecord(IWebDriver driver, string description)
        {
            //Editing new record

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            //Thread.Sleep(1000);
            editButton.Click();

            Thread.Sleep(3000);


            //Change Typecode

            IWebElement newCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            newCodeDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[1]", 3);

            IWebElement matDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]")); ////*[@id="TimeMaterialEditForm"]/div/div[1]/div/span[1]/span/span[1]
            Thread.Sleep(1000);
            matDropdown.Click();

            //Thread.Sleep(1000);

            Wait.WaitToBeVisible(driver, "Id", "Code", 2);

            //Change Code

            IWebElement newCodeTextBox = driver.FindElement(By.Id("Code"));
            newCodeTextBox.Clear();
            newCodeTextBox.SendKeys("updatedcode");

            //Thread.Sleep(1000);

            //Change description

            IWebElement newDescTextBox = driver.FindElement(By.Id("Description"));
            newDescTextBox.Clear();
            newDescTextBox.SendKeys(description);

            //Thread.Sleep(1000);

            // change the price

            IWebElement overLappingTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextBoxNew = driver.FindElement(By.Id("Price"));
            overLappingTag.Click();
            priceTextBoxNew.Clear();
            overLappingTag.Click();
            priceTextBoxNew.SendKeys("300");

            //Thread.Sleep(1000);

            //Click Save

            IWebElement newSaveButton = driver.FindElement(By.Id("SaveButton"));
            newSaveButton.Click();

            //Thread.Sleep(3000);

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);

            //Check if the record has been edited successfully
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));//*[@id="tmsGrid"]/div[4]/a[4]/span
            goToLastPageButton1.Click();

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 3);

            IWebElement newdesc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(newdesc.Text  == description, "New record not editted successfully");

            /*
            if (Newdesc.Text == "Testdatanew")
            {
                Console.WriteLine("New record has been edited successfully");

            }
            else
            {
                Console.WriteLine("New record has not been edited");
            }
            */
        }
        public string GetEditedDesc(IWebDriver driver)
        {
            IWebElement newDesc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDesc.Text;
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Delete new record

            //Thread.Sleep(3000);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(2000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 3);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            Thread.Sleep(2000);

            IWebElement newCode1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode1.Text != "123", "New record not deleted successfully");
            

           /*
            if (newcode1.Text != "123")
            {

                Console.WriteLine(" New record has been successfully deleted");

            }
            else
            {
                Console.WriteLine("New record has not been deleted");
            }
           */
        }

        public string GetCodeValue(IWebDriver driver)
        {
            IWebElement newCodeDelete = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCodeDelete.Text;
        }
    }
}
