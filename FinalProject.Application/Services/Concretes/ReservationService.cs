using FinalProject.Application.Models;
using FinalProject.Application.Services.Interfaces;
using FinalProject.Data;
using FinalProject.Domain.Reservations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Concretes
{
    //If the reservation is successful, it adds the reservation information to the reservations table in the database.
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReservationService> _logger;
        private readonly IEmailService _emailService;

        public ReservationService(IUnitOfWork unitOfWork, ILogger<ReservationService> logger, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailService = emailService;
        }


        public async Task<Reservation> Create(Reservation reservation)
        {
            _unitOfWork.Reservations.Add(reservation);

            MailRequest mail = new MailRequest()
            {
                Body = "Your reservation has been successfully saved. We wish you pleasant holidays.",
                Subject = "Reservation Registration Information",
                ToEmail = reservation.Email
                //reservation detaıls
            };

             MailRequest mailResponse=  await _emailService.SendEmailAsync(mail);
            if (mailResponse.isSended)
            {
                _logger.LogInformation($"New reservation registration added. Added record: {reservation}", reservation);
                reservation.isSended = mailResponse.isSended;
                reservation.ReservationMessage = "Your reservation has been successfully saved. We wish you pleasant holidays.";
            }
            else
            {
                _logger.LogInformation($"Reservation could not be created. Added record: {reservation}", reservation);
                reservation.isSended = mailResponse.isSended;
              
            }

            return reservation;
            
            
        }

        public IEnumerable<Reservation> List()
        {
            var reservations = _unitOfWork.Reservations.GetAll();
            return reservations;


        }

    }
}