using FromScratch.Models;

namespace FromScratch.DTOs;

public class ProductDTO
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }

    public static ProductDTO FromProduct(Product product)
    {
        return new ProductDTO
        {
            Name = product.Name,
            Price = product.Price
        };
    }
}