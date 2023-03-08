using FluentValidation;
using HR.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HR.Application.Validators
{
    public class TakeNewPasswordValidator : AbstractValidator<TakeNewPasswordDTO>
    {
        public TakeNewPasswordValidator()
        {
            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password is required.")
             .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
             .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
             .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
             .Matches(x => x.ConfirmPassword).WithMessage("Password and Confirm Password do not match.");

        }
    }
}
