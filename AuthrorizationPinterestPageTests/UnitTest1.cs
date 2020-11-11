using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AuthrorizationPinterestPageTests
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _signInButton = By.XPath("//div[text()='Войти']");
        private readonly By _loginInputButton = By.XPath("//input[@name='id']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='password']");
        private readonly By _signUpButton = By.XPath("//button[@type='submit']");
        private readonly By _loggedInUserButton = By.XPath("//*[@href='/viacheslavdars/']");
        private readonly By _userLogin = By.XPath("//span[text()='@viacheslavdars']");

        private const string _login = "viacheslav.dars@gmail.com";
        private const string _password = "123456wW";
        private const string _expectedLogin = "@viacheslavdars";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.pinterest.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            var login = driver.FindElement(_loginInputButton);
            login.SendKeys(_login);

            var password = driver.FindElement(_passwordInputButton);
            password.SendKeys(_password);

            var signUp = driver.FindElement(_signUpButton);
            signUp.Click();

            Thread.Sleep(3000);

            var loggedInUser = driver.FindElement(_loggedInUserButton);
            loggedInUser.Click();

            Thread.Sleep(800);

            var actualLogin = driver.FindElement(_userLogin).Text;

            Assert.AreEqual(_expectedLogin, actualLogin, "Login is wrong");
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
    }
}