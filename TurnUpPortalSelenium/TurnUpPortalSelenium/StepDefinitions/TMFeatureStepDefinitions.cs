using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TurnUpPortalSelenium.Pages;
using TurnUpPortalSelenium.Utilities;

namespace TurnUpPortalSelenium.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : Commondriver 
    {
        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();
            //login page object initialization and Definition
            Loginpage loginpageobj = new Loginpage();
            loginpageobj.loginactions(driver);
        }

        [Given(@"I navigate to Time and Materials page")]
        public void GivenINavigateToTimeAndMaterialsPage()
        {
            //Home page object initialization and definition
            Homepage homepageobj = new Homepage();
            homepageobj.GotoTimeandMaterialpage(driver);
        }

        [When(@"I create a new Time record")]
        public void WhenICreateANewTimeRecord()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.Createtimerecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            string newcode1 = tmPageobj.GetCode(driver);
            Assert.That(newcode1 == "123", "New record is not Created");
        }

        [When(@"I update '([^']*)' on existing Time record")]
        public void WhenIUpdateOnExistingTimeRecord(string p0)
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.edittimerecord(driver, p0);
        }

        [Then(@"the record should have an updated '([^']*)'")]
        public void ThenTheRecordShouldHaveAnUpdated(string p0)
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            string newDesc = tmPageobj.GetEditedDesc(driver);
            Assert.That(newDesc == p0, "Decription has not been edited");
        }

        [When(@"I delete an existing Time record")]
        public void WhenIDeleteAnExistingTimeRecord()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();
            tmPageobj.deletetimerecord(driver);
        }

        [Then(@"the record should be deleted successfully")]
        public void ThenTheRecordShouldBeDeletedSuccessfully()
        {
            TimeandMaterialpage tmPageobj = new TimeandMaterialpage();

            string newCode2 = tmPageobj.GetCodeValue(driver);

            Assert.That(newCode2 != "123", "New record has not been deleted");
        }



    }
}
