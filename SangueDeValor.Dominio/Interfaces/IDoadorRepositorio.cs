using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Dominio.Interfaces;

public interface IDoadorRepositorio
{
    Task<Doador> GetDoador(int? id);
    Task<Doador> GetDoador(string? email);
    Task<Doador> Create(Doador doador);
    Task<Doador> Remove(Doador doador);
}
