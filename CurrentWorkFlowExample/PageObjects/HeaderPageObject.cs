namespace CurrentWorkFlowExample.PageObjects
{
    using DataObjects;
    using Enums;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selectors;

    public class HeaderPageObject : BasePageobject
    {
        public HeaderPageObject(DriverType driverName) : base(driverName)
        {
        }

        public HeaderPageObject(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void SignIn(User user)
        {
            this.Driver.FindElement(By.Id(HeaderSelector.SignInLinkId)).Click();
            this.Wait.Until(driver => driver.FindElement(By.ClassName(SignInOverLaySelector.SignInOverLayClass)).Displayed && driver.FindElement(By.ClassName(SignInOverLaySelector.SignInOverLayClass)).Enabled);

            this.Driver.FindElement(By.Id(SignInOverLaySelector.EmailAddressTextFieldId)).SendKeys(user.EmailAddress);
            this.Driver.FindElement(By.Id(SignInOverLaySelector.PasswordTextFieldId)).SendKeys(user.Password);

            this.Driver.FindElement(By.Id(SignInOverLaySelector.SignInWithEmailButtonId)).Click();
            this.Wait.Until(driver => driver.FindElement(By.Id(HeaderSelector.DisplayUserNameComponentId)).Displayed && driver.FindElement(By.Id(HeaderSelector.DisplayUserNameComponentId)).Enabled);
        }
    }
}