using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Dominio.Interfaces;

public interface IProdutoRepositorio
{
    Task<IEnumerable<Produto>> GetProdutos();
    Task<IEnumerable<Produto>> GetProdutosPorParceiro(int? parceiroId);
    Task<Produto> GetProdutoPorId(int? id);
    Task<Produto> Create(Produto produto);
    Task<Produto> Remove(Produto produto);
}
