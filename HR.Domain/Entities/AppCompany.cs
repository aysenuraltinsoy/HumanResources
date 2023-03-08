using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR.Domain.Entities
{
    public class AppCompany : IBaseEntity
    {
        public Guid AppCompanyID { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string TaxNo { get; set; } //vergi numarası
        public string MersisNo { get; set; }
        public string TaxAdministration { get; set; } //vergi dairesi
        public DateTime CompanyFounded { get; set; }
        public DateTime? DealStartDate { get; set; }
        public DateTime? DealEndDate { get; set; }
        public int NumberOfEmployees { get; set; }
        public string CompanyPhone { get; set; }
        public string EmailAddress { get; set; }
        public Sector Sector { get; set; }
        public CompanyTitle CompanyTitle { get; set; }
        public string? Logo { get; set; }
        public ICollection<AppUser> Personnels { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
