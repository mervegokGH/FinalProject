using FinalProject.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        public IReservationRepository Reservations { get; }
        void Complete();
    }
}
