using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Infra.Data.Configuracoes;

public class ParceiroConfiguracao : IEntityTypeConfiguration<Parceiro>
{
    public void Configure(EntityTypeBuilder<Parceiro> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.NomeFantasia).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Imagem).HasMaxLength(250).IsRequired();

        builder.HasOne(p => p.Categoria).WithMany(c => c.Parceiros).HasForeignKey(p => p.CategoriaId);

        builder.HasData(
            new Parceiro(1, 3, "Vila do Açaí", "https://lh3.googleusercontent.com/p/AF1QipPEcq-e-X8sinM_d3skDFfnchqMDIhBmIdxCf6g=w1080-h608-p-no-v0"),
            new Parceiro(2, 1, "Drogasil", "https://cuponomia-a.akamaihd.net/img/stores/medium/drogasil.png?v4"),
            new Parceiro(3, 2, "Hortifruti", "https://hortifruti.com.br/logo-hortifruti-eBB.svg")
        );
    }
}
