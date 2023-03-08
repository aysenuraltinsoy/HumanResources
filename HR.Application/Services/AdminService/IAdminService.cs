using HR.Application.Models.DTOs;
using HR.Application.Models.Message;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Services.AdminService
{
    public interface IAdminService
    {
        Task<string> CreateCompany(AddCompanyDTO model);
        Task<string> UpdateCompany(UpdateCompanyDTO model);
        Task<string> DeleteCompany(Guid Id);
        Task<bool> UpdateAdmin(AdminUpdateDTO model);
		Task<List<AppCompany>> GetAllCompany();
        Task<Message> CreateManager(AddManagerDTO model);
        Task<IQueryable<ListOfManagerVM>> GetAllManager();
        Task<AppCompany> GetCompany(Guid Id);
    }
}
