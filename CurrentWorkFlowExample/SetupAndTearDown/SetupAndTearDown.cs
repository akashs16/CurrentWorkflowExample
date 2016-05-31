namespace CurrentWorkFlowExample.SetupAndTearDown
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using DataObjects;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class SetupAndTearDown
    {
        [BeforeScenario("prodSgUser")]
        public static void ProdSgUser()
        {
            var user = new User()
            {
                FirstName = "Reebonz",
                LastName = "Tester",
                EmailAddress = "tester@reebonz.com",
                Password = "P@ssword@123",
                Country = "Singapore",
                Gender = "Male"
            };

            ScenarioContext.Current.Add(TestConstants.User, user);
        }

        [BeforeScenario("prodCnUser")]
        public static void ProdCnUser()
        {
            var user = new User()
            {
                FirstName = "TesterCn",
                LastName = "Reebonz",
                EmailAddress = "testercn@reebonz.com",
                Password = "P@ssword@123",
                Country = "China",
                Gender = "Female"
            };

            ScenarioContext.Current.Add(TestConstants.User, user);
        }

        [AfterScenario("cancelItemCheckoutFromPaymentDetailsPage")]
        public static void CancelItemCheckoutFromPaymentDetailsPage()
        {
            try
            {
                var driver = ScenarioContext.Current.Get<IWebDriver>(TestConstants.Driver);
                var wait = ScenarioContext.Current.Get<WebDriverWait>(TestConstants.Wait);

                var paymentType = ScenarioContext.Current.Get<PaymentType>(TestConstants.PaymentType);
                var paymentDetailsPage = new PaymentDetailsPageObject(driver, wait);

                paymentDetailsPage.CancelOrder(paymentType);

                var cartPageObject = new CartPageObject(driver, wait);

                cartPageObject.CleanUpCart();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("clean up failed one or the other key wasn't found/set");
            }
        }

        [AfterTestRun]
        public static void KillDriver()
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>(TestConstants.Driver);
            driver.Quit();
        }
    }
}