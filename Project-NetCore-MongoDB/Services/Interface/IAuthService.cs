using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Services.Interface
{
    public interface IAuthService
    {
        Task<List<Users>> GetAllAsync();
        Task<Users> LoginUser(string email);
        Task<Users> CreateAsync(Users user);
    }
}
