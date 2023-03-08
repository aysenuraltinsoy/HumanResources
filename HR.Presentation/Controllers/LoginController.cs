using AutoMapper;
using HR.Application.Models.DTOs;
using HR.Application.Services.MailService;
using HR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Text;

namespace HR.Presentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
       
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IMailService mailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
        }

        public IActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Login(LoginDTO loginDTO)
		{
            if (loginDTO.Email==null)
            {
                TempData["ErrorEmail"] = "Please Enter Email";
                return View(loginDTO);
            }
            if (loginDTO.Password == null)
            {
                TempData["ErrorPassword"] = "Please Enter Password";
                return View(loginDTO);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email==loginDTO.Email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Such a user is not registered.";
                return View(loginDTO);
            }
            if (user.IsActive==false)
            {
                TempData["ErrorMessage"] = "Your account is passive";
                return View();
            }
			if (!await _userManager.CheckPasswordAsync(user,loginDTO.Password))
			{
				TempData["ErrorMessage"] = "Such a user is not registered.";
				return View(loginDTO);
			}
            var role = await _userManager.GetRolesAsync(user);
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, true);
            if (result.Succeeded)
			{
                if (user.UpdateDate==null)
                {
                    return RedirectToAction(nameof(TakeNewPassword), new {currentPassword=loginDTO.Password});
                }
				if (role.FirstOrDefault() == "Admin")
				{
					return RedirectToAction("AdminProfile", "Admin", new { area = "Admin" });
				}
				else if(role.FirstOrDefault() == "Personnel")
				{
					return RedirectToAction("Profile", "Personnel", new { area = "Personnel" });
                }
                else
                {
                    return RedirectToAction("ManagerProfile", "Managers", new { area = "Manager" });
				}
			}
          
			return View();
		}
		public async Task<IActionResult> LogOut() 
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public  IActionResult CodeSender()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CodeSender(string email)
        {
            ViewData["ErrorMessage"] = "";
           
            var user = await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null)
            {
                ViewData["ErrorMessage"] = "A user with the given email address could not be found.";
                return View(ViewData["ErrorMessage"]);
            }
            if(await _mailService.SendEmailAsyncForResetPassword(email, "Password was reseted."))
            {
                
                email1 = email;
                TempData["Succesfull"] = "Please check your Email address.";
                return View();
            }  
           

            ViewData["ErrorMessage"] = "Failed to send Email";
            return View();
        }
        static string? email1;
    
        public async Task<IActionResult> ResetPassword(string token)
        {
            
            ResetPasswordDTO resetPassword = new ResetPasswordDTO()
            {
                Token = token,
                Email = email1
            };
          
            return View(resetPassword);
        }
   
        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordDTO model)
        {

            string decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(model.Token));
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(model.Email, "User not found.");
                return View(model);
            }
            
            var user = await _userManager.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
            if (user == null)
            {
                // Kullanıcı bulunamadıysa uyarı verir
                return View(model);
            }
            var result = await _userManager.ResetPasswordAsync(user,decodedToken,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("Code", "Code is not correct.");
                return View(model);
            }
            
            
        }
        public IActionResult TakeNewPassword(string currentPassword)
        {
            TakeNewPasswordDTO takeNewPasswordDTO = new TakeNewPasswordDTO()
            {
                CurrentPassword = currentPassword
            }; 
            return View(takeNewPasswordDTO);
        }
        [HttpPost]
		public async Task<IActionResult> TakeNewPassword(TakeNewPasswordDTO model)
		{
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user=await _userManager.GetUserAsync(User);
            var result=await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);
            if (result.Succeeded)
            {
                user.UpdateDate= DateTime.Now;
                await _userManager.UpdateAsync(user);
				return RedirectToAction(nameof(LogOut));
			}
            else
            {
                ModelState.AddModelError("CurrentPassword", "Your password you entered is not valid");
                return View(model);
            }
		}
	}
}
