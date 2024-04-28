using DevFramework.Core.Utilities.Results;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Constants;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public IResult Add(Category category)
		{
			_categoryDal.Add(category);
			return new SuccessResult(Messages.CategoryAdded);
		}

		public IResult Delete(int id)
		{
			var deletedCategory = _categoryDal.Get(x => x.CategoryId == id);
			_categoryDal.Delete(deletedCategory);
			return new SuccessResult(Messages.CategoryDeleted);
		}

		public IDataResult<Category> Get(int id)
		{
			return new SuccessDataResult<Category>(_categoryDal.Get(x => x.CategoryId == id), Messages.CategoryListed);
		}

		public IDataResult<List<Category>> GetAll()
		{
			return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);

		}

		public IResult Update(Category category)
		{
			_categoryDal.Update(category);
			return new SuccessResult(Messages.CategoryUpdated);
		}
	}
}
