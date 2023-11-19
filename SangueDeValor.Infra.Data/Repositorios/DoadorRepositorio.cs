using Microsoft.EntityFrameworkCore;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;

namespace SangueDeValor.Infra.Data.Repositorios;

public class DoadorRepositorio : IDoadorRepositorio
{
    AppDbContext _doadorContext;

    public DoadorRepositorio(AppDbContext doadorContext)
    {
        _doadorContext = doadorContext;
    }

    public async Task<Doador> Create(Doador doador)
    {
        _doadorContext.Add(doador);
        await _doadorContext.SaveChangesAsync();
        return doador;
    }

    public async Task<Doador> GetDoador(int? id)
    {
        return await _doadorContext.Doadores.FindAsync(id);
    }

    public async Task<Doador> GetDoador(string? email)
    {
        return await _doadorContext.Doadores.FirstOrDefaultAsync(d => d.Email == email);
    }

    public async Task<Doador> Remove(Doador doador)
    {
        _doadorContext.Remove(doador);
        await _doadorContext.SaveChangesAsync();
        return doador;
    }
}
