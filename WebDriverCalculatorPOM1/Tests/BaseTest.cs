﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverCalculatorPOM1.Tests
{
    public class BaseTest
    {
        protected WebDriver driver;

        [SetUp]

        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
