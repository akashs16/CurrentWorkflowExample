namespace CurrentWorkFlowExample.Steps
{
    using System;
    using Constants;
    using DataObjects;
    using Enums;
    using NUnit.Framework;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class EndToEndUserFlowsSteps
    {
        private readonly LandingPagePageObject landingPagePageObect;
        private readonly HeaderPageObject headerPageObject;
        private readonly EventPageObject eventPageObject;
        private readonly ProductPageObject productPageObject;
        private readonly CartPageObject cartPageObject;
        private readonly CheckoutPageObject checkoutPageObject;
        private readonly PaymentDetailsPageObject paymentDetailsPageObject;
        private readonly CheckoutReviewPageObject checkoutReviewPageObject;

        public EndToEndUserFlowsSteps()
        {
            this.landingPagePageObect = new LandingPagePageObject(DriverType.Chrome);
            var driver = this.landingPagePageObect.Driver;
            var wait = this.landingPagePageObect.Wait;
            this.headerPageObject = new HeaderPageObject(driver, wait);
            this.eventPageObject = new EventPageObject(driver, wait);
            this.productPageObject = new ProductPageObject(driver, wait);
            this.cartPageObject = new CartPageObject(driver, wait);
            this.checkoutPageObject = new CheckoutPageObject(driver, wait);
            this.checkoutReviewPageObject = new CheckoutReviewPageObject(driver, wait);
            this.paymentDetailsPageObject = new PaymentDetailsPageObject(driver, wait);

            ScenarioContext.Current.Add(TestConstants.Driver, driver);
            ScenarioContext.Current.Add(TestConstants.Wait, wait);
        }

        [Given(@"I am on the landing page of the (.*) website")]
        public void GivenIAmOnTheLandingPageOfTheWebsite(string website)
        {
            var navigationUrl = new Uri(website);
            this.landingPagePageObect.GotoUrl(navigationUrl);
        }

        [Given(@"I sign in")]
        public void GivenISignIn()
        {
            var user = ScenarioContext.Current.Get<User>(TestConstants.User);
            this.headerPageObject.SignIn(user);
        }

        [When(@"go to a particular event and add a product to my cart")]
        public void WhenGoToAParticularEventAndAddAProductToMyCart()
        {
            this.landingPagePageObect.GoToEvent(1);
            this.eventPageObject.GoToProductPageForThatProduct();
            this.productPageObject.ProceedToCart();
        }

        [When(@"proceed to buy an item using (.*)")]
        public void WhenProceedToBuyAnItem(string paymentMethod)
        {
            this.cartPageObject.ProceedToCheckout();
            this.checkoutPageObject.PlaceOrder(paymentMethod);
            this.checkoutReviewPageObject.ConfirmOrder();
        }

        [Then(@"the user is able to procced to the payment page with paymentType (.*)")]
        public void WhenThatTheUserIsAbleToProccedToThePaymentPageWithPaymentType(string paymentName)
        {
            var paymentType = GetPaymentEnum(paymentName);
            ScenarioContext.Current.Add(TestConstants.PaymentType, paymentType);

            switch (paymentType)
            {
                case PaymentType.Express:
                    break;
                case PaymentType.PayPal:
                    Assert.That(this.paymentDetailsPageObject.GetPaymentPageDiscription(PaymentType.PayPal).ToLower(), Is.EqualTo("PayPal Checkout".ToLower()), "The correct payment page should be displayed based on the payment selected");
                    break;
                case PaymentType.Card:
                    Assert.That(this.paymentDetailsPageObject.GetPaymentPageDiscription(PaymentType.Card).ToLower(), Is.EqualTo("Credit Card Details".ToLower()), "The correct payment page should be displayed based on the payment selected");
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
                    Assert.That(this.paymentDetailsPageObject.GetPaymentPageDiscription(PaymentType.Union).ToLower(), Is.EqualTo("PayPal Checkout".ToLower()), "The correct payment page should be displayed based on the payment selected");
                    break;
                case PaymentType.AliPay:
                    Assert.That(this.paymentDetailsPageObject.GetPaymentPageDiscription(PaymentType.AliPay).ToLower(), Is.EqualTo("PayPal Checkout".ToLower()), "The correct payment page should be displayed based on the payment selected");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static PaymentType GetPaymentEnum(string paymentType)
        {
            return (PaymentType)Enum.Parse(typeof(PaymentType), paymentType, true);
        }
    }
}
