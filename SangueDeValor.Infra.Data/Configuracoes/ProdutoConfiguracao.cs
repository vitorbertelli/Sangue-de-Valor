using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SangueDeValor.Dominio.Entidades;

namespace SangueDeValor.Infra.Data.Configuracoes;

public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Preco).HasPrecision(10, 2).IsRequired();
        builder.Property(p => p.Imagem).HasMaxLength(250).IsRequired();

        builder.HasOne(p => p.Parceiro).WithMany(p => p.Produtos).HasForeignKey(p => p.ParceiroId);

        builder.HasData(
            new Produto(1, 1, "Açaí 500ml", 15.5m, "https://contatei.com.br/img/bancodeimagens/acai/acai-copo.jpg?v=198"),
            new Produto(2, 2, "Rivotril 2,5mg/ml", 35.9m, "https://cdn-cosmos.bluesoft.com.br/products/7896226501239"),
            new Produto(3, 3, "Penca de banana", 10.9m, "https://cdn.shoppub.io/cdn-cgi/image/w=1000,h=1000,q=80,f=auto/cenourao/media/uploads/produtos/foto/67dc8df0dbe6file.png")
        );
    }
}
