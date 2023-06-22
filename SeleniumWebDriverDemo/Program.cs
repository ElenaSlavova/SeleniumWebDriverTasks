using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriverDemo
{
    public class SeleniumWebDriver
    {
        static void Main()
        {
            //create driver
             var driver = new ChromeDriver();
           // var driver = new FirefoxDriver();
            //var driver = new EdgeDriver();

            //navigato to Wikipedia
            //driver.Url = "https://wikipedia.org";
            driver.Navigate().GoToUrl("https://wikipedia.org");

            //get broser title
            var pageTitle = driver.Title;

            Console.WriteLine("The page title is " + pageTitle);

            if(pageTitle=="Wikipedia")
            { Console.WriteLine("TEST PASS"); }
            else 
            { Console.WriteLine("TEST FAIL"); }
         
            //close browser
            driver.Quit();
        }
    }
}