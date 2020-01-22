using CoffeeMug.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMug.Core.Repositories
{
    public interface IProductRepository
    {
        Task <IEnumerable<Product>>GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);

    }
}
