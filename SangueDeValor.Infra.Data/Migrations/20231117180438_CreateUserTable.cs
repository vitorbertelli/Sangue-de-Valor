using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SangueDeValor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoSanguineo = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: false),
                    UltimaDoacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pontos = table.Column<int>(type: "int", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doadores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Doadores",
                columns: new[] { "Id", "Email", "Imagem", "NomeCompleto", "Peso", "Pontos", "Senha", "TipoSanguineo", "UltimaDoacao" },
                values: new object[,]
                {
                    { 1, "vitor@gmail.com", "https://revolucaonerd.com/wordpress/wp-content/files/revolucaonerd.com/2023/06/henry-cavill-1024x683.webp", "Vitor Bertelli do Prado", 52.5m, 77, "Senha@2023", 2, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "alexandresilva@hotmail.com", "https://jornaltribuna.com.br/wp-content/uploads/2022/05/1a2948a0-d1d3-4b5f-b105-fd58a0fc0ddb-1-1068x1602.jpg", "Alexandre Silva", 73m, 67, "Senha@2023", 1, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "lukeskywalker@forca.com", "https://lumiere-a.akamaihd.net/v1/images/luke-skywalker-main_7ffe21c7.jpeg?region=130%2C147%2C1417%2C796", "Luke Skywalker", 65m, 14500, "Senha@2023", 7, new DateTime(2017, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doadores_Email",
                table: "Doadores",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doadores");
        }
    }
}
