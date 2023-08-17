//Open the browser
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortalSelenium.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        //login page object initialization and Definition
        Loginpage loginpageobj = new Loginpage();
        loginpageobj.loginactions(driver);

        //Home page object initialization and definition
        Homepage homepageobj = new Homepage();
        homepageobj.GotoTimeandMaterialpage(driver);

        //Time and Materials page object initialization and definition
        TimeandMaterialpage tmoageobj = new TimeandMaterialpage();
        tmoageobj.Createtimerecord(driver);
        tmoageobj.edittimerecord(driver);
        tmoageobj.deletetimerecord(driver);

       
    }
}