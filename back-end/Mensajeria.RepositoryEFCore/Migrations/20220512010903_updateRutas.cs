using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensajeria.RepositoryEFCore.Migrations
{
    public partial class updateRutas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Rutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Rutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Rutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Rutas");
        }
    }
}
