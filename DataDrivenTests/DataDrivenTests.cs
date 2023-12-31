using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
        }

        [TearDown]
       public void CloseBrowser() 
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("+");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 12";

            Assert.That(expectedResult,Is.EqualTo(resultField.Text));


        }
        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("-10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("-2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("+");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: -12";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));


        }
        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("*");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 20";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("-10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("-2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("*");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 20";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("-");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: 8";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
        [Test]
        public void Test_Substract_TwoNegativeNumbers()
        {
            var firstInput = driver.FindElement(By.Id("number1"));
            firstInput.SendKeys("-10");
            var secondInput = driver.FindElement(By.Id("number2"));
            secondInput.SendKeys("-2");
            var operationField = driver.FindElement(By.Id("operation"));
            operationField.SendKeys("-");

            var calcButton = driver.FindElement(By.Id("calcButton"));
            calcButton.Click();

            var resultField = driver.FindElement(By.Id("result"));

            var expectedResult = "Result: -8";

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));

        }
    }
}