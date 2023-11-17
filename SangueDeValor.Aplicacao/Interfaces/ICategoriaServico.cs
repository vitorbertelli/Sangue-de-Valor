using SangueDeValor.Aplicacao.DTOs;
using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Aplicacao.Interfaces;

public interface ICategoriaServico
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO> GetCategoriaPorId(int? id);
    Task Create(CategoriaDTO categoriaDTO);
    Task Remove(int? id);
}
