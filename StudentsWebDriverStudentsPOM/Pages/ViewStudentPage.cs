using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace StudentsWebDriverStudentsPOM.Pages
{
    public class ViewStudentPage : BasePage
    {
        private readonly IWebDriver driver;
        public ViewStudentPage(WebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public override string BaseUrl => "https://studentregistry.softuniqa.repl.co/students";

        public ReadOnlyCollection<IWebElement> ListStudents => driver.FindElements(By.CssSelector("body > ul > li"));

        public List<string> GetAllRegisteredStudents()
        {
            List<string> elementStudents = this.ListStudents.Select(s=>s.Text).ToList();
            return elementStudents;
        }

    }
}
