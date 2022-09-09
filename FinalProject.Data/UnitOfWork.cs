using FinalProject.Data.Repositories.Concretes;
using FinalProject.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _context;
        public IUserRepository Users { get; private set; }
        public IReservationRepository Reservations { get; private set; }

        public UnitOfWork(MainDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Reservations = new ReservationRepository(context);
        }


        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
