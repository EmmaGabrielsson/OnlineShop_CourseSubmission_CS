namespace OnlineShop_CourseSubmission_CS.Data
{
    public class Products
    {
        public Products(int id, string title, decimal price, string description, Category category, string categoryName, string name, object rating)
        {
            this.id = id;
            this.title = title;
            this.price = price;
            this.description = description;
            this.category = category;
            this.categoryName = categoryName;
            this.rating = rating;

        }
        public int id { get; set; }
        public string title { get; set; }

        public decimal price { get; set; }
        public string description { get; set; }
        public Category category { get; set; }
        public string categoryName { get; set; }
        public string image { get; set; }
        public object rating { get; set; }
    }

}