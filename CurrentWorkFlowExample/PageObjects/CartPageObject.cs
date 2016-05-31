namespace CurrentWorkFlowExample.PageObjects
{
    using System.Linq;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class CartPageObject : BasePageobject
    {
        public CartPageObject(DriverType driverName) : base(driverName)
        {
        }

        public CartPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void ProceedToCheckout()
        {
            this.Driver.FindElement(By.Id(CartPageSelector.CheckoutButton)).Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(CheckoutPageSelector.CheckoutPageClass)).Displayed);
        }

        public void CleanUpCart()
        {
            int productCount;
            do
            {
                var productsInCart = this.Driver.FindElements(By.CssSelector(CartPageSelector.ProductsInCartCss));
                productsInCart.First().FindElement(By.CssSelector(CartPageSelector.RemoveProductButtonCss)).Click();

                productsInCart = this.Driver.FindElements(By.CssSelector(CartPageSelector.ProductsInCartCss));
                productCount = productsInCart.Count;
            } while (productCount > 0);
        }
    }
}