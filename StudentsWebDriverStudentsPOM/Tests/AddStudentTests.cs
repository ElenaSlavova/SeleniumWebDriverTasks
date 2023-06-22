using NUnit.Framework;
using NUnit.Framework.Internal;
using StudentsWebDriverStudentsPOM.Pages;

namespace StudentsWebDriverStudentsPOM.Tests
{
    internal class AddStudentTests : BaseTest
    {
        private HomePage page;
        private AddStudentPage studentPage;
        private ViewStudentPage studentViewPage;
        

        [SetUp]
        public void Setup()
        {
            this.page = new HomePage(driver);
            this.studentPage= new AddStudentPage(driver);
            this.studentViewPage= new ViewStudentPage(driver);  
        }

        [Test]
        public void Test_AddStudent_CheckTitle()
        {
            page.Open();
            page.AddStudentLink.Click();

            Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));
        }

         [Test]
         public void Test_AddStudent_CheckNewStudentName()
         {
              page.Open();
         page.AddStudentLink.Click();
            studentPage.AddStudent("Pesho", "test@test.com");
            Assert.IsTrue(studentViewPage.GetAllRegisteredStudents().Contains("Pesho (test@test.com)"));
        }

        [Test]
        public void Test_TestAddStudentPage_Heading()
        {
            page.Open();
            page.AddStudentLink.Click();

            Assert.That(page.PageHeadingLabel.Text, Is.EqualTo("Register New Student"));
        }
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            page.Open();
            page.AddStudentLink.Click();

            Assert.That(page.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(page.PageHeadingLabel.Text, Is.EqualTo("Register New Student"));
        }
        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            page.Open();
            page.AddStudentLink.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsPageOpen());
            
        }
    }
}
