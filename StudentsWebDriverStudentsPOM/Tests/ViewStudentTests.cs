using NUnit.Framework;
using StudentsWebDriverStudentsPOM.Pages;

namespace StudentsWebDriverStudentsPOM.Tests
{
 
    public class ViewStudentTests : BaseTest
    {
        private BasePage page;

        [SetUp]
        public void Setup()
        {
            this.page = new BasePage(driver);
        }

        [Test]
        public void Test_ViewStudentPage_CheckTitle()
        {
            page.Open();
            page.ViewStudentsLink.Click();
            
            Assert.That(page.GetPageTitle(), Is.EqualTo("Students"));
        }

    
    }
}
