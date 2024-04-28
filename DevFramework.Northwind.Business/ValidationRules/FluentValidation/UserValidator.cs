using DevFramework.Core.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Inappropriate for an email adress");
			RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter  yazın");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen soyadınızı yazın");
		
		}
    }
}
