using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository;

namespace Project_NetCore_MongoDB.Services
{
    public class ProductsService : IProductsService
    {
        //SU dung lop ben customerRepository de su dung trong nay
        private readonly IProductsRepository _productRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Products>> GetAllAsync()
        {
            return _productRepository.GetAllAsync();
        }

        public Task<Products> GetByIdAsync(string id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public Task<Products> CreateAsync(Products products)
        {
            return _productRepository.CreateAsync(products);
        }

        public Task UpdateAsync(string id, Products products)
        {
            return _productRepository.UpdateAsync(id, products);
        }

        public Task DeleteAsync(string id)
        {
            return _productRepository.DeleteAsync(id);
        }
    }
}
