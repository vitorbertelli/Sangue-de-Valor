using System.ComponentModel.DataAnnotations;

namespace SangueDeValor.Aplicacao.DTOs;

public class LoginDTO
{
    [Required, MaxLength(250), EmailAddress]
    public string Email { get; set; }
    [Required, MaxLength(250), DataType(DataType.Password)]
    public string Senha { get; set; }
}
