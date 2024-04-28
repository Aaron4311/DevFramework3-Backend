using DevFramework.Northwind.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
	public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
	{
        public UserForLoginDtoValidator()
        {
			RuleFor(x => x.Email).NotNull().WithMessage("Please enter your email").EmailAddress().WithMessage("Inappropriate for an email adress");
			RuleFor(x => x.Password).NotNull().WithMessage("Please enter your password");

		}
	}
}
