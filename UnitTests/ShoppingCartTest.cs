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

            //test add prod1 to shoppingcart
            await ShoppingCart.AddToCart(1);
            //check only one product is in shoppingcart
            Assert.Single(ShoppingCart.CartList);
            //add prod1 again
            await ShoppingCart.AddToCart(1);
			//check only one product is in shoppingcart
			Assert.Single(ShoppingCart.CartList);
            //check if prod1 is in shoppingcart
            CartItem? cartItem = ShoppingCart.CartList.FirstOrDefault((item) =>
            {
                if (item.Product != null)
                {
                    return item.Product.Id == 1;
                }else 
                    return false;

            });
            Assert.NotNull(cartItem);
            //check prod1's quantity =2
            Assert.Equal(2, cartItem.Quantity);
			
            //test add prod3 to shoppingcart
			await ShoppingCart.AddToCart(3);
            Assert.Single(ShoppingCart.CartList);
            //try to find if prod3 exist, if not exist, retrun false, there is no prod3 in cartItemList
            CartItem? cartItem3 = ShoppingCart.CartList.FirstOrDefault((item) =>
            {
                if (item.Product != null)
                {
                    return item.Product.Id == 3;
                }else
                    return false;
            });

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
            //add prod1 to cart
            await ShoppingCart.AddToCart(1);
            //prod1 is already in list, quantity of prod1++, prod2 quantit1, total quantity=3, total price=305, total price exclude shipping=300
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
            //delete prod1
            ShoppingCart.Delete(1);
            //had 2 products in shopping cart, after delete, only one product in shopping cart. total quantity=1,totalExshipping=100.totoal pris=105
            Assert.Single(ShoppingCart.CartList);
            Assert.Equal(1, ShoppingCart.TotalQuantity);
            Assert.Equal(100, ShoppingCart.TotalExShipping);
            Assert.Equal(105, ShoppingCart.TotalPrice);
        }
    }
}