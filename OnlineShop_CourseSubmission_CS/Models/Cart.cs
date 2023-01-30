namespace OnlineShop_CourseSubmission_CS.Components
{
    public class Cart
    {
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public CartItem[] CartItem { get; set; }
    }
}
