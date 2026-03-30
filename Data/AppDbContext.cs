using FromScratch.Models;
using Microsoft.EntityFrameworkCore;

namespace FromScratch.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}