using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon
{
    public class SearchBar
    {
        private IWebDriver driver;
        private string text;
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string Text
        {
            get
            {
                var sexrchText = driver.FindElement(By.Id("twotabsearchtextbox"));
                return sexrchText.GetAttribute("value");
            }
            set
            {
                var searchText = driver.FindElement(By.Id("twotabsearchtextbox"));
                searchText.SendKeys(value);
                // searchText.Clear();
            }
        }
        public void Click()
        {
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
        }
    }
}
