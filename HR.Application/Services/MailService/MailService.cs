using HR.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace HR.Application.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public MailService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsyncForResetPassword(string Email, string subject)
        {
            AppUser user= await _userManager.FindByEmailAsync(Email);
            string resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            byte[] tokenBytes = Encoding.UTF8.GetBytes(resetPasswordToken);
            string token= WebEncoders.Base64UrlEncode(tokenBytes);
            
            //Bu url kendimiz kullanıcaz.
            //string url = _configuration["profiles:HR.Presentation:applicationUrl"] + "/Login/ResetPassword"+"?token=" + token;
            //Bu urli publish ederken kullanıcaz.
            string url = "https://hrpresentation20230202135341.azurewebsites.net" + "/Login/ResetPassword"+"?token=" + token;          
            
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                        
                mail.From = new MailAddress("testsende124@outlook.com");
                mail.To.Add(Email);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
            
                mail.Body = "<html><body><p>Your reset password token is: " + $"<br><strong><a target=\"_blank\" href={url}>Buraya tıklayın</a></strong>" + "</p></body></html>";         
                
                SmtpServer.Port =587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testsende124@outlook.com", "Testsender");
                SmtpServer.EnableSsl = true;
                await SmtpServer.SendMailAsync(mail);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SendEmailAsyncToManager(string Email, string password)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("testsende124@outlook.com");
                mail.To.Add(Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Password For Login";
                mail.Body = "<html><body><p>Your password is: " + password + "</p></body></html>";
               
                SmtpServer.Port =587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("testsende124@outlook.com", "Testsender");
                SmtpServer.EnableSsl = true;
                await SmtpServer.SendMailAsync(mail);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
