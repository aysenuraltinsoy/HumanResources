using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
	public class AddPersonnelDTO
	{
		public Guid ID { get; set; } = Guid.NewGuid();
		public string? UserName { get; set; }//+
		public string Name { get; set; }//+
		public string? SecondName { get; set; }//+
		public string Surname { get; set; }//+
		public string? SecondSurname { get; set; }//+
		public Status Status { get; set; } = Status.Active;
		[NotMapped]
		public IFormFile UploadPath { get; set; }//--
		public string? ImagePath { get; set; }//+
		public DateTime BirthDate { get; set; }
		public string PlaceOfBirth { get; set; }//+
		public long PhoneNumber { get; set; }//+
		public string Password { get; set; }//+
        public  decimal Salary { get; set; }
        public string IdentityNumber { get; set; }//+
		public DateTime StartingDate { get; set; }//+
		public string Address { get; set; }//++
		public bool IsActive { get; set; } = true;
		public DateTime CreateDate => DateTime.Now;
		public Sector Sector { get; set; }//+
		public Department Department { get; set; }//++
		public Guid CompanyID { get; set; }
	}
}
