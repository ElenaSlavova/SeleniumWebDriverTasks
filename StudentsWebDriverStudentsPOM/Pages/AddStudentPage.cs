using OpenQA.Selenium;

namespace StudentsWebDriverStudentsPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        private readonly IWebDriver driver;
        public AddStudentPage(WebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/add-student";

        public IWebElement AddRegisterName => driver.FindElement(By.CssSelector("#name"));
        public IWebElement AddRegisterEmail => driver.FindElement(By.CssSelector("#email"));
        public IWebElement AddButton => driver.FindElement(By.CssSelector("form[method='post'] > button[type='submit']"));
        public void AddStudent(string name, string email) {

            this.AddRegisterName.SendKeys(name);
            this.AddRegisterEmail.SendKeys(email);
            this.AddButton.Click();
        } 
        
    }
}
