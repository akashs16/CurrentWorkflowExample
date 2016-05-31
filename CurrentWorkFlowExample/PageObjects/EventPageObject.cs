namespace CurrentWorkFlowExample.PageObjects
{
    using System;
    using System.Threading;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class EventPageObject : BasePageobject
    {
        public EventPageObject(DriverType driverName) : base(driverName)
        {
        }

        public EventPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void GoToProductPageForThatProduct()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            this.Wait.Until(driver => driver.FindElement(By.CssSelector("#block-system-main > div > div.reebonzListingPage > div.itemListingContainer > div > div > div:nth-child(1)")).Displayed
            && driver.FindElement(By.CssSelector("#block-system-main > div > div.reebonzListingPage > div.itemListingContainer > div > div > div:nth-child(1)")).Enabled);
            var eventProducts = this.Driver.FindElements(By.CssSelector(EventsPageSelector.AllProductsCss));
            var requiredProduct = eventProducts[0].FindElement(By.CssSelector("div > div.itemListingImage > a"));

            requiredProduct.Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(ProductPageSelector.ProductPageClass)).Displayed);
        }
    }
}