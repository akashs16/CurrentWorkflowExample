namespace CurrentWorkFlowExample.PageObjects
{
    using System;
    using System.Threading;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class LandingPagePageObject : BasePageobject
    {
        public LandingPagePageObject(DriverType driverType) : base(driverType)
        {
        }

        public LandingPagePageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void GoToEvent(int eventNumber)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var events = this.Driver.FindElements(By.CssSelector(LandingPageSelector.AllEventsCss));
            var requiredEvent = events[eventNumber].FindElement(By.CssSelector("a"));
            requiredEvent.Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(EventsPageSelector.ProductListClass)));
        }
    }
}
