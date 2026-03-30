using FromScratch.DTOs;

namespace FromScratch.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProducts();
    Task<ProductDTO> GetProductById(Guid id);
    Task<ProductDTO> CreateProduct(ProductDTO product);
    Task<ProductDTO> UpdateProduct(Guid id, ProductDTO product);
    Task DeleteProduct(Guid id);
}