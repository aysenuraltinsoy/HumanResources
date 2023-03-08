using HR.Application.Extensions;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class UpdateCompanyDTO
    {
        public Guid AppCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }

        [PictureFileExtension]
        public IFormFile LogoFile { get; set; } //dto kalcak
        //public string? Logo { get; set; }
        public CompanyTitle CompanyTitle { get; set; }


    }
}
