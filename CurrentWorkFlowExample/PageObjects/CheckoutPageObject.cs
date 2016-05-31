namespace CurrentWorkFlowExample.PageObjects
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Threading;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class CheckoutPageObject : BasePageobject
    {
        public CheckoutPageObject(DriverType driverName) : base(driverName)
        {
        }

        public CheckoutPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void PlaceOrder(string paymentMethod)
        {
            this.Wait.Until(driver => driver.FindElement(By.CssSelector("#edit-payment-box > div > ul")).Displayed);
            this.Wait.Until(driver => driver.FindElement(By.Id("shipping0")).Displayed && driver.FindElement(By.Id("shipping0")).Enabled);
            this.Driver.FindElement(By.Id(CheckoutPageSelector.ShippingAddressCheckboxId)).Click();
            this.Driver.FindElement(By.Id(CheckoutPageSelector.BillingAddressCheckboxId)).Click();
            this.SelectPaymentMethod(paymentMethod);
            this.Driver.FindElement(By.Id(CheckoutPageSelector.AgreeToTermsAndConditionsCheckboxId)).Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            this.Driver.FindElement(By.Id(CheckoutPageSelector.PlaceOrderButtonId)).Click();
            this.Wait.Until(driver => driver.FindElement(By.Id(CheckoutReviewPageSelector.CheckoutReviewPageId)).Displayed);
        }

        private void SelectPaymentMethod(string paymentMethod)
        {
            var availablePaymentMethods = this.Driver.FindElements(By.CssSelector(CheckoutPageSelector.PaymentMethodsCss));
            IWebElement paymentMethodToSelect;
            try
            {
                paymentMethodToSelect =
                    availablePaymentMethods.First(
                        x => x.FindElement(By.CssSelector("label")).Text.ToLower().Contains(paymentMethod.ToLower()));
            }
            catch (InvalidOperationException)
            {
                if (paymentMethod.ToLower() == "unionpay")
                {
                    paymentMethod = "cup_on_full";
                }

                paymentMethodToSelect =
                    availablePaymentMethods.First(
                        x => x.FindElement(By.CssSelector("input")).GetAttribute("value").Contains(paymentMethod));
            }

            paymentMethodToSelect.FindElement(By.CssSelector("input")).Click();
        }
    }
}
