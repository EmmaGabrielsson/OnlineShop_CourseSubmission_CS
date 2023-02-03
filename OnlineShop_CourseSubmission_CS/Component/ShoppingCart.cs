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

		public static async Task AddToCart(int productId)
		{
			DataService data = new DataService();
			Products[] allProd = await data.GetAllProducts();
			Products? product = allProd.FirstOrDefault(x => x.Id == productId);
			if (product == null)
			{
				return;
			}
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
			UpdateCart();
        }
		public static void UpdateCart()
		{
			decimal totalPrice = 0;
			decimal totalExShipping = 0;
			int totalQuantity = 0;
            foreach (CartItem Item in ShoppingCart.CartList)
            {
                totalExShipping += Item.Quantity * Item.Product.Price;
				totalPrice = totalExShipping + 5;
				totalQuantity += Item.Quantity;
            }
			TotalPrice = totalPrice;
			TotalExShipping = totalExShipping;
			TotalQuantity = totalQuantity;
        }

		public static void UpdateCart(Products prod, int newQuantity)
		{
			Console.WriteLine(newQuantity);
            CartItem? item = CartList.FirstOrDefault(cartItem => cartItem.Product.Id == prod.Id);
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
        public static void Delete(int productId)
		{
			CartItem? item = CartList.FirstOrDefault(x => x.Product.Id == productId);
			if (item != null)
			{
				CartList.Remove(item);
				UpdateCart();
			}
		}
		public static void Empty()
		{
			CartList = new List<CartItem>();
		}
	}
}