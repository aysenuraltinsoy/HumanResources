using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.AutoMapper
{
    public class Mapping: Profile
    {
        public Mapping()
        {  
            CreateMap<AppUser, ResetPasswordDTO>().ReverseMap();
            CreateMap<AppUser, AdminUpdateDTO>().ReverseMap();
            CreateMap<AppUser, AddUserDTO>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();
            CreateMap<AppUser, UserVM>().ReverseMap();
            CreateMap<AppUser, UserDetailsVM>().ReverseMap();
            CreateMap<AppUser, AddManagerDTO>().ReverseMap();
            CreateMap<AppUser, ListOfManagerVM>().ReverseMap();
            CreateMap<AppUser, AddPersonnelDTO>().ReverseMap();
            CreateMap<AppUser, ListOfPersonnelVM>().ReverseMap();
            CreateMap<AppUser, UpdateManagerDTO>().ReverseMap();
            CreateMap<AppUserAdvance, RequestAdvanceDTO>().ReverseMap();
            CreateMap<AppUserAdvance, UserAdvanceListVM>().ReverseMap();
            CreateMap<AppCompany, ListOfCompanyVM>().ReverseMap();
            CreateMap<AppCompany, AddCompanyDTO>().ReverseMap();
            CreateMap<AppCompany, DetailCompanyVM>().ReverseMap();
            CreateMap<AppCompany, UpdateCompanyDTO>().ReverseMap();
            
        

        }
    }
}
