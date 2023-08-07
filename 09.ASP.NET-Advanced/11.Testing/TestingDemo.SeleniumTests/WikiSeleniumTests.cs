using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestingDemo.SeleniumTests
{
    public class WikiSeleniumTests
    {
        [Test]
        public void Test_Wikipedia_Title()
        {
            var driver = new ChromeDriver();
            driver.Url = "https://www.wikipedia.org/";
            var searchInputElement = driver
               .FindElement(By.Id("searchInput"));
            searchInputElement.Click();
            searchInputElement.SendKeys("QA");
            searchInputElement.SendKeys(Keys.Enter);
            Assert.That(driver.Title.Contains("QA"));
            driver.Quit();
        }
    }
}