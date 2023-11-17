using Microsoft.EntityFrameworkCore;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;

namespace SangueDeValor.Infra.Data.Repositorios;

public class ParceiroRepositorio : IParceiroRepositorio
{
    AppDbContext _parceiroContext;

    public ParceiroRepositorio(AppDbContext parceiroContext)
    {
        _parceiroContext = parceiroContext;
    }

    public async Task<Parceiro> Create(Parceiro parceiro)
    {
        _parceiroContext.Add(parceiro);
        await _parceiroContext.SaveChangesAsync();
        return parceiro;
    }

    public async Task<Parceiro> GetParceiroPorId(int? id)
    {
        return await _parceiroContext.Parceiros.FindAsync(id);
    }

    public async Task<IEnumerable<Parceiro>> GetParceiros()
    {
        return await _parceiroContext.Parceiros.ToListAsync();
    }

    public async Task<IEnumerable<Parceiro>> GetParceirosPorCategoria(int? categoriaId)
    {
        return await _parceiroContext.Parceiros.Where(p => p.CategoriaId == categoriaId).ToListAsync();
    }

    public async Task<Parceiro> Remove(Parceiro parceiro)
    {
        _parceiroContext.Remove(parceiro);
        await _parceiroContext.SaveChangesAsync();
        return parceiro;
    }
}
