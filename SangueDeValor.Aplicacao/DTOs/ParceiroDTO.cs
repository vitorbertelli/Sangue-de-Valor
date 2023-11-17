using SangueDeValor.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SangueDeValor.Aplicacao.DTOs;

public class ParceiroDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Nome fantasia não pode ser nulo.")]
    [MaxLength(100)]
    [DisplayName("Nome Fantasia")]
    public string NomeFantasia { get; set; }
    [Required(ErrorMessage = "Imagem não pode ser nulo.")]
    [MaxLength(250)]
    [DisplayName("Imagem")]
    public string Imagem { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
    [Required(ErrorMessage = "CategoriaId é obrigatório.")]
    [DisplayName("Categoria")]
    public int CategoriaId { get; set; }
}
