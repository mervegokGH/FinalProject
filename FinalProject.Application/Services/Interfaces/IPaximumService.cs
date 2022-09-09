using FinalProject.Domain.Reservations;
using FinalProject.Shared.PaximumModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Interfaces
{
    public interface IPaximumService 
    {
        Task<Dictionary<int, string>> GetArrivalAutoCompleteAsync( string city);
        Task<List<Dictionary<string, string>>> PriceSearchAsync(int cityName);
        Task<Dictionary<string, string>> GetProductInfoAsync(string ItemId, string OwnerProvider);
        Task<string> BeginTransactionAsync(string OfferId);
        Task<string> SendReservationAsync(string TransactionId, Reservation reservation);
    }
}
