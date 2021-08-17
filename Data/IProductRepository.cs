using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meus_produtos.Models;

namespace meus_produtos.Data
{
  public interface IProductRepository
  {
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(int id);
  }
}