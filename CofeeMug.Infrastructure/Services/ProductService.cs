using CofeeMug.Infrastructure.Repositories;
using CoffeeMug.Core.Domain.Models;
using CoffeeMug.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CofeeMug.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Guid id, string name, decimal price)
        {
            var product = new Product(id, name, price);
            await _productRepository.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _productRepository.GetAllAsync();

        public async Task<Product> GetById(Guid id)
            => await _productRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Guid id, string name, decimal price) 
        {
            var product = new Product(id, name, price);
            var toUpdate = await _productRepository.GetByIdAsync(id);

            if (toUpdate == null)
            {
                throw new ArgumentException($"Product with id equal to ${id} does not exists");
            }
            else
            {
                await _productRepository.UpdateAsync(product);
            }
        }

        public async Task DeleteAsync(Guid id) 
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new ArgumentException($"Product with id {id} does not exists");
            }
            else 
            {
                await _productRepository.DeleteAsync(id);
            }
        }


    }
}
