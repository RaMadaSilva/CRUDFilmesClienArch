using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroFilmes.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    DurationsInMinute = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Realizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmeRealizador",
                columns: table => new
                {
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RealizadorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeRealizador", x => new { x.FilmeId, x.RealizadorId });
                    table.ForeignKey(
                        name: "FK_FilmeRealizador_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FilmeRealizador_Realizador_RealizadorId",
                        column: x => x.RealizadorId,
                        principalTable: "Realizador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeRealizador_RealizadorId",
                table: "FilmeRealizador",
                column: "RealizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeRealizador");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Realizador");
        }
    }
}
