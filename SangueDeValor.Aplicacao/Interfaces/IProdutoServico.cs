using SangueDeValor.Aplicacao.DTOs;

namespace SangueDeValor.Aplicacao.Interfaces;

public interface IProdutoServico
{
    Task<IEnumerable<ProdutoDTO>> GetProdutos();
    Task<IEnumerable<ProdutoDTO>> GetProdutosPorParceiro(int? parceiroId);
    Task<ProdutoDTO> GetProdutoPorId(int? id);
    Task Create(ProdutoDTO produtoDTO);
    Task Remove(int? id);
}
