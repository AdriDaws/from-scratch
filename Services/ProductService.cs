using FromScratch.DTOs;
using FromScratch.Repositories;
using FromScratch.Exceptions;
using FromScratch.Models;

namespace FromScratch.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var products = await productRepository.GetAllProducts();
        return products.Select(ProductDTO.FromProduct);
    }

    public async Task<ProductDTO> GetProductById(Guid id)
    {
        var product = await productRepository.GetProductById(id);
        if (product is null)
        {
            throw new NotFoundException("Product not found");
        }
        return ProductDTO.FromProduct(product);
    }

    public async Task<ProductDTO> CreateProduct(ProductDTO product)
    {
        var productModel = new Product(product.Name, product.Price);
        var createdProduct = await productRepository.CreateProduct(productModel);
        return ProductDTO.FromProduct(createdProduct);
    }

    public async Task<ProductDTO> UpdateProduct(Guid id, ProductDTO product)
    {
        var productModel = await productRepository.GetProductById(id);
        if (productModel is null)
        {
            throw new NotFoundException("Product not found");
        }

        productModel.Update(product.Name, product.Price);

        var updatedProduct = await productRepository.UpdateProduct(productModel);
        return ProductDTO.FromProduct(updatedProduct);
    }

    public async Task DeleteProduct(Guid id)
    {
        await productRepository.DeleteProduct(id);
    }
}