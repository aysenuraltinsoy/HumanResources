using FluentValidation;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Validators
{
    public class AdvanceValidator : AbstractValidator<RequestAdvanceDTO>
    {
   
        public AdvanceValidator()
        {
           
            When(x => x.AdvanceType == AdvanceType.IndividualDemand, () =>
            {
                RuleFor(x => x.Amount)
                .NotEmpty()
                .WithName("Amount")
                .WithMessage("Please enter an amount")
                .GreaterThanOrEqualTo(500) // Son bir yılda max 3 maaş
                .WithName("Amount")
                .WithMessage("Your advance demand can not be less than 500 TL");

            });
            When(x => x.AdvanceType == AdvanceType.CorporateDemand, () =>
            {
                RuleFor(x => x.Amount)
                .NotEmpty()
                .WithName("Amount")
                .WithMessage("Please enter an amount")
                .GreaterThanOrEqualTo(x => 1000)
                .WithName("Amount")
                .WithMessage("Your advance demand can not be less than 1000 TL")
                .LessThanOrEqualTo(x => 250000)// 
                .WithName("Amount")
                .WithMessage("Your advance demand can not be greater than 250000 TL");

            });
            RuleFor(x => x.Description)
                .MinimumLength(25)
                .WithMessage("Please Enter at least 25 letters")
                .MaximumLength(250)
                .WithName("Description")
                .WithMessage("{Description} Enter at least 250 letters.");
          
        }


    }   
    
}
