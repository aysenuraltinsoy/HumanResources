using AutoMapper.Execution;
using FluentValidation;
using HR.Application.Models.DTOs;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Application.Validators
{
    public class CompanyValidation : AbstractValidator<AddCompanyDTO>
    {
        public CompanyValidation()
        {
            RuleFor(x => x.CompanyName)
           .NotEmpty()
           .WithMessage("Please enter Company Name")
           .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
           .WithMessage("Please enter at least one letter");


            RuleFor(x => x.TaxAdministration)
           .NotEmpty()
           .WithMessage("Please enter Tax Administration")
           .Matches(new Regex("^[a-zA-ZwığüşöçİĞÜŞÖÇ\\s]+$"))
           .WithMessage("Please enter letters only");

            RuleFor(x => x.TaxNo)
            .NotEmpty()
            .WithMessage("Please enter Tax No")
            .Matches(new Regex(@"^[0-9]*$"))
            .WithMessage("Please enter numbers only.")
            .Length(10)
            .WithMessage("Plase Enter 10 digit numbers");

            RuleFor(x => x.MersisNo)
            .NotEmpty()
            .WithMessage("Please enter MersisNo")
            .Matches(new Regex(@"^[0-9]*$"))
            .WithMessage("Please enter numbers only.")
            .Length(16).WithMessage("Plase Enter 16 digit numbers");

            RuleFor(x => x.CompanyFounded)
            .NotEmpty()
            .WithMessage("Please enter CompanyFounded")
            .GreaterThan(new DateTime(1800, 1, 1));

            RuleFor(x => x.DealStartDate)
                .NotEmpty()
                .WithMessage("Please enter DealStartDate")
                .Must(date => date >= DateTime.Today.AddDays(-7))
                .WithMessage("Starting date must be at least 7 days from today")
                .GreaterThan(x => x.CompanyFounded).WithMessage("The Agreement Start Date must be after the Establishment Date.");
          

            RuleFor(x => x.DealEndDate)
                .NotEmpty()
                .WithMessage("Please enter DealEndDate")
                .GreaterThanOrEqualTo(x => x.DealStartDate)
                .WithMessage("The end date must be after the start date.");

            RuleFor(x => x.Address)
                .MaximumLength(250)
                .MinimumLength(25)
                .WithMessage("The address must be a min.25-max. 255 characters.");

            RuleFor(x => x.NumberOfEmployees)
                .NotEmpty()
                .WithMessage("Please enter Number Of Employees")
                .InclusiveBetween(10, 100000)
                .WithMessage("The number of employees should be in the range of 10, 100000.");

            RuleFor(x => x.CompanyPhone)
                .NotEmpty()
                .WithMessage("Please enter Company Phone")
                .Matches(new Regex(@"^[0-9]*$"))
                .MaximumLength(10)
                .WithMessage("Please enter a valid 10 digit phone number.");


            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Please enter Company Phone")
                .EmailAddress()
                .WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Sector)
                .IsInEnum()
                .WithMessage("Please enter Sector");



        }
    }
}
