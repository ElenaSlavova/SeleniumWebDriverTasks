using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverNUnitDemo
{
    public class WebDriverTests
    {

        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            this.driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Url = "https://wikipedia.org";
        }

      
        [Test]
        public void Test_Wikipedia_CheckTitle()
        {
            

            var pageTitle = driver.Title;

            Assert.That("Wikipedia", Is.EqualTo(pageTitle));
        }
        [Test]
        public void Test_Wikipedia_SearchField()
        {
            //driver.Url = "https://Wikipedia.org";

            var searchField = driver.FindElement(By.Id("searchInput"));
            searchField.SendKeys("QA" + Keys.Enter);
            //searchField.SendKeys(Keys.Enter);
            var pageTitle=driver.Title;

            Assert.That("QA - Wikipedia",Is.EqualTo(pageTitle));    
        }
        [Test]
         public void Test_Wikipedia_CheckDeutsch()
        {
            //driver.Url = "https://Wikipedia.org";
            var allStrongElements = driver.FindElements(By.TagName("strong"));
            var germanLinkText = allStrongElements[5].Text;

            Assert.That("Deutsch", Is.EqualTo(germanLinkText));  
        }

        [Test]
        public void Test_Wikipedia_CheckItaliano()
        {

            var allStrongElements = driver.FindElements(By.TagName("strong"));
            var italianLink = allStrongElements[7];
            italianLink.Click();
            var pageTitle= driver.Title;

            Assert.That("Wikipedia, l'enciclopedia libera", Is.EqualTo(pageTitle));
        }

        [Test]
        public void Test_Wikipedia_CheckName()
        {
            //This is not unique!!!
            var searchField = driver.FindElement(By.Name("search"));

            searchField.SendKeys("QA" + Keys.Enter);
            var pageTitle= driver.Title;

            Assert.That("QA - Wikipedia", Is.EqualTo(pageTitle));
        }
       

        [Test]
        public void Test_Wikipedia_CheckItalianLink()
        {
           
            var allStrongElements = driver.FindElements(By.TagName("strong"));
            var italianLink = driver.FindElement(By.PartialLinkText("Italiano"));
            italianLink.Click();    
            var pageTitle= driver.Title;    

            Assert.That("Wikipedia, l'enciclopedia libera", Is.EqualTo(pageTitle));

        
        }
        [Test]
        public void Test_Wikipedia_CheckItalianLink_Other()
        {

            var allStrongElements = driver.FindElements(By.TagName("strong"));
            var italianLink = driver.FindElement(By.PartialLinkText("Italiano"));
            italianLink.Click();
            var pageTitle = driver.Title;

            Assert.That("Wikipedia, l'enciclopedia libera", Is.EqualTo(pageTitle));

            var MTVLink = driver.FindElement(By.LinkText("MTV"));
            MTVLink.Click();

            //OR driver.FindElement(By.LinkText("Bizzard Enertainment")).Click();

            var expectedTitle = "MTV - Wikipedia";
            Assert.That(expectedTitle, Is.EqualTo(driver.Title));
        }

        [Test]
        public void Test_Wikipedia_SearchField_BySSC_Selector()
        {
          
            var searchField = driver.FindElement(By.CssSelector("#searchInput"));
            searchField.SendKeys("QA" + Keys.Enter);
            //searchField.SendKeys(Keys.Enter);
            var pageTitle = driver.Title;

            Assert.That("QA - Wikipedia", Is.EqualTo(pageTitle));
        }

        [Test]
        public void Test_Wikipedia_SearchField_ByXpath()
        {

          var searchField = driver.FindElement(By.XPath("//input[@type='search']"));
            
            searchField.SendKeys("QA" + Keys.Enter);
            //searchField.SendKeys(Keys.Enter);
            var pageTitle = driver.Title;

            Assert.That("QA - Wikipedia", Is.EqualTo(pageTitle));
        }
        [TearDown]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }

    }
}