namespace CurrentWorkFlowExample.PageObjects
{
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class ProductPageObject : BasePageobject
    {
        public ProductPageObject(DriverType driverName) : base(driverName)
        {
        }

        public ProductPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void ProceedToCart()
        {
            this.Driver.FindElement(By.Id(ProductPageSelector.BuyNowButtonId)).Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(CartPageSelector.CartPageClass)).Enabled);
        }
    }
}