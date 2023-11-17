using SangueDeValor.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SangueDeValor.Aplicacao.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome do produto não pode ser nulo.")]
    [MaxLength(50)]
    [DisplayName("Nome")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Preço do produto não pode ser nulo.")]
    [Column(TypeName = "decimal(10, 2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Preço")]
    public decimal Preco { get; set; }
    [Required(ErrorMessage = "Imagem não pode ser nulo.")]
    [MaxLength(250)]
    [DisplayName("Imagem")]
    public string Imagem { get; set; }
    [JsonIgnore]
    public Parceiro? Parceiro { get; set; }
    [DisplayName("Parceiro")]
    public int ParceiroId { get; set; }
}
