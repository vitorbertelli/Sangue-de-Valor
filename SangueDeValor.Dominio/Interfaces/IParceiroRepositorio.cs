using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Dominio.Interfaces;

public interface IParceiroRepositorio
{
    Task<IEnumerable<Parceiro>> GetParceiros();
    Task<IEnumerable<Parceiro>> GetParceirosPorCategoria(int? categoriaId);
    Task<Parceiro> GetParceiroPorId(int? id);
    Task<Parceiro> Create(Parceiro parceiro);
    Task<Parceiro> Remove(Parceiro parceiro);
}
