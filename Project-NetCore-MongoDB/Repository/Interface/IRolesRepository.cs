using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository.Interface
{
    public interface IRolesRepository
    {
        Task<RolesName> CreateAsync(RolesName roles);
        Task<RolesName> GetByIdAsync(string id);

        Task<RolesName> GetByRole(string userRole);
    }
}
