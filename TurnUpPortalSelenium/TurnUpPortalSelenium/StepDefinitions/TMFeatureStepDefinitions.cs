    using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnUpPortalSelenium.Pages;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver 
    {
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();
            //login page object initialization and Definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);
        }

        [Given(@"I navigate to Time and Materials page")]
        public void GivenINavigateToTimeAndMaterialsPage()
        {
            //Home page object initialization and definition
            HomePage homepageobj = new HomePage();
            homepageobj.GotoTimeandMaterialPage(driver);
        }

        [When(@"I create a new Time record")]
        public void WhenICreateANewTimeRecord()
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();
            tmPageobj.CreateTimeRecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();
            string newcode1 = tmPageobj.GetCode(driver);
            Assert.That(newcode1 == "123", "New record is not Created");
        }

        [When(@"I update '([^']*)' on existing Time record")]
        public void WhenIUpdateOnExistingTimeRecord(string p0)
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();
            tmPageobj.EditTimeRecord(driver, p0);
        }

        [Then(@"the record should have an updated '([^']*)'")]
        public void ThenTheRecordShouldHaveAnUpdated(string p0)
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();
            string newDesc = tmPageobj.GetEditedDesc(driver);
            Assert.That(newDesc == p0, "Decription has not been edited");
        }

        [When(@"I delete an existing Time record")]
        public void WhenIDeleteAnExistingTimeRecord()
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();
            tmPageobj.DeleteTimeRecord(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            TimeAndMaterialPage tmPageobj = new TimeAndMaterialPage();

            string newCode2 = tmPageobj.GetCodeValue(driver);

            Assert.That(newCode2 != "123", "New record has not been deleted");
        }



    }
}
