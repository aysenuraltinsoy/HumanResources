using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using HR.Application.Models.DTOs;
using HR.Application.Models.VMs;
using HR.Application.Services.AdvanceService;
using HR.Application.Services.UserService;
using HR.Application.Validators;
using HR.Domain.Entities;
using HR.Domain.Enum;
using HR.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;


namespace HR.Presentation.Areas.Personnel.Controllers
{
	[Area("Personnel")]
	
	//[Authorize(Roles = "Personnel")]
	public class PersonnelController : Controller
	{
		private readonly IUserService _userService;
		private readonly IAdvanceService _advanceService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
	    private readonly RoleManager<AppRole> _roleManager;
		public PersonnelController(UserManager<AppUser> userManager, IUserService userService, IMapper mapper,IAdvanceService advanceService)
		{
			_userManager = userManager;
			_userService = userService;
			_advanceService = advanceService;
			_mapper = mapper;
		}

		//GET: Personnel Home Page
		public async Task<IActionResult> Profile() //++++
		{
			//var user = await _userService.GetUser(id);
			var user = await _userManager.FindByNameAsync(User.Identity?.Name);
			return View(_mapper.Map<UserVM>(user));
		}
		//GET: Personnel/DetailPage/{id}
		public async Task<IActionResult> DetailPage()  //+++
		{
			string Id = _userManager.GetUserId(User);
			var userDetails = await _userService.GetUserDetails(Guid.Parse(Id));
			return View(userDetails);
		}

		//GET: Personnel/Edit/{id}
		[HttpGet]
		//[Route("Personnel/Edit")]
		public async Task<IActionResult> EditPersonnel()
		{
			var user = await _userManager.GetUserAsync(User);
			var send = _mapper.Map<UpdateProfileDTO>(user);
			 //login olan kullanıcı için sormayı unutma!!
			return View(send);
		}

		[HttpPost]
		public async Task<IActionResult> EditPersonnel(UpdateProfileDTO user)
		{

			if (ModelState.IsValid)
			{
				if (await _userService.UpdateUser(user))
				{
					return RedirectToAction(nameof(Profile));
				}
			}
			return View(user);
		}
		[HttpGet]
		public async Task<IActionResult> UserAdvance()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UserAdvance(RequestAdvanceDTO model)
		{
			string Id = _userManager.GetUserId(User);
			model.AppUserId = Guid.Parse(Id);
			
			if (ModelState.IsValid)
			{
				var response = await _advanceService.CreateAdvance(model);
				TempData["Response"] = response.MessageBody;
				TempData["ResponseState"] = response.IsPositiveAnswer;
				if(response.IsPositiveAnswer)
				return RedirectToAction();
			}

			return View(model);
		}
		public async Task<IActionResult> ListOfAdvances()
		{
			string Id = _userManager.GetUserId(User);
			var advanceList = await _advanceService.GetAdvances(Guid.Parse(Id));			
			return View(advanceList);
		}
        public async Task<IActionResult> CancelAdvance(Guid id)
        {
			await _advanceService.CancelAdvance(id);
			return RedirectToAction(nameof(ListOfAdvances));
        }
    }
}
