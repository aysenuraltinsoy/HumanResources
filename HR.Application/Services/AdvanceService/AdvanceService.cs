using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.Message;
using HR.Application.Models.VMs;
using HR.Domain.Entities;
using HR.Domain.Enum;
using HR.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Services.AdvanceService
{
    public class AdvanceService : IAdvanceService
    {
        private readonly IMapper _mapper;
        private readonly IUserAdvanceRepo _userAdvanceRepo;
        private readonly UserManager<AppUser> _userManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICompanyRepo _companyRepo;

        public AdvanceService(IMapper mapper, UserManager<AppUser> appUser, IUserAdvanceRepo userAdvanceRepo, IHttpContextAccessor httpContextAccessor, ICompanyRepo companyRepo)
        {
            _mapper = mapper;
            _userAdvanceRepo = userAdvanceRepo;
            _userManager = appUser;
            _httpContextAccessor = httpContextAccessor;
            _companyRepo = companyRepo;
        }

        public async Task<Message> CreateAdvance(RequestAdvanceDTO model)
        {
            Message message = new Message();
           
            var IndividualAdvanceList = await _userAdvanceRepo.GetDefaults(x => x.AppUserId == model.AppUserId && x.AdvanceType == AdvanceType.IndividualDemand && (x.ApprovalStatus == ApprovalStatus.Approved || x.ApprovalStatus == ApprovalStatus.AwaitingApproval));
            var CorporateAdvanceList = await _userAdvanceRepo.GetDefaults(x => x.AppUserId == model.AppUserId && x.AdvanceType == AdvanceType.CorporateDemand && (x.ApprovalStatus == ApprovalStatus.Approved || x.ApprovalStatus == ApprovalStatus.AwaitingApproval));
            var user = await _userManager.FindByIdAsync(model.AppUserId.ToString());
            if (model.Amount > 0 && (IndividualAdvanceList.Sum(x => x.Amount) + model.Amount) < user.Salary * 3 && model.AdvanceType == AdvanceType.IndividualDemand)
            {
                var advance = _mapper.Map<AppUserAdvance>(model);
                await _userAdvanceRepo.Create(advance);
                message.MessageBody = "Your advance request has been successfully created.";
                message.IsPositiveAnswer=true;
            }
            else if (model.Amount > 0 && model.Amount < 250000 && model.AdvanceType == AdvanceType.CorporateDemand && (CorporateAdvanceList.Sum(x => x.Amount) + model.Amount) < 1000000)
            {
                var advance = _mapper.Map<AppUserAdvance>(model);
                await _userAdvanceRepo.Create(advance);
                message.MessageBody = "Your advance request has been successfully created.";
                message.IsPositiveAnswer = true;
            }
            else
            {
                if (model.AdvanceType == AdvanceType.CorporateDemand)
                {
                    message.MessageBody = "Your request the amount of the corporate advance exceeded the limit.";
                    message.IsPositiveAnswer = false;
                } 
                else
                {
                    message.MessageBody = "Your request individual advance amount exceeded the annual limit.";
                    message.IsPositiveAnswer=false;
                }
            }
            return message;
        }

        public async Task<List<UserAdvanceListVM>> GetAdvances(Guid Id)
        {
            var appUserAdvanceList = await _userAdvanceRepo.GetDefaults(x => x.AppUserId == Id);

            return _mapper.Map<List<UserAdvanceListVM>>(appUserAdvanceList);
        }

        public async Task ApprovedAdvance(Guid Id)
        {
            var updateUserAdvance = await _userAdvanceRepo.GetDefault(x => x.Id == Id);
            updateUserAdvance.ApprovalStatus = ApprovalStatus.Approved;
            updateUserAdvance.ReplyDate= DateTime.UtcNow;
            await _userAdvanceRepo.Update(updateUserAdvance);
        }


        //Bireysel avans talepleri için  bir sene içinde 3 maaş kadar mavans talep edebileceğini belirten metot yazılacak.
        //Kurumsal avas tipinde ise bir üst limit belirlenecek.(üst limit 250000 tl dir.)
        public async Task CancelAdvance(Guid id)
        {
            AppUserAdvance cancelledAdvance = await _userAdvanceRepo.GetDefault(x => x.Id == id);
            cancelledAdvance.ApprovalStatus = ApprovalStatus.Cancelled;

            await _userAdvanceRepo.Update(cancelledAdvance);
        }

        public async Task<List<AdvanceListVM>> GetAdvancesListByCompany()
        {
            var user=_httpContextAccessor.HttpContext.User;
            var activeUser = await _userManager.GetUserAsync(user);
            var companyId = activeUser.CompanyId;
            var companysPersonnels = _userManager.Users.Include(a => a.AppUserAdvances).Where(u => u.CompanyId == companyId).ToList();
            var advancesList=new List<AdvanceListVM>();
            foreach (var personnel in companysPersonnels)
            {
                var advances = personnel.AppUserAdvances
                    .Select(a => new AdvanceListVM
                    {
                        ID = a.Id,
                        Description = a.Description,
                        Amount = a.Amount,
                        ApprovalStatus= a.ApprovalStatus,
                        AdvanceType= a.AdvanceType,
                        RequestDate=a.RequestDate,
                        ReplyDate=a.ReplyDate,
                        ApprovalDate=a.ApprovalDate,
                        AppUser=a.AppUser,
                        Currency=a.Currency
                    });

                advancesList.AddRange(advances);
            }
             
            return advancesList.OrderBy(s => s.ApprovalStatus).ToList();

        }

        public async Task RejectAdvance(Guid id)
        {
            AppUserAdvance rejectedAdvance = await _userAdvanceRepo.GetDefault(x => x.Id == id);
            rejectedAdvance.ApprovalStatus = ApprovalStatus.Rejection;
            rejectedAdvance.ReplyDate = DateTime.UtcNow;
            await _userAdvanceRepo.Update(rejectedAdvance);
        }
    }
}
