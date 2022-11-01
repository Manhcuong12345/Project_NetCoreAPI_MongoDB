using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Services.Interface;

namespace Project_NetCore_MongoDB.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

       public async Task<RolesName> CreateAsync(RolesName roles)
        {
            return await _rolesRepository.CreateAsync(roles);
        }

        public async Task<RolesName> GetByRole(string userRole)
        {
            return await _rolesRepository.GetByRole(userRole);
        }

        public async Task<RolesName> GetByIdAsync(string id)
        {
             return await _rolesRepository.GetByIdAsync(id);
        }
    }
}
