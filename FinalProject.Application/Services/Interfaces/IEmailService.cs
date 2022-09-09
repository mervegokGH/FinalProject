using FinalProject.Application.Models;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task<MailRequest> SendEmailAsync(MailRequest mailRequest);
    }
}
