using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
    public class DetailCompanyVM
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
       
    }
}
