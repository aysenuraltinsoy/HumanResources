using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.Message;
using HR.Application.Services.AdminService;
using HR.Application.Services.ManagerService;
using HR.Application.Services.UserService;
using HR.Domain.Entities;
using HR.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HR.Presentation.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ManagerController : Controller
	{
		private readonly IAdminService _adminService;
		private readonly IManagerService _managerService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;


        public ManagerController(IAdminService adminService, IManagerService managerService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _adminService = adminService;
            _managerService = managerService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AddManager()
		{
            ViewBag.CompanyList = await _adminService.GetAllCompany();
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
		{
            ViewBag.CompanyList = await _adminService.GetAllCompany();
       
            if (ModelState.IsValid)
			{      
                    Message response = await _adminService.CreateManager(addManagerDTO);  
                    TempData["response"] = response.MessageBody;	
                    TempData["IsSuccess"] = response.IsPositiveAnswer;	
				
                    return RedirectToAction(nameof(ListOfManager));     
			}
			
			return View("AddManager",addManagerDTO);
		}
        [HttpGet]
        public async Task<IActionResult> ListOfManager()
        {
            return View(await _adminService.GetAllManager());
        }

        
    }
}
