using OnlineShop_CourseSubmission_CS.Components;
using OnlineShop_CourseSubmission_CS.Pages;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineShop_CourseSubmission_CS.Data
{
    public class Data
    {
     
        public async Task<Products[]> GetAllProducts()
        {
            
            HttpClient client = new();

            try
            {
                using HttpResponseMessage response = await client.GetAsync("https://fakestoreapi.com/products");
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
               
                Products[] productList = JsonSerializer.Deserialize<Products[]>(responseBody)!;
                return productList;
       
            }
            catch
            {
                throw;
            }
        }
    }
}
