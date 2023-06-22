using OpenQA.Selenium;

namespace StudentsWebDriverStudentsPOM.Pages
{
    public class BasePage
    {

        private WebDriver driver;
       
        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public virtual string BaseUrl { get;}
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.LinkText("View Students"));
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));
       public IWebElement PageHeadingLabel =>driver.FindElement(By.CssSelector("body > h1"));


        public void Open()
        { driver.Navigate().GoToUrl(BaseUrl); }
        public string GetPageTitle()
        { return driver.Title; }
        public bool IsPageOpen()
        {

            return driver.Url == BaseUrl;
        }


    }
}
