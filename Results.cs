using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestAmazon
{
    public class Results
    {
        private IWebDriver driver;
        private SearchBar searchBar;

        public Results(IWebDriver driver)
        {
            this.driver = driver;
            this.searchBar = new SearchBar(driver);
        }

        public List<Item> GetResultBy(Dictionary<string, string> filters)
        {

            string xpath = "//span[@class='a-offscreen'";

            foreach (KeyValuePair<string, string> filter in filters)
            {
                switch (filter.Key)
                {
                    case "price lower then":
                        string x = "<" + filters["price lower then"];
                        xpath += "and substring(.,2) " + x;
                        break;
                    case "price higher or eauals":
                        string x1 = ">=" + filters["price higher or eauals"];
                        xpath += " and substring(.,2) " + x1;
                        break;
                    case "free shipping":
                        if (filters["free shipping"] == "true")
                            xpath += " and .//ancestor::div[@class='sg-row' and contains(.,'FREE')]]";
                        break;
                }
            }
            xpath += "//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small']";
            Console.WriteLine(xpath);
           
            List<Item> results = new List<Item>();
            IList<IWebElement> elements = driver.FindElements(By.XPath(xpath)).ToArray();

            Console.WriteLine(elements.Count());

            foreach (IWebElement element in elements)
            {
                string title = element.FindElement(By.XPath(".//span[@class='a-size-medium a-color-base a-text-normal']")).Text;
                string price = element.FindElement(By.XPath(".//span[@class='a-price']")).Text;
                var url = element.FindElement(By.XPath(".//a[@class='a-size-base a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']")).GetAttribute("href");
                Item i = new Item(title, price, url);
                results.Add(i);
                Console.WriteLine(i.tostring());
            }
            return results;
        }
    }
}
