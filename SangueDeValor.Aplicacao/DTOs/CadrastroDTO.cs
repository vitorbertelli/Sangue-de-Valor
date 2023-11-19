using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SangueDeValor.API.Models;

public class CadastroDTO
{
    [Required, MaxLength(100), DisplayName("Nome Completo")]
    public string NomeCompleto { get; set; }
    [Required, EmailAddress, MaxLength(250), DisplayName("E-mail")]
    public string Email { get; set; }
    [Required, DataType(DataType.Password), MaxLength(250), DisplayName("Senha")]
    public string Senha { get; set; }
    [Required, DataType(DataType.Password), Compare("Senha"), MaxLength(250), DisplayName("Confirmar Senha")]
    public string ConfirmarSenha { get; set; }
    [Required, DisplayName("Tipo Sanguineo")]
    public int TipoSanguineo { get; set; }
    [Required, Column(TypeName = "decimal(4, 1)"), DisplayFormat(DataFormatString = "{0:C2}"), DataType(DataType.Currency), DisplayName("Peso")]
    public decimal Peso { get; set; }
}
