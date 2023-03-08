using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using HR.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace HR.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserService(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
        public async Task<UpdateProfileDTO> GetByUserID(Guid Id)
        {
            var updatedUserDTO = await _userManager.FindByIdAsync(Id.ToString());
            return _mapper.Map<UpdateProfileDTO>(updatedUserDTO);
        }


        public async Task<bool> UpdateUser(UpdateProfileDTO model)
        {
            var updatedUser = await _userManager.FindByIdAsync(model.Id.ToString());
          
            if (model.UploadPath != null)
            {
                updatedUser.ImagePath = await FillImagePath(model.UploadPath);
            }
           
            updatedUser.PhoneNumber= model.PhoneNumber;
            updatedUser.Address= model.Address;
            var result = await _userManager.UpdateAsync(updatedUser);
            return result.Succeeded;

        }

        public async Task<UserDetailsVM> GetUserDetails(Guid Id)
        {
            var appUser = await _userManager.FindByIdAsync(Id.ToString());
            return _mapper.Map<UserDetailsVM>(appUser);
        }

        public async Task<UserVM> GetUser(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            return _mapper.Map<UserVM>(user);
        }
    }
}
