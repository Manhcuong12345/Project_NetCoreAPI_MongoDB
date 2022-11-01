using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Dto;

namespace Project_NetCore_MongoDB.Services.Interface
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetAllAsync();
        Task<Comments> GetByIdAsync(string id);
        Task<Comments> CreateAsync(CommentsDto comments);
        Task UpdateAsync(string id, CommentsDto comments);
        Task DeleteAsync(string id);
        Task<List<Comments>> GetAllCommentId(string author);
    }
}
