using FluentValidation;
using HR.Application.Models.DTOs;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Validators
{
    public class UpdatePersonnelValidator : AbstractValidator<UpdateProfileDTO>
    {
        public UpdatePersonnelValidator()
        {

            RuleFor(x => x.Address)
               .MaximumLength(250)
               .MinimumLength(25)
               .WithMessage("The address must be a min.25-max. 255 characters.");
            RuleFor(x => x.PhoneNumber).LessThan(10000000000).GreaterThan(1000000000).WithMessage("Enter 10 digit number");
           
        }
    }
}
