using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Data;

namespace OnlineShop_CourseSubmission_CS.Component
{
	public class WishItem
	{
		public static List<Products> WishList = new();
		public static async void AddToWish(int productId)
		{
			DataService data = new DataService();
			Products[] allProd = await data.GetAllProducts();
			Products? product = allProd.FirstOrDefault(x => x.Id == productId);

			Products prodWish=WishList.Find(x=>x.Id==productId);
			if (prodWish != null)
			{
				return;
			}
			else
			{
				Products addedWish = product;
				WishList.Add(addedWish);
			}
		}
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
