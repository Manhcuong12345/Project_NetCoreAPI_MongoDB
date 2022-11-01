using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;
using System.Xml.Linq;

namespace Project_NetCore_MongoDB.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly IMongoCollection<Comments> _collection;
        private readonly DbConfiguration _settings;
        public CommentsRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Comments>("comments");
         }

        public Task<List<Comments>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Comments> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<Comments>> GetAllCommentId(string id)
        {
            return _collection.Find(c => true).ToListAsync();
        }

        public async Task<Comments> CreateAsync(Comments comments)
        {
            await _collection.InsertOneAsync(comments).ConfigureAwait(false);
            return comments;
        }
        public Task UpdateAsync(string id, Comments comments)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, comments, new UpdateOptions { IsUpsert = true });
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
