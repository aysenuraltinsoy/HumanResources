using FluentValidation;
using HR.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Validators
{
	public class LoginValidator:AbstractValidator<LoginDTO>
	{
		public LoginValidator()
		{
			RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Please enter e-mail");
			RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Please enter password");
		}
	}
}
