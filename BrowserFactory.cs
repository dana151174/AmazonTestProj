using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace OnlineStore.WrapperFactory
{
    public class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", driver);
                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", driver);
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(@"C:\\Users\\User\\Desktop\\Drivers");
                        Drivers.Add("Chrome", driver);
                    }
                    break;
            }
        }

        public void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
