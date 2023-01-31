namespace OnlineShop_CourseSubmission_CS.Components
{
    public class Cart
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public CartItem[] CartItem { get; set; }
    }
}
