//Open the browser
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//launch the turnup portal and navigate to login

driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//Identify username textbox and enter valid userename

IWebElement usernametextbox = driver.FindElement(By.Id("UserName"));
usernametextbox.SendKeys("hari");


//Identify password textbox and enter valid password

IWebElement passwordtextbox = driver.FindElement(By.Id("Password"));
passwordtextbox.SendKeys("123123");

//Click on the login button

IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginbutton.Click();

//check if the user is logged in successfully

IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

if(hellohari.Text == "Hello hari!")
{
    Console.WriteLine("User logged in successfully");
}
else
{
    Console.WriteLine("User not logged in successfully");

}


