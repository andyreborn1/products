using Microsoft.EntityFrameworkCore;
using meus_produtos.Models;

namespace meus_produtos.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>().HasData(new User
      {
        Id = 1,
        Name = "Anderson Vinicius",
        Email = "andy@gmail.com",
        Password = "1234578"
      });

      modelBuilder.Entity<User>().HasData(new User
      {
        Id = 2,
        Name = "Bruno Josep",
        Email = "bruno@gmail.com",
        Password = "67897845"
      });

      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 1,
        Name = "Borracha",
        Value = 0.50M,
        Status = true
      });

      modelBuilder.Entity<Product>().HasData(new Product
      {
        Id = 2,
        Name = "Lápis",
        Value = 0.90M,
        Status = false
      });
    }
  }
}