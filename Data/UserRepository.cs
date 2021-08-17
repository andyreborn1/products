using System.Collections.Generic;
using System.Threading.Tasks;
using meus_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace meus_produtos.Data
{
  public class UserRepository : IUserRepository
  {
    DataContext dataContext;

    public UserRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task<User> AddUser(User user)
    {
      var result = await dataContext.Users.AddAsync(user);
      await dataContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task DeleteUser(string email)
    {
      var result = await dataContext.Users
      .FirstOrDefaultAsync(u => u.Email == email);

      if (result != null)
      {
        dataContext.Users.Remove(result);
        await dataContext.SaveChangesAsync();
      }
    }

    public async Task<User> GetUser(string email)
    {
      return await dataContext.Users
      .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      return await dataContext.Users.ToListAsync();
    }

    public async Task<User> UpdateUser(User user)
    {
      var result = await dataContext.Users
      .FirstOrDefaultAsync(u => u.Email == user.Email);

      if (result != null)
      {
        result.Name = user.Name;
        result.Email = user.Email;
        result.Password = user.Password;

        await dataContext.SaveChangesAsync();
        return result;
      }
      return null;
    }
  }
}