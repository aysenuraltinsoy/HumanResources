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
    public class ManagerValidator : AbstractValidator<AddManagerDTO>
    {
        public ManagerValidator()
        {
            RuleFor(x => x.Name)
         .NotEmpty()
         .WithMessage("Please enter  Name")
         .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
         .WithMessage("Please enter at least one letter")
         .MinimumLength(2);

            RuleFor(x => x.SecondName)
         .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
         .WithMessage("Please enter at least one letter");


            RuleFor(x => x.Surname)
         .NotEmpty()
         .WithMessage("Please enter Surname")
         .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
         .WithMessage("Please enter at least one letter")
         .MinimumLength(2);

            RuleFor(x => x.SecondSurname)
         .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
         .WithMessage("Please enter at least one letter");


            RuleFor(x => x.Address)
         .NotEmpty()
         .MinimumLength(25)
         .WithMessage("Please Enter at least 25 letters")
         .MaximumLength(255)
         .WithMessage("Please Enter Max 254 letters");


            RuleFor(x => x.IdentityNumber)
         .NotEmpty()
         .WithMessage("Please enter Identity Number")
         .Length(11)
         .WithMessage("Please enter 11 digit Password");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Please enter Birth Date")
                .GreaterThan(new DateTime(1950, 1, 1))
               .WithMessage("Please Enter greater than 1/1/1950")
                .Must(date => date <= DateTime.Today.AddYears(-18))
        .WithMessage("Your age must be greater than 18.");


            RuleFor(x => x.Salary)
        .NotEmpty()
        .WithMessage("Please enter Salary")
        .InclusiveBetween(8500, 45000)
        .WithMessage("Please enter a value in the range of 8500 to 45000");

            RuleFor(x => x.StartingDate)
        .NotEmpty().WithMessage("Please enter Starting Date")//7 gün öncesine kadar kayıt olur
        .Must(date => date >= DateTime.Today.AddYears(-65))
        .WithMessage("Starting date must be at least 65 years from today");

        }
    }
}



