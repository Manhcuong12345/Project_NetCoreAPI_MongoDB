using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<List<Users>> GetAllAsync();

        Task<Users> LoginUser(string email);

        Task<Users> CreateAsync(Users user);
    }
}
