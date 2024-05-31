using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConectaBairro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LimiteParticipantes = table.Column<int>(type: "int", nullable: false),
                    ValorIngresso = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evento_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_evento_usuario_UserId",
                        column: x => x.UserId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Atividades físicas e competições recreativas.", "Esportivo" },
                    { 2, "Diversão e lazer para todos os gostos.", "Entreterimento" },
                    { 3, "Exploração da arte, história e tradições.", "Cultaral" },
                    { 4, "Eventos voltados para negócios.", "Corporativo" },
                    { 5, "Práticas e celebrações voltadas para a religião.", "Religioso" },
                    { 7, "Eventos voltados para educação", "Educacional" },
                    { 8, "Eventos relacionados a organizações e instituições.", "Institucional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_evento_CategoriaId",
                table: "evento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_evento_UserId",
                table: "evento",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
