using System.ComponentModel.DataAnnotations;

namespace meus_produtos.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
    [MaxLength(80, ErrorMessage = "Máximo 20 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public bool Status { get; set; }
  }
}