using DevFramework.Core.Aspects.Autofac.Caching;
using DevFramework.Core.Aspects.Autofac.Performance;
using DevFramework.Core.Aspects.Autofac.Validation;
using DevFramework.Core.Utilities.Business;
using DevFramework.Core.Utilities.Results;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.BusinessAspects.Autofac;
using DevFramework.Northwind.Business.Constants;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.Entities.Dtos;

namespace DevFramework.Northwind.Business.Concrete
{

	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		[ValidationAspect(typeof(ProductValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		//[SecuredOperation("admin")]
		public IResult Add(Product product)
		{
			IResult result = BusinessRules.Run
				(CheckIfProductNameExists(product.ProductName),
				CheckIfItsMaintenanceHour(DateTime.Now),
				CheckIfCountOfCategoryPerProductIsCorrect(product.CategoryId));
			if (result != null)
			{
				return result;
			}
			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
			
		}
		[SecuredOperation("admin")]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Delete(int id)
		{
			var deletedProduct = _productDal.Get(x => x.ProductId == id);
			_productDal.Delete(deletedProduct);
			return new SuccessResult(Messages.ProductDeleted);
		}

		[CachingAspect]
		[SecuredOperation("admin")]
		public IDataResult<Product> Get(int id)
		{
			return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id), Messages.ProductListed);
		}
		[CachingAspect]
		[PerformanceAspect(2)]
		[SecuredOperation("editor,admin")]
		public IDataResult<List<Product>> GetAll()
		{
			Thread.Sleep(3000);
			return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

		}
		[CachingAspect(10)]
		[SecuredOperation("admin")]
		public IDataResult<List<ProductDetailDto>> GetProductDetails()
		{
			return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductDetailsListed);
		}
		[SecuredOperation("admin")]
		[TransactionAspect]
		public IResult TransactionalOperation(Product product)
		{
			_productDal.Add(product);
			return new SuccessResult(Messages.TransactionCompleted);
		}
		[SecuredOperation("admin")]
		public IResult Update(Product product)
		{
			_productDal.Update(product);
			return new SuccessResult(Messages.ProductUpdated);
		}


		//Business Rules
		private IResult CheckIfProductNameExists(string productName)
		{
			var result = _productDal.GetAll(x => x.ProductName.Equals(productName)).Any();
			if (result)
			{
				return new ErrorResult(Messages.ProductNameAlreadyExists);
			}
			return new SuccessResult();
		}

		private IResult CheckIfItsMaintenanceHour(DateTime hour)
		{
			
			if (MaintenanceHour.maintenanceHour == hour.Hour)
			{
				return new ErrorResult(Messages.MaintenanceHour);
			}
			return new SuccessResult();
		}
		private IResult CheckIfCountOfCategoryPerProductIsCorrect(int categoryId)
		{
			var result = _productDal.GetAll(x => x.CategoryId == categoryId).Count();
			if (result > 15)
			{
				return new ErrorResult(Messages.TooManyProductsForCategory);
			}
			return new SuccessResult();
		}
	}
}
