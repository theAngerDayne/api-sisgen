using Microsoft.EntityFrameworkCore.Migrations;

namespace api_sisgen.Migrations
{
    public partial class Eliminonumerolineaendetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroLinDet",
                table: "Detalles");

            migrationBuilder.AddColumn<int>(
                name: "BoletaId",
                table: "Detalles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_BoletaId",
                table: "Detalles",
                column: "BoletaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Boletas_BoletaId",
                table: "Detalles",
                column: "BoletaId",
                principalTable: "Boletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Boletas_BoletaId",
                table: "Detalles");

            migrationBuilder.DropIndex(
                name: "IX_Detalles_BoletaId",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "BoletaId",
                table: "Detalles");

            migrationBuilder.AddColumn<int>(
                name: "NroLinDet",
                table: "Detalles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
