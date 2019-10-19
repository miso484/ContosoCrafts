﻿using System;
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
    }
}