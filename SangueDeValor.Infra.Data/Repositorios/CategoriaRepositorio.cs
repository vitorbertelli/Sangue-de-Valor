using Microsoft.EntityFrameworkCore;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;

namespace SangueDeValor.Infra.Data.Repositorios;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    AppDbContext _categoriaContext;

    public CategoriaRepositorio(AppDbContext categoriaContext)
    {
        _categoriaContext = categoriaContext;
    }

    public async Task<Categoria> Create(Categoria categoria)
    {
        _categoriaContext.Add(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> GetCategoriaPorId(int? id)
    {
        return await _categoriaContext.Categorias.FindAsync(id);
    }

    public async Task<IEnumerable<Categoria>> GetCategorias()
    {
        return await _categoriaContext.Categorias.ToListAsync();
    }

    public async Task<Categoria> Remove(Categoria categoria)
    {
        _categoriaContext.Remove(categoria);
        await _categoriaContext.SaveChangesAsync();
        return categoria;
    }
}
