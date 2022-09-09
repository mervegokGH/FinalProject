using FinalProject.Application.Models;
using FinalProject.Application.Services.Interfaces;
using FinalProject.Data;
using FinalProject.Domain.Users;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace FinalProject.Application.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IEmailService emailService, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _logger = logger;
        }

        public IEnumerable<User> List()
        {
            var users = _unitOfWork.Users.GetAll();
            return users;


        }

        public async Task Create(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
            
            {
                MailRequest mail = new MailRequest()
                {
                    Body = "Your registration has been successfully received.",
                    Subject = "FinalProject Registration Confirmation",
                    ToEmail = user.Email
                };

                await _emailService.SendEmailAsync(mail);
                _logger.LogInformation($"New user registration added. Added record: {@user}", user);
            }
            
        }
        public Task Edit(User user)
        {
            User userEdit = _unitOfWork.Users.Get(user.Id);// choosing user 
            userEdit.Username = user.Username;
            userEdit.Password = user.Password;   
            userEdit.Email = user.Email;
            _unitOfWork.Complete();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var user = _unitOfWork.Users.Get(id);
            user.IsDeleted = true;
            _unitOfWork.Complete();
            _logger.LogInformation($"A user registration deleted. Deleted record: {@user}", user);
            return Task.CompletedTask;
        }
    

        public Task ChangeStatus(int id)
        {
            var user = _unitOfWork.Users.Get(id);
            if (user.IsActive == true)
                user.IsActive = false;
            else
                user.IsActive = true;

            _unitOfWork.Complete();
            _logger.LogInformation($"New user registration added. Added record: {@user}", user);
            return Task.CompletedTask;
        }

        public User Get(int id)
        {
            var user = _unitOfWork.Users.Get(id);
            return user;
        }
    }
}