using DnsClient;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;

namespace Project_NetCore_MongoDB.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IMongoCollection<RolesName> _collection;
        private readonly DbConfiguration _settings;
        public RolesRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<RolesName> ("role");
        }

       public async Task<RolesName> CreateAsync(RolesName roles)
        {
            await _collection.InsertOneAsync(roles).ConfigureAwait(false);
            return roles;
        }

       public async Task<RolesName> GetByRole(string userRole)
       {
          return await _collection.Find(x => x.Role == userRole).FirstOrDefaultAsync();
       }

        public async Task<RolesName> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
