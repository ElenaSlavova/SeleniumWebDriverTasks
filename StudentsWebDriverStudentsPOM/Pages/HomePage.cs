
using OpenQA.Selenium;

namespace StudentsWebDriverStudentsPOM.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver driver;
        public HomePage(WebDriver driver) : base(driver)
        {
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/";

        public IWebElement RegisredStudentLabel => driver.FindElement(By.CssSelector("body > p"));
    }
}
