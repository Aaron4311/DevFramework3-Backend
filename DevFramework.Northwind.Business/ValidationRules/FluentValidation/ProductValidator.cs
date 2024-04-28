using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class ProductValidator : AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x => x.ProductId).NotNull();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty().GreaterThan(2);

        }
    }
}
