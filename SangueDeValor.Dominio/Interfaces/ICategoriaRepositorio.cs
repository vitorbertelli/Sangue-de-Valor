using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Dominio.Interfaces;

public interface ICategoriaRepositorio
{
    Task<IEnumerable<Categoria>> GetCategorias();
    Task<Categoria> GetCategoriaPorId(int? id);
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria> Remove(Categoria categoria);
}
