using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Aplicacao.Interfaces;

public interface IDoadorServico
{
    Task<DoadorDTO> GetDoador(int? id);
    Task<DoadorDTO> GetDoador(string? email);
    Task Remove(int? id);
}
