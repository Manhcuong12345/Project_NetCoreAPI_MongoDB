using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Services.Interface
{
    public interface IRolesService
    {
        Task<RolesName> CreateAsync(RolesName roles);
        Task<RolesName> GetByIdAsync(string id);

        Task<RolesName> GetByRole(string userRole);

    }
}
