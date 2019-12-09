using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Demos
    {
        static void Main(string[] args)
        {
        }
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\Asus\\Desktop\\chromedriver_win32");
        }

        string username = "dsjhsadjhajd@dadk.lt";
        string password = "labas";

        public void Login(string user, string pass)
        {
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(user);
            driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(pass);
        }
        [Test]
        public void loginascorrect()
        {
            driver.Url = "http://automationpractice.com/";
            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login(username, password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='SubmitLogin']/span")).Click();

            var myAccount = driver.FindElement(By.XPath("//*[@id='center_column']/h1")).Text.ToLower().Contains("my account");
            Assert.IsTrue(myAccount);

            driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[3]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='center_column']/ul/li/div/div[1]/div/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var condition = driver.FindElement(By.XPath("//*[@id='product_condition']/label")).Text.ToLower().Contains("condition");
            Assert.IsTrue(condition);

            driver.FindElement(By.XPath("//*[@id='add_to_cart']/button/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='center_column']/form/p/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath("//*[@id='cgv']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='form']/p/button/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='HOOK_PAYMENT']/div[1]/div/p/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//*[@id='cart_navigation']/button/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var complete = driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong")).Text.ToLower().Contains("complete");
            Assert.IsTrue(complete);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();

        }
    }

}



