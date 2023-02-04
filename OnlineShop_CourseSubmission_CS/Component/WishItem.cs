using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace OnlineShop_CourseSubmission_CS.Component
{
	public class WishItem
	{
		//create wishlist as static variable to store the data
		public static List<Products> WishList = new();

		//function add product to wish
		public static async void AddToWish(int productId)
		{
			DataService data = new DataService();
			Products[] allProd = await data.GetAllProducts();
			Products? product = allProd.FirstOrDefault(x => x.Id == productId);

			Products? prodWish=WishList.Find(x=>x.Id==productId);
			if (prodWish != null)
			{
				return;
			}
			else
			{
				if(product!= null) 
				{ 
					Products addedWish = product;
					WishList.Add(addedWish);
				}
				
			}
		}

		//function remove product from wish
        public static void Remove(int productId)
        {
            Products? product = WishList.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                WishList.Remove(product);
            }
        }
    }
}
