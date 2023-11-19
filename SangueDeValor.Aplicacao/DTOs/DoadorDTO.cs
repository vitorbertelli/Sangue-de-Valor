using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SangueDeValor.Aplicacao.DTOs;

public class DoadorDTO
{
    public int Id { get; private set; }
    [Required(ErrorMessage = "Nome completo não pode ser nulo.")]
    [MaxLength(100)]
    [DisplayName("Nome Completo")]
    public string NomeCompleto { get; private set; }
    [Required(ErrorMessage = "Email não pode ser nulo.")]
    [MaxLength(250)]
    [DisplayName("Email")]
    public string Email { get; private set; }
    [Required(ErrorMessage = "Senha não pode ser nulo.")]
    [MaxLength(250)]
    [DisplayName("Senha")]
    public string Senha { get; private set; }
    [Required(ErrorMessage = "Tipo Sanguineo não pode ser nulo.")]
    [DisplayName("Tipo Sanguineo")]
    public int TipoSanguineo { get; private set; }
    [Required(ErrorMessage = "Peso não pode ser nulo.")]
    [Column(TypeName = "decimal(5, 1)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Peso")]
    public decimal Peso { get; private set; }
    public DateTime? UltimaDoacao { get; private set; }
    public int? Pontos { get; private set; }
    [MaxLength(250)]
    public string? Imagem { get; private set; }
}
