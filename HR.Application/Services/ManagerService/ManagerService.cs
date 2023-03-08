using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using HR.Domain.Enum;
using HR.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace HR.Application.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IUserRepo _userRepo;
        private readonly ICompanyRepo _companyRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ManagerService(IUserRepo userRepo, IMapper mapper, UserManager<AppUser> userManager, ICompanyRepo companyRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
            _companyRepo = companyRepo;
        }
        public async Task<AppUser> GetManager(Guid id)
        {
            return await _userRepo.GetDefault(x => x.Id == id);
        }
        public async Task<string> FillImagePath(IFormFile formFile)
        {
            if (formFile != null)
            {
                using var image = Image.Load(formFile.OpenReadStream());
                //Dosyayı yolunu okuduk                 image.Mutate(x => x.Resize(140, 140));//Resim boyutu ayarladık
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/img/userspic/{guid}.jpg");
                return $"/img/userspic/{guid}.jpg";
            }
            else
            {
                return $"/img/userspic/default.jpeg";
            }
        }
        public async Task<string> CreatePersonnel(AddPersonnelDTO model, Guid id)
        {
            var personnel = _mapper.Map<AddPersonnelDTO, AppUser>(model);//manager appuser türünde
            personnel.SecurityStamp = Guid.NewGuid().ToString();
            personnel.ImagePath = await FillImagePath(model.UploadPath);
            personnel.UserName = $"{model.Name.Substring(0, 1)}{model.Surname.ToUpper()}";
            var manager = await GetManager(id);
            personnel.CompanyId = manager.CompanyId;
            personnel.Email = await CreateEmail((Guid)manager.CompanyId, model.Name, model.Surname);
            var result = await _userManager.CreateAsync(personnel, model.Password); if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(personnel, "Personnel");//manager rolü atandı
                return "Personnel Successfully Created";
            }
            else
            {
                return "Creating Personnel Failed";
            }
        }
        public async Task<string> CreateEmail(Guid Id, string name, string surname)
        {
            var company = await GetCompany(Id);
            return ToLowerEnglish(($"{name}.{surname}@{company.CompanyName}.com").Replace(" ", ""));
        }
        string ToLowerEnglish(string text)
        {
            // Tüm karakterleri küçük harfe dönüştürme
            string lowerText = text.ToLower();             // Türkçe karakterleri İngilizce karakterlere dönüştürme
            lowerText = lowerText.Replace("İ", "I").Replace("ı", "i")
            .Replace("Ğ", "G").Replace("ğ", "g")
            .Replace("Ü", "U").Replace("ü", "u")
            .Replace("Ş", "S").Replace("ş", "s")
            .Replace("Ç", "C").Replace("ç", "c")
            .Replace("Ö", "O").Replace("ö", "o"); 
             return lowerText;
        }
        public async Task<IQueryable<ListOfPersonnelVM>> GetAllPersonnel()
        {
            var companyList = await _companyRepo.GetDefaults(x => x.Status == Status.Active || x.Status == Status.Modified);
            var personnelList = await _userManager.GetUsersInRoleAsync("Personnel");
            foreach (var comp in companyList)
            {
                foreach (var man in personnelList)
                {
                    if (man.CompanyId == comp.AppCompanyID)
                    {
                        man.Company = comp;
                    }
                }
            }
            var listOfPersonnel = personnelList.Select(c => _mapper.Map<ListOfPersonnelVM>(c)).AsQueryable();
            return listOfPersonnel;
        }
        public async Task<AppCompany> GetCompany(Guid Id)
        {
            var company = await _companyRepo.GetDefault(x => x.AppCompanyID == Id);
            return company;
        }
        public async Task<List<AppUser>> GetAllPersonnelByCompanyID(Guid? id)
        {
            var personnelList = await _userManager.GetUsersInRoleAsync("Personnel"); return personnelList.Where(x => x.CompanyId == id).ToList();
        }
        public async Task<bool> UpdateManager(UpdateManagerDTO model)
        {
            var updatedManager = await _userManager.FindByIdAsync(model.ID.ToString());

            if (model.UploadPath != null)
            {
                updatedManager.ImagePath = await FillImagePath(model.UploadPath);
            }
            updatedManager.PhoneNumber = (long)model.PhoneNumber;
            updatedManager.Address = model.Address;
            var result = await _userManager.UpdateAsync(updatedManager);
            return result.Succeeded;

        }
    }
}