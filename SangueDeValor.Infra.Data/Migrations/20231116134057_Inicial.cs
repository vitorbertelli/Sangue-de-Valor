using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SangueDeValor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Imagem = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parceiros_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParceiroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Farmácia" },
                    { 2, "Mercado" },
                    { 3, "Lanches" }
                });

            migrationBuilder.InsertData(
                table: "Parceiros",
                columns: new[] { "Id", "CategoriaId", "Imagem", "NomeFantasia" },
                values: new object[,]
                {
                    { 1, 3, "https://lh3.googleusercontent.com/p/AF1QipPEcq-e-X8sinM_d3skDFfnchqMDIhBmIdxCf6g=w1080-h608-p-no-v0", "Vila do Açaí" },
                    { 2, 1, "https://cuponomia-a.akamaihd.net/img/stores/medium/drogasil.png?v4", "Drogasil" },
                    { 3, 2, "https://hortifruti.com.br/logo-hortifruti-eBB.svg", "Hortifruti" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Imagem", "Nome", "ParceiroId", "Preco" },
                values: new object[,]
                {
                    { 1, "https://contatei.com.br/img/bancodeimagens/acai/acai-copo.jpg?v=198", "Açaí 500ml", 1, 15.5m },
                    { 2, "https://cdn-cosmos.bluesoft.com.br/products/7896226501239", "Rivotril 2,5mg/ml", 2, 35.9m },
                    { 3, "https://cdn.shoppub.io/cdn-cgi/image/w=1000,h=1000,q=80,f=auto/cenourao/media/uploads/produtos/foto/67dc8df0dbe6file.png", "Penca de banana", 3, 10.9m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parceiros_CategoriaId",
                table: "Parceiros",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ParceiroId",
                table: "Produtos",
                column: "ParceiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Parceiros");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
