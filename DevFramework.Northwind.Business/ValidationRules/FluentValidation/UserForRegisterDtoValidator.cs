using DevFramework.Northwind.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
	{
        public UserForRegisterDtoValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Inappropriate for an email adress").NotNull().WithMessage("Email adress is required");
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).WithMessage("Your name should be longer than 2 characters.");
            RuleFor(x => x.LastName).NotNull().MinimumLength(2).WithMessage("Your lastname should be longer than 2 characters.");
		}
    }
}
