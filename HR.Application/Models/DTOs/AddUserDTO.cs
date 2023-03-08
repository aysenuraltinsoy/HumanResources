using HR.Application.Extensions;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class AddUserDTO
    {
        public Guid Id => Guid.NewGuid();

        [Required(ErrorMessage = "Cannot be Empty")]
        [MaxLength(25, ErrorMessage = "You Cannot Enter More Than 25 Characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cannot be Empty")]
        [MaxLength(25, ErrorMessage = "You Cannot Enter More Than 25 Characters")]
        public string? SecondName { get; set; }
        [Required(ErrorMessage = "Cannot be Empty")]
        [MaxLength(50, ErrorMessage = "You Cannot Enter More Than 25 Characters")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Cannot be Empty")]
        [MaxLength(50, ErrorMessage = "You Cannot Enter More Than 25 Characters")]
        public string? SecondSurname { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;
       
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PlaceOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string? ImagePath { get; set; }
        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public void EmailCreate(string name, string surname)
        {
            string email = name + "." + surname + "@bilgeadamboost.com";
        }
    }
}
