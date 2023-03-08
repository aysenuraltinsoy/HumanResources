using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Application.Services.AdminService;
using HR.Application.Services.ManagerService;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Printing;
using System.Security.Claims;

namespace HR.Presentation.Areas.Manager.Controllers
{
	[Area("Manager")]
	[Authorize(Roles = "Manager")]
	public class PersonnelController : Controller
	{
		private readonly IManagerService _managerService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IAdminService _adminService;

		public PersonnelController(IManagerService managerService, UserManager<AppUser> userManager, IAdminService adminService)
		{
			_managerService = managerService;
			_userManager = userManager;
			_adminService = adminService;
		}

		[HttpGet]
		public async Task<IActionResult> ListOfPersonnel(int page = 1, int pageSize = 8)
		{
			var manager = await _userManager.GetUserAsync(User);
			var personnels = await _managerService.GetAllPersonnelByCompanyID(manager.CompanyId);
			int totalPersonnels = personnels.Count();
			//int totalPages= (int)Math.Ceiling((double)totalPersonnels/pageSize);
			int totalPages = (totalPersonnels / pageSize) + 1;

			var subset = personnels.Skip((page - 1) * pageSize).Take(pageSize);
			var vm = new ListOfPersonVM
			{
				Personnels = subset.ToList(),
				TotalCount = totalPages,
				PageSize = pageSize,
				CurrentPage = page
			};
			return View(vm);

		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AddPersonnel()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddPersonnel(AddPersonnelDTO addPersonnelDTO)
		{
			string response = "";
			if (ModelState.IsValid)
			{
				string loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);//giriş yapaman manageri bulursun
				//var user = await _managerService.GetCompany(Guid.Parse(loginId));//managerin companysi
				response = await _managerService.CreatePersonnel(addPersonnelDTO,Guid.Parse(loginId));
				TempData["response"] = response;
				return RedirectToAction(nameof(ListOfPersonnel));
			}

			return View("AddPersonnel", addPersonnelDTO);
		}
		//[HttpGet]
		//public async Task<IActionResult> ListOfPersonnel()
		//{
		//	return View(await _managerService.GetAllPersonnel());
		//}
	}
}
