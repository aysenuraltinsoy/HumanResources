using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HR.Application.Services.ManagerService
{
    public interface IManagerService
    {
        Task<AppUser> GetManager(Guid id);
        Task<string> CreatePersonnel(AddPersonnelDTO model, Guid id);
        Task<string> CreateEmail(Guid Id, string name, string surname);
        Task<IQueryable<ListOfPersonnelVM>> GetAllPersonnel();
        Task<AppCompany> GetCompany(Guid Id);
        Task<List<AppUser>> GetAllPersonnelByCompanyID(Guid? id);
        Task<bool> UpdateManager(UpdateManagerDTO model);
    }
}