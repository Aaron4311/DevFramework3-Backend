using DevFramework.Core.Utilities.Results;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
	public interface IProductService
	{
		IDataResult<List<Product>> GetAll();
		IDataResult<Product> Get(int id);
		IResult Add(Product product);
		IResult Update(Product product);
		IResult Delete(int id);
		//IDataResult<List<ProductDetailDto>> GetProductDetails();
		IResult TransactionalOperation(Product product);
	}
}
