using System.Reflection.Metadata.Ecma335;
using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace OnlineShop_CourseSubmission_CS.Component
{
	public static class ShoppingCart
	{
		public static List<CartItem> CartList = new();
		public static decimal TotalPrice = 0;
		public static int TotalQuantity = 0;
		public static decimal TotalExShipping = 0;
		
		//function of add products to shopping cart
		public static async Task AddToCart(int productId)
		{
			DataService data = new DataService();
			Products[] allProd = await data.GetAllProducts();
			Products? product = allProd.FirstOrDefault(x => x.Id == productId);
			if (product == null)
			{
				return;
			}

			//check if shoppingcart already has the product that is clicked
			CartItem? foundCartItem = CartList.Find((cartItem) =>
			{
				if (cartItem.Product != null)
				{
					return
					cartItem.Product.Id == productId;
				} else 
					return false;	
			});

			//if the product is not in shopping cart, push the product to cartItem; if exist, only change the quantity of the product. Then update the shoppingcart
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
			UpdateCart();
        }

		//function of updateshopping cart for the total price, total quantity
		public static void UpdateCart()
		{
			decimal totalPrice = 0;
			decimal totalExShipping = 0;
			int totalQuantity = 0;

            foreach (CartItem Item in ShoppingCart.CartList)
            {
				if (Item.Product != null) 
				{ 
					totalExShipping += Item.Quantity * Item.Product.Price;
					totalPrice = totalExShipping + 5;
					totalQuantity += Item.Quantity;
                }
            }
			TotalPrice = totalPrice;
			TotalExShipping = totalExShipping;
			TotalQuantity = totalQuantity;
        }

		//function of when input of quantity changes, update shoppingcart.
		public static void UpdateCart(Products prod, int newQuantity)
		{
            CartItem? item = CartList.FirstOrDefault((cartItem) =>
            {
                if (cartItem.Product != null)
                {
                    return
                    cartItem.Product.Id == prod.Id;
                }
                else
					return false;
                
            });
            if (item == null)
			{
				item = new CartItem()
				{
					UserId = 1,
					CartId = 1,
					Product = prod,
					Quantity = newQuantity
				};
				CartList.Add(item);
			}
			else
			{
				item.Quantity = newQuantity;
			}
			UpdateCart();
        }

		//function of delete products
        public static void Delete(int productId)
		{
			//try to find the aimed product
			CartItem? item = CartList.FirstOrDefault((cartItem) =>
            {
                if (cartItem.Product != null)
                {
                    return
                    cartItem.Product.Id == productId;
                }
                else
					return false;
                
            });
			//if found, delete it. and update cart
            if (item != null)
			{
				CartList.Remove(item);
				UpdateCart();
			}
		}
		
		//create new list with empty for test purpose 
		public static void Empty()
		{
			CartList = new List<CartItem>();
		}
	}
}