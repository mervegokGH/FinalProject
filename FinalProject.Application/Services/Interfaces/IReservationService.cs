using FinalProject.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> Create(Reservation reservation);
        IEnumerable<Reservation> List();

    }
}
