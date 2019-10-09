using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
	public class Product
	{
		public string Id { get; set; }
		public string Maker { get; set; }
		[JsonPropertyName("img")]
		public string Image { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int[] Ratings { get; set; }
		//JsonSerializer provides functionality to serialize objects or value types to JSON and to deserialize JSON into objects or value types
		public override string ToString() => JsonSerializer.Serialize<Product>(this);
		
	}
}
