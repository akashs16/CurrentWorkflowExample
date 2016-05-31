namespace CurrentWorkFlowExample.PageObjects
{
    using System;
    using System.IO;
    using System.Reflection;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class BasePageobject
    {
        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }

        private const string DriverLocation = "\\Resources\\Drivers\\";

        protected BasePageobject(DriverType driverName)
        {
            this.Driver = this.GetDriver(driverName);
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
        }

        protected BasePageobject(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;
        }

        public void GotoUrl(Uri homePageUrl)
        {
            this.Driver.Navigate().GoToUrl(homePageUrl);
        }

        private IWebDriver GetDriver(DriverType driverName)
        {
            var resourcePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var parent = Directory.GetParent(resourcePath);
            var path = parent + DriverLocation;
            switch (driverName)
            {
                case DriverType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArguments("--start-maximized");
                    return new ChromeDriver(path, options);
                case DriverType.FireFox:
                    return null;
                case DriverType.Safari:
                    return null;
                case DriverType.Edge:
                    return null;
                case DriverType.IE11:
                    return null;
                case DriverType.Opera:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverName), driverName, null);
            }
        }
    }
}