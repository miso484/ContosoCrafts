using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoCrafts.WebApp.Services
{
	// Add this service in Startup.cs under ConfigureServices function
	public class JsonFileProductService
	{
		// IWebHostEnvironment provides information about the web hosting environment an application is running in
		public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment { get; }

		// Path to product.json file
		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
		}

		// Get list of product objects that are deserialized from json file
		public IEnumerable<Product> GetProducts()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				// Convert json text into the objects
				return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
								new JsonSerializerOptions
								{
									PropertyNameCaseInsensitive = true
								});
			}
		}

		public void AddRating(string productId, int rating)
		{
			var products = GetProducts();

			//LINQ
			var query = products.First(x => x.Id == productId);

			if (query.Ratings == null)
			{
				query.Ratings = new int[] { rating };
			}
			else
			{
				var ratings = query.Ratings.ToList();
				ratings.Add(rating);
				query.Ratings = ratings.ToArray();
			}

			using (var outputStream = File.OpenWrite(JsonFileName))
			{
				JsonSerializer.Serialize<IEnumerable<Product>>(
					new Utf8JsonWriter(outputStream, new JsonWriterOptions
					{
						SkipValidation = true,
						Indented = true
					}),
					products
				);
			}

		}
	}
}
