using CoffeeMug.Core.Domain.Models;
using CoffeeMug.Core.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace CofeeMug.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly IMongoDatabase _database;

        public ProductRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await Collection.AsQueryable().ToListAsync();


        public async Task<Product> GetByIdAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(s => s.Id == id);

        public async Task UpdateAsync(Product product)
            => await Collection.ReplaceOneAsync(filter => filter.Id == product.Id, product);

        public async Task DeleteAsync(Guid id)
            => await Collection.DeleteOneAsync(filter => filter.Id == id);

        public async Task AddAsync(Product product)
            => await Collection.InsertOneAsync(product);

        private MongoDB.Driver.IMongoCollection<Product> Collection => _database.GetCollection<Product>("Products");

    }
}
