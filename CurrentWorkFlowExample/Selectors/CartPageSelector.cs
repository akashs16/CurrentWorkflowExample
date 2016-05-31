namespace CurrentWorkFlowExample.Selectors
{
    public static class CartPageSelector
    {
        public static string CheckoutButton => "edit-submit";
        public static string CartPageClass => "reebonzCart";
        public static string ProductsInCartCss => "#reebonz-cart-form > div > div > div > div.cartContent > div > div.col-sm-7 > div > div";
        public static string RemoveProductButtonCss => "div[class$=itemInfoWrapper] > div.row.rowItem > div:nth-child(2) > a";
    }
}