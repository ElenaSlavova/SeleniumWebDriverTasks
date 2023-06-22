using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests3
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        private ChromeOptions options;

        IWebElement firstInput;
        IWebElement secondInput;
        IWebElement operationField;
        IWebElement calcButton;
        IWebElement resultField;
        IWebElement resetButton;


        [OneTimeSetUp]
        public void OpenBrowser()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless");
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

        [TestCase("10","+","2", "Result: 12")]
        [TestCase("-10","+","-2", "Result: -12")]
        [TestCase("10","*","2", "Result: 20")]
        [TestCase("-10","*","-2", "Result: 20")]
        [TestCase("10","-","2", "Result: 8")]
        [TestCase("-10","-","-2", "Result: -8")]
        [TestCase("-10","-","aaa", "Result: invalid input")]
        public void Test_Calculator(string firstNum, string operation, string secondNum, string expectedResult)
        {
            resetButton.Click();
            firstInput.SendKeys(firstNum);
            secondInput.SendKeys(secondNum);
            operationField.SendKeys(operation);

            calcButton.Click();

            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
     
    }
}