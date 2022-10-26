using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;

namespace Project_NetCore_MongoDB.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Products> _collection;
        private readonly DbConfiguration _settings;
        public ProductsRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Products>("product");
        }

        public Task<List<Products>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Products> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Products> CreateAsync(Products products)
        {
            await _collection.InsertOneAsync(products).ConfigureAwait(false);
            return products;
        }
        public async Task UpdateAsync(string id, Products products)
        {
            await _collection.ReplaceOneAsync(c => c.Id == id, products);

        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
