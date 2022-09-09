using FinalProject.Data.Repositories.Interfaces;
using FinalProject.Domain.Reservations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data.Repositories.Concretes
{
    public class ReservationRepository : Repository<Reservation>,IReservationRepository
    {
        public ReservationRepository(MainDbContext context) : base(context)
        {
        }
    }
}
