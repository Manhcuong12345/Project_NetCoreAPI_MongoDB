using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services.Interface;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Repository.Interface;
using System.ComponentModel.DataAnnotations;

namespace Project_NetCore_MongoDB.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<Users> CreateAsync(Users user)
        {
            return await _authRepository.CreateAsync(user);
        }

        public Task<List<Users>> GetAllAsync()
        {
            return _authRepository.GetAllAsync();
        }

        public Task<Users> LoginUser(string email)
        {
            return _authRepository.LoginUser(email);
        }
    }
}
