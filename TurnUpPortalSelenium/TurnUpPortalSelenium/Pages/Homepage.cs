using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortalSelenium.Pages
{
    public class Homepage
    {
        public void GotoTimeandMaterialpage(IWebDriver driver)
        {
            //Go to Time and Material page

            IWebElement administrationdropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationdropdown.Click();

            //select the Time and materials option

            IWebElement tmoption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmoption.Click();

            Thread.Sleep(2000);

        }
    }
}
