using HR.Application.Extensions;
using HR.Domain.Entities;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class AddCompanyDTO
    {
        public Guid CompanyID { get; set; } = Guid.NewGuid();
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; } //vergi numarası
        public string MersisNo { get; set; }
        public string TaxAdministration { get; set; } //vergi dairesi
        public DateTime CompanyFounded { get; set; } 
        public DateTime? DealStartDate { get; set; } = DateTime.Now;
        public DateTime? DealEndDate { get; set; }
        public int NumberOfEmployees { get; set; }
        public string CompanyPhone { get; set; }
        public string EmailAddress { get; set; }
        public Sector Sector { get; set; }
        public CompanyTitle CompanyTitle { get; set; }
        public string? Logo { get; set; }
        [PictureFileExtension]
        public IFormFile LogoFile { get; set; } //dto kalcak
        public Status Status { get; set; } = Status.Active;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
