using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mensajeria.RepositoryEFCore.Migrations
{
    public partial class addRelationshipTurnoRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MotoId",
                table: "Turnos",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_TurnoId",
                table: "Rutas",
                column: "TurnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Turnos_TurnoId",
                table: "Rutas",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Motos_MotoId",
                table: "Turnos",
                column: "MotoId",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Turnos_TurnoId",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Motos_MotoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_MotoId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Rutas_TurnoId",
                table: "Rutas");
        }
    }
}
