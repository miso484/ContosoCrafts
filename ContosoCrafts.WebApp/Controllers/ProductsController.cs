using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebApp.Services;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		public ProductsController(JsonFileProductService productService)
		{
			this.ProductService = productService;
		}
		
		public JsonFileProductService ProductService { get;  }

		[HttpGet]
		public IEnumerable<Product> Get()
		{
			return ProductService.GetProducts();
		}

		//[HttpPatch]  "[FromBody]"
		//localhost:44300/products/rate?ProductId=jenlooper-cactus&rating=5
		[Route("Rate")]
		[HttpGet]
		public ActionResult Patch([FromQuery] RatingRequest request)
		{
			ProductService.AddRating(request.ProductId, request.Rating);
			return Ok();
		}

		public class RatingRequest
		{
			public string ProductId { get; set; }
			public int Rating { get; set; }
		}
    }
}