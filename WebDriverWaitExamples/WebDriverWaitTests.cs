using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverWaitExamples
{
    public class WebDriverWaitTests
    {

        private WebDriver driver;
        private WebDriverWait wait;
        private const string BaseUrl = "http://uitestpractice.com/";

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;
            //driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(15);
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Wait_ThreadSleep()
        {
            var AjaxLink = driver.FindElement(By.LinkText("AjaxCall"));
            AjaxLink.Click();

            var internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            Thread.Sleep(15000);

            var textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));
            
            driver.Navigate().Refresh();

            internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            Thread.Sleep(15000);

            textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));
        }

        [Test]
        public void Test_Wait_ImplicitWaitExample()
        {
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(15);   
            var AjaxLink = driver.FindElement(By.LinkText("AjaxCall"));
            AjaxLink.Click();

            var internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            

            var textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));

            driver.Navigate().Refresh();

            internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            

            textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));
        }
        [Test]
        public void Test_Wait_ExplicitWaitExample()
        {
            this.wait=new WebDriverWait(driver, TimeSpan.FromSeconds(15));  

            var AjaxLink = driver.FindElement(By.LinkText("AjaxCall"));
            AjaxLink.Click();

            var internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            var textElementText= wait.Until(d =>
            { return d.FindElement(By.ClassName("ContactUs")).Text;
            });

           // var textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));

            driver.Navigate().Refresh();

            internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();


             textElementText = wait.Until(d =>
            {
                return d.FindElement(By.ClassName("ContactUs")).Text;
            });
            //textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));
        }
        [Test]
        public void Test_Wait_SeleniumExtras_ExpectedConditiones()
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            var AjaxLink = driver.FindElement(By.LinkText("AjaxCall"));
            AjaxLink.Click();

            var internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            var textElementText = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs")));

            // var textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Text.Contains("Selenium is a portable software testing"));

            driver.Navigate().Refresh();

            internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();

            textElementText = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs")));
            //textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Text.Contains("Selenium is a portable software testing"));
        }

        [Test]
        public void Test_Wait_MultipleWaits()
        {
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(2);  
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            var AjaxLink = driver.FindElement(By.LinkText("AjaxCall"));
            AjaxLink.Click();

            var internalAjaxLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            internalAjaxLink.Click();


            var image = driver.GetScreenshot();
            image.SaveAsFile("screenshot.png",ScreenshotImageFormat.Png);

            var pageSource = driver.PageSource;

            Assert.False(pageSource.Contains("Selenium is a portable software testing"));   

            var textElementText = wait.Until(d =>
            {
                return d.FindElement(By.ClassName("ContactUs")).Text;
            });

            // var textElementText = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElementText.Contains("Selenium is a portable software testing"));

           
        }
    }
    
}