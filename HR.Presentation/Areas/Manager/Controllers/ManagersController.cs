using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Application.Services.AdvanceService;
using HR.Application.Services.ManagerService;
using HR.Application.Services.UserService;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HR.Presentation.Areas.Manager.Controllers
{
	[Area("Manager")]
	[Authorize(Roles = "Manager")]
	public class ManagersController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IManagerService _managerService;
        private readonly IAdvanceService _advanceService;
        public ManagersController(UserManager<AppUser> userManager, IUserService userService, IMapper mapper, IAdvanceService advanceService, IManagerService managerService)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
            _advanceService = advanceService;
            _managerService = managerService;
        }
        [HttpGet]
		public async Task<IActionResult> ManagerProfile()
		{
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            return View(_mapper.Map<UserVM>(user));
        }

      
        [HttpGet]
        public async Task<IActionResult> ManagerDetail()
		{
            string Id = _userManager.GetUserId(User);
            var userDetails = await _userService.GetUserDetails(Guid.Parse(Id));
            return View(userDetails);
        }

        [HttpGet]
        public async Task<IActionResult> ManagerUpdateProfile()
        {
            var manager = await _userManager.GetUserAsync(User);
            var send = _mapper.Map<UpdateManagerDTO>(manager);
            return View(send);

        }

        [HttpPost]
        public async Task<IActionResult> ManagerUpdateProfile(UpdateManagerDTO manager)
        {

            if (ModelState.IsValid)
            {
                if (await _managerService.UpdateManager(manager))
                {
                    return RedirectToAction(nameof(ManagerProfile));
                }
            }
            return View(manager);
        }
       

    }
}
