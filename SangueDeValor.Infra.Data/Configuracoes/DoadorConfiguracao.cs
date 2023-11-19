using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SangueDeValor.Dominio.Entidades;
using SangueDeValor.Dominio.Enumeradores;

namespace SangueDeValor.Infra.Data.Configuracoes;

public class DoadorConfiguracao : IEntityTypeConfiguration<Doador>
{
    public void Configure(EntityTypeBuilder<Doador> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.NomeCompleto).HasMaxLength(100).IsRequired(true);
        builder.Property(d => d.Email).HasMaxLength(250).IsRequired(true);
        builder.Property(d => d.Senha).HasMaxLength(250).IsRequired(true);
        builder.Property(d => d.TipoSanguineo).HasConversion<int>().IsRequired(true);
        builder.Property(d => d.Peso).HasPrecision(5, 1).IsRequired(true);
        builder.Property(d => d.UltimaDoacao).HasColumnType("datetime").IsRequired(false);
        builder.Property(d => d.Pontos).IsRequired(false);
        builder.Property(p => p.Imagem).HasMaxLength(250).IsRequired(false);
        builder.HasIndex(d => d.Email).IsUnique();

        builder.HasData(
            new Doador(1, "Vitor Bertelli do Prado", "vitor@gmail.com", "$2a$11$qezl/0Xs0HS0SnyMqtHuA.zAF32zxoas/WDjxu9LHAKm/N2iAYQeC", (TipoSanguineo)2, 52.5m, new DateTime(2023, 07, 21), 77, "https://revolucaonerd.com/wordpress/wp-content/files/revolucaonerd.com/2023/06/henry-cavill-1024x683.webp"),
            new Doador(2, "Alexandre Silva", "alexandresilva@hotmail.com", "$2a$11$qezl/0Xs0HS0SnyMqtHuA.zAF32zxoas/WDjxu9LHAKm/N2iAYQeC", (TipoSanguineo)1, 73, new DateTime(2022, 02, 07), 67, "https://jornaltribuna.com.br/wp-content/uploads/2022/05/1a2948a0-d1d3-4b5f-b105-fd58a0fc0ddb-1-1068x1602.jpg"),
            new Doador(3, "Luke Skywalker", "lukeskywalker@forca.com", "$2a$11$qezl/0Xs0HS0SnyMqtHuA.zAF32zxoas/WDjxu9LHAKm/N2iAYQeC", (TipoSanguineo)7, 65, new DateTime(2017, 12, 14), 14500, "https://lumiere-a.akamaihd.net/v1/images/luke-skywalker-main_7ffe21c7.jpeg?region=130%2C147%2C1417%2C796")
        );
    }
}
