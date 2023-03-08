using AutoMapper;
using HR.Application.Services.AdvanceService;
using HR.Application.Services.UserService;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HR.Presentation.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class AdvancesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IAdvanceService _advanceService;

        public AdvancesController(IAdvanceService advanceService, IMapper mapper, IUserService userService, UserManager<AppUser> userManager)
        {
            _advanceService = advanceService;
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> ListOfAdvances()
        {
            var advanceList = await _advanceService.GetAdvancesListByCompany();
            return View(advanceList);
        }

       
        public async Task<IActionResult> ApproveAdvance(Guid id)
        {
            await _advanceService.ApprovedAdvance(id);
            return RedirectToAction("ListOfAdvances");
        }

        
        public async Task<IActionResult> RejectAdvance(Guid id)
        {
            await _advanceService.RejectAdvance(id);
            return RedirectToAction("ListOfAdvances");
        }
    }
}
