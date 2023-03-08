using HR.Domain.Entities;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
    public class ListOfManagerVM
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }//+
        public string Name { get; set; }//+
        public string Surname { get; set; }//+
        public string Email { get; set; }//+
        public string? ImagePath { get; set; }//+
        public long PhoneNumber { get; set; }//
        public bool IsActive { get; set; }//++
        public Sector Sector { get; set; }//+
        public Department Department { get; set; }//--
        public Guid CompanyID { get; set; }
        public AppCompany Company { get; set; }
         
    }
}
