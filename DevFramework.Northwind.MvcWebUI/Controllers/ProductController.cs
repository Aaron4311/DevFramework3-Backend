using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
	public class ProductController : Controller
	{
		private IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var model = new ProductListViewModel
			{
				Products = _productService.GetAll().Data
			};
			return View(model);
		}
	}
}
