using System.ComponentModel.DataAnnotations;

namespace meus_produtos.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
    [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
    [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
    public string Password { get; set; }
  }
}