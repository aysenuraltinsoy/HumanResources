using HR.Domain.Entities;
using HR.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.VMs
{
	public class ListOfPersonnelVM
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
