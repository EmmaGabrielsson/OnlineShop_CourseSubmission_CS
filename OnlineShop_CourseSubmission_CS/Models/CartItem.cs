namespace OnlineShop_CourseSubmission_CS.Components
{
    public class CartItem
    {
        public int UserId { get; set; } 
        public int CartId { get; set; }
        public Products? Product { get; set; }
        public int Quantity { get; set; }
    }
}
