using Microsoft.EntityFrameworkCore;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;

namespace SangueDeValor.Infra.Data.Repositorios;

public class ProdutoRepositorio : IProdutoRepositorio
{
    AppDbContext _produtoContext;

    public ProdutoRepositorio(AppDbContext produtoContext)
    {
        _produtoContext = produtoContext;
    }

    public async Task<Produto> Create(Produto produto)
    {
        _produtoContext.Add(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> GetProdutoPorId(int? id)
    {
        return await _produtoContext.Produtos.FindAsync(id);
    }

    public async Task<IEnumerable<Produto>> GetProdutos()
    {
        return await _produtoContext.Produtos.ToListAsync();
    }

    public async Task<IEnumerable<Produto>> GetProdutosPorParceiro(int? parceiroId)
    {
        return await _produtoContext.Produtos.Where(p => p.ParceiroId == parceiroId).ToListAsync();
    }

    public async Task<Produto> Remove(Produto produto)
    {
        _produtoContext.Remove(produto);
        await _produtoContext.SaveChangesAsync();
        return produto;
    }
}
