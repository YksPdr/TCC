using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConectaBairro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipo_conta",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tipo de conta baseado no ENUM da aplicação: 0 para organizador, 1 para Munícipe")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoContaId = table.Column<byte>(type: "tinyint", nullable: false),
                    Foto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PasswordSalt = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_tipo_conta_TipoContaId",
                        column: x => x.TipoContaId,
                        principalTable: "tipo_conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tipo_conta",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { (byte)1, "Organizador" },
                    { (byte)2, "Municipe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_TipoContaId",
                table: "usuario",
                column: "TipoContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tipo_conta");
        }
    }
}
