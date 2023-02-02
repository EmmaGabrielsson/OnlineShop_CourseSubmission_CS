using System.Net.Security;
using OnlineShop_CourseSubmission_CS;
using OnlineShop_CourseSubmission_CS.Component;
using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace UnitTests
{
    public class ShoppingCartTest
    {

        [Fact]
        public async void TestAdd()
        {
            ShoppingCart.Empty();
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
        public async void UpdateCart()
        {
            ShoppingCart.Empty();
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
            CartItem item1 = new CartItem()
            {
                CartId = 1,
                Product = prod1,
                Quantity = 1,
            };
            CartItem item2 = new CartItem()
            {
                CartId = 2,
                Product = prod2,
                Quantity = 1,
            };
            ShoppingCart.CartList = new List<CartItem>() { item1, item2 };

            await ShoppingCart.AddToCart(1);
            Assert.Equal(300, ShoppingCart.TotalExShipping);
            Assert.Equal(305, ShoppingCart.TotalPrice);
            Assert.Equal(3, ShoppingCart.TotalQuantity);

        }
        
        [Fact]
        public void DeleteProduct()
        {
            ShoppingCart.Empty();
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
            CartItem item1 = new CartItem()
            {
                CartId = 1,
                Product = prod1,
                Quantity = 1,
            };
            CartItem item2 = new CartItem()
            {
                CartId = 2,
                Product = prod2,
                Quantity = 1,
            };
            ShoppingCart.CartList = new List<CartItem>() { item1, item2 };

            ShoppingCart.Delete(1);

            Assert.Single(ShoppingCart.CartList);
            Assert.Equal(1, ShoppingCart.TotalQuantity);
            Assert.Equal(100, ShoppingCart.TotalExShipping);
            Assert.Equal(105, ShoppingCart.TotalPrice);
        }
    }
}