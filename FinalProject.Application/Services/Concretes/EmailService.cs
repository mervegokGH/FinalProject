using FinalProject.Application.Models;
using FinalProject.Application.Services.Interfaces;
using FinalProject.Shared.SettingsModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<MailRequest> SendEmailAsync(MailRequest mailRequest)
        {
            var builder = new BodyBuilder
            {
                HtmlBody = mailRequest.Body
            };

            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_emailSettings.Mail),
                Subject = mailRequest.Subject,
                Body = builder.ToMessageBody()
            };
           
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.From.Add(MailboxAddress.Parse("FinalProject"));
            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
            try
            {
                
              var response=  await smtp.SendAsync(email);
               
                   mailRequest.isSended = true;
                
            }
            catch(Exception ex)
            {
                mailRequest.isSended = false;
                mailRequest.ErrorMessage = "Mail Gönderielemedi.Hata nedeni.." + ex.Message;
            }
            smtp.Disconnect(true);
            return mailRequest;
            
        }
        
    }
}

