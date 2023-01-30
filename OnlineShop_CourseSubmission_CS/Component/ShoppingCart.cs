﻿using System.Security.Cryptography.X509Certificates;
using Blazored.LocalStorage;
using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace OnlineShop_CourseSubmission_CS.Component
{
	public static class ShoppingCart
	{
		public static List<CartItem> CartList = new();

		public static async Task AddToCart(int productId)
		{
			Console.WriteLine("ADDDDDDDDD");
			Console.WriteLine(productId);
			DataService data = new DataService();
			Products[] allProd = await data.GetAllProducts();
			Console.WriteLine(allProd.Length);
			Products product = allProd.FirstOrDefault(x => x.Id == productId);
			Console.WriteLine(product);
			CartItem? foundCartItem = CartList.Find(cartItem => cartItem.Product.Id == productId);
			Console.WriteLine(foundCartItem == null);
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
				Console.WriteLine(foundCartItem.Quantity);
			}
		}
	}
}