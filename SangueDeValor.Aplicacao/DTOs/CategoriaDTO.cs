using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SangueDeValor.Aplicacao.DTOs;

public class CategoriaDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome da categoria não pode ser nulo.")]
    [MaxLength(50)]
    [DisplayName("Nome")]
    public string Nome { get; set; }
}
