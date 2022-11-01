using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository.Interface
{
    public interface ICommentsRepository
    {
        Task<List<Comments>> GetAllAsync();
        Task<Comments> GetByIdAsync(string id);
        Task<Comments> CreateAsync(Comments comments);
        Task UpdateAsync(string id, Comments comments);
        Task DeleteAsync(string id);
        Task<List<Comments>> GetAllCommentId(string articlesId);
    }
}
