﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SangueDeValor.Infra.Data.Context;

#nullable disable

namespace SangueDeValor.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Farmácia"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Mercado"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Lanches"
                        });
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Doador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Imagem")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Peso")
                        .HasPrecision(5, 1)
                        .HasColumnType("decimal(5,1)");

                    b.Property<int?>("Pontos")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("TipoSanguineo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UltimaDoacao")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Doadores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "vitor@gmail.com",
                            Imagem = "https://revolucaonerd.com/wordpress/wp-content/files/revolucaonerd.com/2023/06/henry-cavill-1024x683.webp",
                            NomeCompleto = "Vitor Bertelli do Prado",
                            Peso = 52.5m,
                            Pontos = 77,
                            Senha = "Senha@2023",
                            TipoSanguineo = 2,
                            UltimaDoacao = new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Email = "alexandresilva@hotmail.com",
                            Imagem = "https://jornaltribuna.com.br/wp-content/uploads/2022/05/1a2948a0-d1d3-4b5f-b105-fd58a0fc0ddb-1-1068x1602.jpg",
                            NomeCompleto = "Alexandre Silva",
                            Peso = 73m,
                            Pontos = 67,
                            Senha = "Senha@2023",
                            TipoSanguineo = 1,
                            UltimaDoacao = new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Email = "lukeskywalker@forca.com",
                            Imagem = "https://lumiere-a.akamaihd.net/v1/images/luke-skywalker-main_7ffe21c7.jpeg?region=130%2C147%2C1417%2C796",
                            NomeCompleto = "Luke Skywalker",
                            Peso = 65m,
                            Pontos = 14500,
                            Senha = "Senha@2023",
                            TipoSanguineo = 7,
                            UltimaDoacao = new DateTime(2017, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Parceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Parceiros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 3,
                            Imagem = "https://lh3.googleusercontent.com/p/AF1QipPEcq-e-X8sinM_d3skDFfnchqMDIhBmIdxCf6g=w1080-h608-p-no-v0",
                            NomeFantasia = "Vila do Açaí"
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            Imagem = "https://cuponomia-a.akamaihd.net/img/stores/medium/drogasil.png?v4",
                            NomeFantasia = "Drogasil"
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 2,
                            Imagem = "https://hortifruti.com.br/logo-hortifruti-eBB.svg",
                            NomeFantasia = "Hortifruti"
                        });
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ParceiroId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Imagem = "https://contatei.com.br/img/bancodeimagens/acai/acai-copo.jpg?v=198",
                            Nome = "Açaí 500ml",
                            ParceiroId = 1,
                            Preco = 15.5m
                        },
                        new
                        {
                            Id = 2,
                            Imagem = "https://cdn-cosmos.bluesoft.com.br/products/7896226501239",
                            Nome = "Rivotril 2,5mg/ml",
                            ParceiroId = 2,
                            Preco = 35.9m
                        },
                        new
                        {
                            Id = 3,
                            Imagem = "https://cdn.shoppub.io/cdn-cgi/image/w=1000,h=1000,q=80,f=auto/cenourao/media/uploads/produtos/foto/67dc8df0dbe6file.png",
                            Nome = "Penca de banana",
                            ParceiroId = 3,
                            Preco = 10.9m
                        });
                });

            modelBuilder.Entity("SangueDeValor.Infra.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SangueDeValor.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SangueDeValor.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SangueDeValor.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SangueDeValor.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Parceiro", b =>
                {
                    b.HasOne("SangueDeValor.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Parceiros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("SangueDeValor.Dominio.Entidades.Parceiro", "Parceiro")
                        .WithMany("Produtos")
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Categoria", b =>
                {
                    b.Navigation("Parceiros");
                });

            modelBuilder.Entity("SangueDeValor.Dominio.Entidades.Parceiro", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
