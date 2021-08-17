using System.Collections.Generic;
using System.Threading.Tasks;
using meus_produtos.Models;

namespace meus_produtos.Data
{
  public class UserRepository : IUserRepository
  {
    public Task<User> AddUser(User user)
    {
      throw new System.NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
      throw new System.NotImplementedException();
    }

    public Task<User> GetUser(string email)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
      throw new System.NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
      throw new System.NotImplementedException();
    }
  }
}