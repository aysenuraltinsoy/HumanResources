using HR.Application.Models.DTOs;
using HR.Application.Models.Message;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Services.AdvanceService
{
    public interface IAdvanceService
    {
        Task<Message> CreateAdvance(RequestAdvanceDTO userAdvanceDTO);
        Task<List<UserAdvanceListVM>> GetAdvances(Guid Id);
        Task ApprovedAdvance(Guid Id);//UpdateServiceDTO oluşturulabilir
        Task CancelAdvance(Guid id);
        Task RejectAdvance(Guid id);
        Task<List<AdvanceListVM>> GetAdvancesListByCompany();

    }
}
