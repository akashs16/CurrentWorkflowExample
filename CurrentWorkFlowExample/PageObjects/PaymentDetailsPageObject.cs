namespace CurrentWorkFlowExample.PageObjects
{
    using System;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class PaymentDetailsPageObject : BasePageobject
    {
        public PaymentDetailsPageObject(DriverType driverName) : base(driverName)
        {
        }

        public PaymentDetailsPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void CancelOrder(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Express:
                    break;
                case PaymentType.PayPal:
                    this.Driver.FindElement(By.Id(PaymentDetailsPageSelector.PayPalCancelLinkId)).Click();
                    break;
                case PaymentType.Card:
                    this.Driver.FindElement(By.Id(PaymentDetailsPageSelector.CardCancelButtonId)).Click();
                    break;
                case PaymentType.UOB:
                    break;
                case PaymentType.DBS:
                    break;
                case PaymentType.OCBC:
                    break;
                case PaymentType.Credit:
                    break;
                case PaymentType.Bank:
                    break;
                case PaymentType.Union:
                    this.Driver.FindElement(By.Id(PaymentDetailsPageSelector.UnionPayCancelLinkId)).Click();
                    break;
                case PaymentType.AliPay:
                    this.Driver.FindElement(By.Id(PaymentDetailsPageSelector.AliPayCancelLinkId)).Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null);
            }

            this.Wait.Until(driver => driver.FindElement(By.ClassName(CartPageSelector.CartPageClass)).Displayed);
        }

        public string GetPaymentPageDiscription(PaymentType paymentType)
        {
            switch (paymentType)
            {
                case PaymentType.Express:
                    return null;
                case PaymentType.PayPal:
                    return this.Driver.FindElement(By.CssSelector(PaymentDetailsPageSelector.PayPalDetailsPageCss)).Text;
                case PaymentType.Card:
                    return this.Driver.FindElement(By.CssSelector(PaymentDetailsPageSelector.CardDetailsPageCss)).Text;
                case PaymentType.UOB:
                    return null;
                case PaymentType.DBS:
                    return null;
                case PaymentType.OCBC:
                    return null;
                case PaymentType.Credit:
                    return null;
                case PaymentType.Bank:
                    return null;
                case PaymentType.Union:
                    return this.Driver.FindElement(By.CssSelector(PaymentDetailsPageSelector.UnionPayDetailsCss)).Text;
                case PaymentType.AliPay:
                    return this.Driver.FindElement(By.ClassName(PaymentDetailsPageSelector.AliPayDetailsClass)).Text;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null);
            }
        }
    }
}