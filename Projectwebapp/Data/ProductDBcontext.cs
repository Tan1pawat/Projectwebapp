using Projectwebapp.Models;
using Microsoft.EntityFrameworkCore;

public class ProductDBcontext : DbContext
{
    public ProductDBcontext(DbContextOptions<ProductDBcontext> options) : base(options)
    {
    }

    public DbSet<Sender> Sender { get; set; }
}
