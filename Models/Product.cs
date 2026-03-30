namespace FromScratch.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    
    public Product(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    protected Product()
    {
    }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}