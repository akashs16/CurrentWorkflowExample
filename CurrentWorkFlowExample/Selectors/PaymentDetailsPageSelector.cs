namespace CurrentWorkFlowExample.Selectors
{
    public static class PaymentDetailsPageSelector
    {
        public static string CardNumberTextFieldId => "cardnumber";

        public static string CardCancelButtonId => "cancel-button";

        public static string CardDetailsPageCss => "#checkout-form > fieldset > div.new > div.subheader";

        public static string PayPalDetailsPageCss => "#paypalLogo > span";

        public static string PayPalCancelLinkId => "cancelLink";

        public static string UnionPayDetailsCss => "";

        public static string AliPayDetailsClass => "alipay-logo";

        public static string UnionPayCancelLinkId { get; set; }

        public static string AliPayCancelLinkId { get; set; }
    }
}