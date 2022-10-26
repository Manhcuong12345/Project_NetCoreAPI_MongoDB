using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Services
{
    public interface IProductsService
    {
        Task<List<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(string id);
        Task<Products> CreateAsync(Products products);
        Task UpdateAsync(string id, Products products);
        Task DeleteAsync(string id);
    }
}
