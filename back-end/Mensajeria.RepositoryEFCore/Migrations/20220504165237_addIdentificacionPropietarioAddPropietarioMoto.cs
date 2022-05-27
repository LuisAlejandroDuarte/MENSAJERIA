using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensajeria.RepositoryEFCore.Migrations
{
    public partial class addIdentificacionPropietarioAddPropietarioMoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Propietarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_EmpresaId",
                table: "Propietarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_PropietarioId",
                table: "Motos",
                column: "PropietarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Propietarios_PropietarioId",
                table: "Motos",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propietarios_Empresas_EmpresaId",
                table: "Propietarios",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Propietarios_PropietarioId",
                table: "Motos");

            migrationBuilder.DropForeignKey(
                name: "FK_Propietarios_Empresas_EmpresaId",
                table: "Propietarios");

            migrationBuilder.DropIndex(
                name: "IX_Propietarios_EmpresaId",
                table: "Propietarios");

            migrationBuilder.DropIndex(
                name: "IX_Motos_PropietarioId",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Propietarios");
        }
    }
}
