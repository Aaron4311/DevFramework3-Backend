using DevFramework.Northwind.Business.Concrete;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;

namespace DevFramework.Northwind.Business.Tests
{
	[TestClass]

	public class ProductManagerTests
	{
		[TestMethod]
		[ExpectedException(typeof(ValidationTestException))]

		public void Product_validation_check()
		{
			var validator = new ProductValidator();
			var product = new Product()
			{
				ProductName = "s",
				CategoryId = 1,
				UnitsInStock = 0,
				UnitPrice = 0
			};
			var result = validator.TestValidate(product);
			result.ShouldHaveValidationErrorFor(x => new
			{
				x.ProductName,
				x.UnitPrice
			});



		}
	}
}