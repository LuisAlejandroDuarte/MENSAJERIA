using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensajeria.RepositoryEFCore.Migrations
{
    public partial class AddFieldEstadoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuarios");
        }
    }
}
