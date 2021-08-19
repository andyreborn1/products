using System.Threading.Tasks;
using System.Collections.Generic;
using meus_produtos.Models;

namespace meus_produtos.Data
{
  public interface IUserRepository
  {
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> GetUserEmail(string email);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task DeleteUser(int id);
  }
}