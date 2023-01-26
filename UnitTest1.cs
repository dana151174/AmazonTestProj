using OnlineStore.WrapperFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon
{
    public class Tests
    {
        IWebDriver driver;
        Amazon amazon;
        Dictionary<string, string> filters;

        [SetUp]
        public void Setup()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            browserFactory.InitBrowser("Chrome");
            driver = BrowserFactory.Driver;
            amazon = new Amazon(driver);
            filters = new Dictionary<string, string>();
            filters["price lower then"] = "100";
            filters["price higher or eauals"] = "50";
            filters["free shipping"] = "true";
        }

        [Test]
        public void SearchForMouse()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/?language=en_US");
            amazon.Pages.Home.SearchBar.Text = "mouse";
            amazon.Pages.Home.SearchBar.Click();
            amazon.Pages.Reslts.GetResultBy(filters);
            Assert.Pass();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}