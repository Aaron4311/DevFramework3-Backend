using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFramework.Northwind.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getallproducts")]
		public IActionResult GetAllProducts()
		{
			var result = _productService.GetAll();
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}
		[HttpGet("getproduct")]
		public IActionResult GetProduct(int id)
		{
			var result = _productService.Get(id);
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}
		[HttpPost("add")]
		public IActionResult Add(Product product)
		{
			var result = _productService.Add(product);
			if (result.Success)
			{
				return Ok(result.Message);
			}
			return BadRequest(result.Message);
		}
		[HttpPost("update")]
		public IActionResult Update(Product product)
		{
			var result = _productService.Update(product);
			if (result.Success)
			{
				return Ok(result.Message);
			}
			return BadRequest(result.Message);
		}
		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _productService.Delete(id);
			if (result.Success)
			{
				return Ok(result.Message);
			}
			return BadRequest(result.Message);
		}

	}
}
