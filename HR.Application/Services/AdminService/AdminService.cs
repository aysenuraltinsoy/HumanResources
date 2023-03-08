using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.Message;
using HR.Application.Models.VMs;
using HR.Application.Services.MailService;
using HR.Domain.Entities;
using HR.Domain.Enum;
using HR.Domain.Repositories;
using HR.Infrastructure.Context;
using HR.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly ICompanyRepo _companyRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        public AdminService(ICompanyRepo companyRepo, IMapper mapper, UserManager<AppUser> userManager, IMailService mailService)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
            _userManager = userManager;
            _mailService = mailService;
        }



        public async Task<string> FillLogoPath(IFormFile formFile)
        {
            if (formFile != null)
            {
                using var image = Image.Load(formFile.OpenReadStream());
                //Dosyayı yolunu okuduk

                image.Mutate(x => x.Resize(140, 140));//Resim boyutu ayarladık

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/img/Logo/{guid}.jpg");
                return $"/img/Logo/{guid}.jpg";
            }
            else
            {
                return $"/img/Logo/default.jpeg";

            }
        }
        public async Task<string> CreateCompany(AddCompanyDTO model)
        {
            AppCompany company = _mapper.Map<AppCompany>(model);

            company.Logo = await FillLogoPath(model.LogoFile);
            await _companyRepo.Create(company);

            if (await _companyRepo.Any(x => x.AppCompanyID == company.AppCompanyID))
                return "Company Succesfully Created";
            else
                return "Creating Company Failed";
        }

        public async Task<string> UpdateCompany(UpdateCompanyDTO model)
        {
            try
            {
                var company = await _companyRepo.GetDefault(x => x.AppCompanyID == model.AppCompanyID);
                if (model.LogoFile != null)
                {
                    company.Logo = await FillLogoPath(model.LogoFile);
                }
                //company.CompanyName = model.CompanyName;
                //company.CompanyTitle = model.CompanyTitle;
                //company.EmailAddress = model.EmailAddress;
                _mapper.Map(model, company);
                await _companyRepo.Update(company);
            

            }
            catch (Exception)
            {

                return "Could not updated";
            }
            return "Successfully updated";

            //if (await _companyRepo.Any(x => x.AppCompanyID == company.AppCompanyID))
            //    return "Company Succesfully Created";
            //else
            //    return "Creating Company Faied";
        }

        public async Task<string> DeleteCompany(Guid Id)
        {
 
            var company = await _companyRepo.GetDefault(x => x.AppCompanyID == Id);
            if (company != null)
            {
                company.Status = Status.Passive; await _companyRepo.Delete(company);
                return "Company successfully deleted.";
            }
            else
            {
                return "Company not found.";
            }
        }

        public async Task<List<AppCompany>> GetAllCompany()
        {
            var companyList = await _companyRepo.GetDefaults(x => x.Status == Status.Active);
			return companyList; 
        }

        public async Task<bool> UpdateAdmin(AdminUpdateDTO model)
        {
            var updatedUser = await _userManager.FindByIdAsync(model.Id.ToString());

            if (model.UploadPath != null)
            {
                updatedUser.ImagePath = await FillImagePath(model.UploadPath);
            }

            updatedUser.PhoneNumber = model.PhoneNumber;
            updatedUser.Address = model.Address;

            var result = await _userManager.UpdateAsync(updatedUser);
            return result.Succeeded;
        }

        public async Task<string> FillImagePath(IFormFile formFile)
        {
            if (formFile != null)
            {
                using var image = Image.Load(formFile.OpenReadStream());
                //Dosyayı yolunu okuduk

                image.Mutate(x => x.Resize(140, 140));//Resim boyutu ayarladık

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/img/userspic/{guid}.jpg");
                return $"/img/userspic/{guid}.jpg";
            }
            else
            {
                return $"/img/userspic/default.jpeg";

            }

        }

        public async Task<AppCompany> GetCompany(Guid Id)
        {
            var company = await _companyRepo.GetDefault(x => x.AppCompanyID == Id);
            return company;
        }
        string ToLowerEnglish(string text)
        {
            // Tüm karakterleri küçük harfe dönüştürme
            string lowerText = text.ToLower();

            // Türkçe karakterleri İngilizce karakterlere dönüştürme
            lowerText = lowerText.Replace("İ", "I").Replace("ı", "i")
                       .Replace("Ğ", "G").Replace("ğ", "g")
                       .Replace("Ü", "U").Replace("ü", "u")
                       .Replace("Ş", "S").Replace("ş", "s")
                       .Replace("Ç", "C").Replace("ç", "c")
                       .Replace("Ö", "O").Replace("ö", "o");           

            return lowerText;
        }
        public async Task<string> CreateEmail(Guid Id,string name,string surname)
        {
            var company= await GetCompany(Id);
            return ToLowerEnglish(($"{name}.{surname}@{company.CompanyName}.com").Replace(" ",""));
        }
        public  string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            string password;

            do
            {
                var result = new StringBuilder(8);
                for (int i = 0; i < 8; i++)
                {
                    result.Append(chars[random.Next(chars.Length)]);
                }
                password = result.ToString();
            }
            while (!password.Any(char.IsUpper) || !password.Any(char.IsLower));

            return password;
        }
        public async Task<Message> CreateManager(AddManagerDTO model)
        {
            Message message = new Message();
            var manager = _mapper.Map<AddManagerDTO, AppUser>(model);//manager appuser türünde          
            manager.ImagePath = await FillImagePath(model.UploadPath);
            manager.Email =await CreateEmail(model.CompanyID,model.Name,model.Surname);
            manager.UserName = $"{model.Name.Substring(0,1).ToLower()}{model.Surname.ToUpper()}";
            string password = GeneratePassword();
            
            var result = await _userManager.CreateAsync(manager, password);          
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(manager, "Manager");//manager rolü atandı
                if (!await _mailService.SendEmailAsyncToManager(manager.Email, password))
                {
                    message.MessageBody= "Sending Message Failed";
                    message.IsPositiveAnswer = false;
                    return message;
                }
                    message.MessageBody= "Manager Successfully Created";
                message.IsPositiveAnswer = true;
                return message;
            }
            else
            {
                message.MessageBody = "Creating Manager Failed";
                message.IsPositiveAnswer = false;
                return message;
            }
        }
        public async Task<IQueryable<ListOfManagerVM>> GetAllManager()
        {
            var companyList = await _companyRepo.GetDefaults(x=>x.Status==Status.Active || x.Status == Status.Modified);
            var managerList =await _userManager.GetUsersInRoleAsync("Manager");
            foreach (var comp in companyList)
            {
                foreach (var man in managerList)
                {
                    if (man.CompanyId==comp.AppCompanyID)
                    {
                        man.Company = comp;
                    }
                }
            }
            var listOfmanager = managerList.Select(c => _mapper.Map<ListOfManagerVM>(c)).AsQueryable();
            return listOfmanager;
        }
    }
}

