namespace CurrentWorkFlowExample.PageObjects
{
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class CheckoutReviewPageObject : BasePageobject
    {
        public CheckoutReviewPageObject(DriverType driverName) : base(driverName)
        {
        }

        public CheckoutReviewPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void ConfirmOrder()
        {
            this.Driver.FindElement(By.Id(CheckoutReviewPageSelector.ConfirmOrderButtonId)).Click();
        }

        public void CancelOrder()
        {
            this.Wait.Until(driver => driver.FindElement(By.Id(CheckoutReviewPageSelector.CheckoutReviewPageId)).Displayed);
            this.Driver.FindElement(By.Id(CheckoutReviewPageSelector.CancelOrderButtonId)).Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(CartPageSelector.CartPageClass)).Displayed);
        }
    }
}