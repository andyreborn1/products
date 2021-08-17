using System.Collections.Generic;
using System.Threading.Tasks;
using meus_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace meus_produtos.Data
{
  public class ProductRepository : IProductRepository
  {
    private readonly DataContext dataContext;

    public ProductRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }
    public async Task<Product> AddProduct(Product product)
    {
      var result = await dataContext.Products.AddAsync(product);
      await dataContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task DeleteProduct(int id)
    {
      var result = await dataContext.Products
      .FirstOrDefaultAsync(p => p.Id == id);

      if (result != null)
      {
        dataContext.Products.Remove(result);
        await dataContext.SaveChangesAsync();
      }
    }

    public async Task<Product> GetProduct(int id)
    {
      return await dataContext.Products
      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
      return await dataContext.Products.ToListAsync();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
      var result = await dataContext.Products
        .FirstOrDefaultAsync(p => p.Id == product.Id);

      if (result != null)
      {
        result.Name = product.Name;
        result.Value = product.Value;
        result.Status = product.Status;

        await dataContext.SaveChangesAsync();
        return result;
      }
      return null;

    }
  }
}