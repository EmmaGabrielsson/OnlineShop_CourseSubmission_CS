using System.Text.Json.Serialization;

namespace OnlineShop_CourseSubmission_CS.Components
{
	public class Rating
	{
		[JsonPropertyName("rate")]
		public double Rate { get; set; }
		[JsonPropertyName("count")]
		public int Count { get; set; }
	}
}
