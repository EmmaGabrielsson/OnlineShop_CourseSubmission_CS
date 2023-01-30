using OnlineShop_CourseSubmission_CS;
using OnlineShop_CourseSubmission_CS.Component;
using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace UnitTests
{
    public class UnitTest1
    {

        [Fact]
        public async void TestAdd()
        {

            Products prod1 = new Products()
            {
                Id = 1,
                Category = "new cata",
                Price = 100,
                Title = "Prod 1",
                Description = "",
                Image = ""
            };

            Products prod2 = new Products()
            {
                Id = 2,
                Category = "new cata",
                Price = 100,
                Title = "Prod 2",
                Description = "",
                Image = ""
            };

            DataStorage.ProductList= new Products[] { prod1,prod2 };


            await ShoppingCart.AddToCart(1);
            Assert.Single(ShoppingCart.CartList);
            await ShoppingCart.AddToCart(1);
            Assert.Single(ShoppingCart.CartList);

            CartItem? cartItem = ShoppingCart.CartList.FirstOrDefault(x => x.Product.Id == 1);
            Assert.NotNull(cartItem);
            Assert.Equal(2, cartItem.Quantity);

            await ShoppingCart.AddToCart(3);
            Assert.Single(ShoppingCart.CartList);

            CartItem? cartItem3 = ShoppingCart.CartList.FirstOrDefault(y => y.Product.Id == 3);
            Assert.Null(cartItem3);

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