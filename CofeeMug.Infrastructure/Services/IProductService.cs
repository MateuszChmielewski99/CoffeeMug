using CoffeeMug.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CofeeMug.Infrastructure.Services
{
    public interface IProductService
    {
        Task AddAsync(Guid id, string name, decimal price);
        Task UpdateAsync(Guid id, string name, decimal price);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetById(Guid id);
        Task DeleteAsync(Guid id);

    }
}
