using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Services.MailService
{
    public interface IMailService
    {
        Task<bool> SendEmailAsyncForResetPassword(string Email,string subject);
        Task<bool> SendEmailAsyncToManager(string Email,string password);

    }
}
