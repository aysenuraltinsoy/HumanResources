using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Services.UserService
{
    public interface IUserService
    {
        Task<string> FillImagePath(IFormFile file);
        Task<UpdateProfileDTO> GetByUserID(Guid Id);
        Task<bool> UpdateUser(UpdateProfileDTO model);
        Task<UserDetailsVM> GetUserDetails(Guid Id);
        Task<UserVM> GetUser(Guid Id);
    }
}
