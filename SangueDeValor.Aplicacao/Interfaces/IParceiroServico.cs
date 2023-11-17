using SangueDeValor.Aplicacao.DTOs;

namespace SangueDeValor.Aplicacao.Interfaces;

public interface IParceiroServico
{
    Task<IEnumerable<ParceiroDTO>> GetParceiros();
    Task<IEnumerable<ParceiroDTO>> GetParceirosPorCategoria(int? categoriaId);
    Task<ParceiroDTO> GetParceiroPorId(int? id);
    Task Create(ParceiroDTO parceiroDTO);
    Task Remove(int? id);
}
