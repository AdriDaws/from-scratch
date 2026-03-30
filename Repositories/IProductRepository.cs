using FromScratch.Models;

namespace FromScratch.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product?> GetProductById(Guid id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(Guid id);
}