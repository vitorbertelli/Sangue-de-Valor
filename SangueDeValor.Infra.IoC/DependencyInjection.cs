using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Aplicacao.Mapeamentos;
using SangueDeValor.Aplicacao.Servicos;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;
using SangueDeValor.Infra.Data.Repositorios;

namespace SangueDeValor.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

        services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        services.AddScoped<IParceiroRepositorio, ParceiroRepositorio>();
        services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

        services.AddScoped<ICategoriaServico, CategoriaServico>();
        services.AddScoped<IParceiroServico, ParceiroServico>();
        services.AddScoped<IProdutoServico, ProdutoServico>();
        services.AddAutoMapper(typeof(MapeamentoProfile));

        return services;
    }
}
