using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SangueDeValor.Aplicacao.Interfaces;
using SangueDeValor.Aplicacao.Mapeamentos;
using SangueDeValor.Aplicacao.Servicos;
using SangueDeValor.Dominio.Account;
using SangueDeValor.Dominio.Interfaces;
using SangueDeValor.Infra.Data.Context;
using SangueDeValor.Infra.Data.Identity;
using SangueDeValor.Infra.Data.Repositorios;
using System.Text;

namespace SangueDeValor.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

        services.AddScoped<IAuthenticate, AuthenticateService>();

        services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
        services.AddScoped<IParceiroRepositorio, ParceiroRepositorio>();
        services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
        services.AddScoped<IDoadorRepositorio, DoadorRepositorio>();

        services.AddScoped<ICategoriaServico, CategoriaServico>();
        services.AddScoped<IParceiroServico, ParceiroServico>();
        services.AddScoped<IProdutoServico, ProdutoServico>();
        services.AddScoped<IDoadorServico, DoadorServico>();
        services.AddScoped<IAutenticacaoServico, AutenticacaoServico>();
        services.AddAutoMapper(typeof(MapeamentoProfile));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f43gds5gT")),
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}
