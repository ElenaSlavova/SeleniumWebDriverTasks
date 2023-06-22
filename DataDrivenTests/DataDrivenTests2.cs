using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests2
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        IWebElement firstInput;
        IWebElement secondInput;
        IWebElement operationField;
        IWebElement calcButton;
        IWebElement resultField;
        IWebElement resetButton;


        [OneTimeSetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;


            firstInput = driver.FindElement(By.Id("number1"));
            secondInput = driver.FindElement(By.Id("number2"));
            operationField = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resultField = driver.FindElement(By.Id("result"));
            resetButton = driver.FindElement(By.Id("resetButton"));

        }

        [OneTimeTearDown]
       public void CloseBrowser() 
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            resetButton.Click();
            firstInput.SendKeys("10");
            secondInput.SendKeys("2");
            operationField.SendKeys("+");

            calcButton.Click();

            var expectedResult = "Result: 12";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            resetButton.Click();    
            firstInput.SendKeys("-10");
            secondInput.SendKeys("-2");
            operationField.SendKeys("+");

            calcButton.Click();

            var expectedResult = "Result: -12";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            resetButton.Click();
            firstInput.SendKeys("10");
            secondInput.SendKeys("2");
            operationField.SendKeys("*");

            calcButton.Click();

            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            resetButton.Click();
            firstInput.SendKeys("-10");
            secondInput.SendKeys("-2");
            operationField.SendKeys("*");

            calcButton.Click();

            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            resetButton.Click();
            firstInput.SendKeys("10");
            secondInput.SendKeys("2");
            operationField.SendKeys("-");

            calcButton.Click();

            var expectedResult = "Result: 8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
        [Test]
        public void Test_Substract_TwoNegativeNumbers()
        {
            resetButton.Click();
            firstInput.SendKeys("-10");
            secondInput.SendKeys("-2");
            operationField.SendKeys("-");

            calcButton.Click();

            var expectedResult = "Result: -8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
    }
}