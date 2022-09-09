using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services.Interfaces
{
    public interface IProductService<T> where T : class
    {
        Task<string> Consume(T request, string methodAdress, string token);
    }
}
