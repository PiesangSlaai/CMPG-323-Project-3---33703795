using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        bool ProductExists(int id);
    }
}

