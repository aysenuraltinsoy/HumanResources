using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Application.Services.AdminService;
using HR.Application.Services.UserService;
using HR.Domain.Entities;
using HR.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminController(UserManager<AppUser> userManager, IMapper mapper, IUserService userService, IAdminService adminService)
        {
            _userManager = userManager;
            _userService = userService;
            _adminService = adminService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> AdminProfile()
        {
            string Id = _userManager.GetUserId(User);
            var userDetails = await _userService.GetUserDetails(Guid.Parse(Id));
            return View(userDetails);
        }
        [HttpGet]
        public async Task<IActionResult> AdminUpdateProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var send = _mapper.Map<AdminUpdateDTO>(user);
            return View(send);

        }

        [HttpPost]
        public async Task<IActionResult> AdminUpdateProfile(AdminUpdateDTO user)
        {

            if (ModelState.IsValid)
            {
                if (await _adminService.UpdateAdmin(user))
                {
                    TempData["operationMessage"] = "Admin Succesfully Updated";
                    return RedirectToAction(nameof(AdminProfile));
                }
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AdminDetailProfile()
        {
            string Id = _userManager.GetUserId(User);
            var userDetails = await _userService.GetUserDetails(Guid.Parse(Id));
            return View(userDetails);
        }
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDTO addCompanyDTO)
        {
            string response = "";

            if (ModelState.IsValid)
            {

                response = await _adminService.CreateCompany(addCompanyDTO);
                TempData["operationMessage"] = response;
                return RedirectToAction(nameof(ListOfCompany));
            }
            return View(addCompanyDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ListOfCompany(int page = 1, int pageSize = 10)
        {
			var companies = await _adminService.GetAllCompany();
			int totalCompanies = companies.Count();
			int totalPages = (int)Math.Ceiling((double)totalCompanies / pageSize);
			var subset = companies.Skip((page - 1) * pageSize).Take(pageSize);
			var viewModel = new ListOfCompanyVM
			{
				Companies =subset.ToList(),
				CurrentPage = page,
				PageSize = pageSize,
				TotalCount = totalPages
			};
			return View(viewModel);
		}
        [HttpGet]
        public async Task<IActionResult> CompanyDetailProfile(Guid id)
        {
            var company = await _adminService.GetCompany(id);
            var detailCompany =  _mapper.Map<DetailCompanyVM>(company);
            return View(detailCompany);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateInfoCompany(Guid id) // şirket bilgileri güncelleme ekranı
        {
            var company = await _adminService.GetCompany(id);
            return View(_mapper.Map<UpdateCompanyDTO>(company));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInfoCompany(UpdateCompanyDTO updateCompanyDTO)
        {

            if (ModelState.IsValid)
            {

                await _adminService.UpdateCompany(updateCompanyDTO);
                return RedirectToAction(nameof(ListOfCompany));

            }
            return View(updateCompanyDTO);
        }

	}

}



