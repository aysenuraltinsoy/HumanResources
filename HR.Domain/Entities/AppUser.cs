using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Domain.Entities
{
    public class AppUser: IdentityUser<Guid>, IBaseEntity
    {

        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public decimal Salary { get; set; }
        public Status Status { get; set; } = Status.Active; 
        [NotMapped]
        public IFormFile UploadPath { get; set; }//--
        public string? ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }//--
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Sector Sector { get; set; }//--
        public Department Department { get; set; }//--
        //bireçoğun çok tarafı
        public List<AppUserAdvance> AppUserAdvances { get; set; }
        public Guid? CompanyId { get; set; }
        public virtual AppCompany Company { get; set; }

      


    }
}
