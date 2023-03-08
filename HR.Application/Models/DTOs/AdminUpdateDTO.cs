using HR.Application.Extensions;
using HR.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Models.DTOs
{
    public class AdminUpdateDTO
    {
        public Guid Id { get; set; }
        [PictureFileExtension]
        public IFormFile? UploadPath { get; set; }
        public string? ImagePath { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? Department { get; set; }
     

    }
}
