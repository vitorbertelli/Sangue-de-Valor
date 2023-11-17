using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Infra.Data.Configuracoes;

public class CategoriaConfiguracao : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();

        builder.HasData(
            new Categoria(1, "Farmácia"),
            new Categoria(2, "Mercado"),
            new Categoria(3, "Lanches")
        );
    }
}
