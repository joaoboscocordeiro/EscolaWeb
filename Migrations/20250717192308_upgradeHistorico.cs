using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaWeb.Migrations
{
    /// <inheritdoc />
    public partial class upgradeHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Falta",
                table: "Historicos",
                newName: "Faltas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Faltas",
                table: "Historicos",
                newName: "Falta");
        }
    }
}
