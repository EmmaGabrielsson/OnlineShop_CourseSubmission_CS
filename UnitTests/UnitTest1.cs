using OnlineShop_CourseSubmission_CS;
using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace UnitTests
{
    public class UnitTest1
    {


        public static List<CartItem> CartList = new();

        [Theory]
        [InlineData(112)]
        public static async Task AddToCart(int productId)
            {
                DataService data = new DataService();
                Products[] allProd = await data.GetAllProducts();
                Products product = allProd.FirstOrDefault(x => x.Id == productId);
                CartItem? foundCartItem = CartList.Find(cartItem => cartItem.Product.Id == productId);
                if (foundCartItem == null)
                {
                    CartItem newCartItem = new CartItem()
                    {
                        UserId = 1,
                        CartId = 1,
                        Product = product,
                        Quantity = 1
                    };
                    CartList.Add(newCartItem);
                }
                else
                {
                    foundCartItem.Quantity++;
                }
            }

        [Fact]
        public void UpdateTotalPrice()
        {

        }

        [Fact]
        public void UpdateQuantity()
        {

        }

        [Fact]
        public void DeleteProduct()
        {

        }
    }
}