using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Context;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
	{
		public List<ProductDetailDto> GetProductDetails()
		{
			using (NorthwindContext context = new NorthwindContext())
			{
				var query = from p in context.Products
							join c in context.Categories
							on p.CategoryId equals c.CategoryId
							select new ProductDetailDto
							{
								ProductName = p.ProductName,
								CategoryName = c.CategoryName,
								CategoryId = c.CategoryId,
								ProductId = p.ProductId
							};
				return query.ToList();

		}
	}
}
}
