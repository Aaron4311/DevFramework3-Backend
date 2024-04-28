using DevFramework.Core.Utilities.Results;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
	public interface ICategoryService
	{

		IDataResult<List<Category>> GetAll();
		IDataResult<Category> Get(int id);
		IResult Add(Category category);
		IResult Delete(int id);
		IResult Update(Category category);

	}
}
