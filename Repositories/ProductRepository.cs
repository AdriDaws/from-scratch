using FromScratch.Data;
using FromScratch.Exceptions;
using FromScratch.Models;
using Microsoft.EntityFrameworkCore;

namespace FromScratch.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts() => await dbContext.Products.ToListAsync();
    public async Task<Product?> GetProductById(Guid id) => await dbContext.Products.FindAsync(id);
    public async Task<Product> CreateProduct(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product;
    }
    public async Task<Product> UpdateProduct(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        return product;
    }
    public async Task DeleteProduct(Guid id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product is null)
        {
            throw new NotFoundException("Product not found");
        }
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
    }
}