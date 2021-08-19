using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using meus_produtos.Models;
using meus_produtos.Data;
using Microsoft.AspNetCore.Http;
using meus_produtos.Services;
using Microsoft.AspNetCore.Authorization;

namespace meus_produtos.Controllers
{
  [ApiController]
  [Route("api/v1/users")]
  public class UserController : ControllerBase
  {
    IUserRepository userRepository;
    public UserController(IUserRepository userRepository)
    {
      this.userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Login([FromBody] User user)
    {
      User loggedUser = await userRepository.GetUserEmail(user.Email);

      if (BCrypt.Net.BCrypt.Verify(user.Password, loggedUser.Password) == false)
      {
        return NotFound("Usuário ou senha inválido");
      }

      var token = TokenService.GenerateToken(loggedUser);

      return new
      {
        loggedUser = loggedUser,
        token = token
      };
    }

    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
      try
      {
        return Ok(await userRepository.GetUsers());
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao recuperar dados");
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      try
      {
        var result = await userRepository.GetUser(id);

        if (result == null)
        {
          return NotFound($"Usuário com o id {id} não encontado");
        }

        return result;

      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
          "Erro ao recuperar dados");
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<User>> AddUser(User user)
    {
      try
      {
        if (user == null)
        {
          return BadRequest();
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        var createdUser = await userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUser),
        new { id = createdUser.Id }, createdUser);
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao adicionar dados");
      }
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<ActionResult> DeleteUser(int id)
    {
      try
      {
        var userToDelete = await userRepository.GetUser(id);

        if (userToDelete == null)
        {
          return NotFound($"Usuário com id {id} não encontrado!");
        }

        await userRepository.DeleteUser(id);
        return Ok($"Usuário com id {id} deletado");
      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao deletar dados");
      }
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
      try
      {
        if (id != user.Id)
        {
          return BadRequest("Ids de usuário inconsistentes");
        }

        var userToUpdate = await userRepository.GetUser(id);

        if (userToUpdate == null)
        {
          return NotFound($"Uuário com o ID {user.Id} não encontado");
        }

        return await userRepository.UpdateUser(user);

      }
      catch (System.Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError,
            "Erro ao atualizar dados");
      }
    }
  }
}