namespace CurrentWorkFlowExample.Selectors
{
    public static class CheckoutPageSelector
    {
        public static string CheckoutPageClass => "reebonzCheckout";
        public static string PaymentMethodsCss => "#edit-payment-box > div > ul > li";
        public static string AgreeToTermsAndConditionsCheckboxId => "edit-return";
        public static string PlaceOrderButtonId => "edit-place-order";
        public static string ShippingAddressCheckboxId => "shipping0";
        public static string BillingAddressCheckboxId => "billing0";
    }
}