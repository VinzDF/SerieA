using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerieA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campionato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCampionato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campionato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squadra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampionatoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squadra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squadra_Campionato_CampionatoId",
                        column: x => x.CampionatoId,
                        principalTable: "Campionato",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calciatore",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroMaglia = table.Column<int>(type: "int", nullable: false),
                    SquadraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calciatore", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calciatore_Squadra_SquadraId",
                        column: x => x.SquadraId,
                        principalTable: "Squadra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calciatore_SquadraId",
                table: "Calciatore",
                column: "SquadraId");

            migrationBuilder.CreateIndex(
                name: "IX_Squadra_CampionatoId",
                table: "Squadra",
                column: "CampionatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calciatore");

            migrationBuilder.DropTable(
                name: "Squadra");

            migrationBuilder.DropTable(
                name: "Campionato");
        }
    }
}
