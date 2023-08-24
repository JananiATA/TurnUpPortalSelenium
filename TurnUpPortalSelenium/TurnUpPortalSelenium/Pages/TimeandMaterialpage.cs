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
    public class TimeandMaterialpage
    {
        public void Createtimerecord(IWebDriver driver)
        {
            //Click on the Create new button

            IWebElement createnewbutton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createnewbutton.Click();

            //Select the typecode

            IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodedropdown.Click();

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 3);

            IWebElement timetypecode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            //Thread.Sleep(1000);
            timetypecode.Click();

            //Enter the code

            IWebElement codetextbox = driver.FindElement(By.Id("Code"));
            codetextbox.SendKeys("123");

            //Enter the description

            IWebElement desctectbox = driver.FindElement(By.Id("Description"));
            desctectbox.SendKeys("Testdata");

            //Enter the price
            IWebElement pricetextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricetextbox.SendKeys("20");

            //Click on the save button
            IWebElement savebutton = driver.FindElement(By.Id("SaveButton"));
            savebutton.Click();

            Thread.Sleep(3000);

            //Check if new record has been created successfully

            IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotolastpagebutton.Click();

            
            //Assert.That(newcode.Text == "123", "New record is not Created");
            
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
            IWebElement newcode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newcode.Text;
        }
        public void edittimerecord(IWebDriver driver, string description)
        {
            //Editing new record

            IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotolastpagebutton.Click();

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 3);

            IWebElement Editbutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            //Thread.Sleep(1000);
            Editbutton.Click();

            Thread.Sleep(3000);


            //Change Typecode

            IWebElement newcodedropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            newcodedropdown.Click();

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[1]", 3);

            IWebElement matdropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]")); ////*[@id="TimeMaterialEditForm"]/div/div[1]/div/span[1]/span/span[1]
            Thread.Sleep(1000);
            matdropdown.Click();

            //Thread.Sleep(1000);

            wait.waittobevisible(driver, "Id", "Code", 2);

            //Change Code

            IWebElement newcodetextbox = driver.FindElement(By.Id("Code"));
            newcodetextbox.Clear();
            newcodetextbox.SendKeys("updatedcode");

            //Thread.Sleep(1000);

            //Change description

            IWebElement newdesctextbox = driver.FindElement(By.Id("Description"));
            newdesctextbox.Clear();
            newdesctextbox.SendKeys(description);

            //Thread.Sleep(1000);

            // change the price

            IWebElement overlappingtag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement pricetextboxnew = driver.FindElement(By.Id("Price"));
            overlappingtag.Click();
            pricetextboxnew.Clear();
            overlappingtag.Click();
            pricetextboxnew.SendKeys("300");

            //Thread.Sleep(1000);

            //Click Save

            IWebElement newsavebutton = driver.FindElement(By.Id("SaveButton"));
            newsavebutton.Click();

            //Thread.Sleep(3000);

            wait.waittobeclickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);

            //Check if the record has been edited successfully
            IWebElement gotolastpagebutton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));//*[@id="tmsGrid"]/div[4]/a[4]/span
            gotolastpagebutton1.Click();

            wait.waittobevisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 3);
           
            

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
            IWebElement Newdesc = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return Newdesc.Text;
        }
        public void deletetimerecord(IWebDriver driver)
        {
            //Delete new record

            //Thread.Sleep(3000);

            IWebElement gotolastpagebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotolastpagebutton.Click();

            Thread.Sleep(2000);
            wait.waittobeclickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 3);

            IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deletebutton.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept();
            wait.waittobevisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);
            Thread.Sleep(2000);

           // IWebElement newcode1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            

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
