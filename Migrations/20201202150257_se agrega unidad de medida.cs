using Microsoft.EntityFrameworkCore.Migrations;

namespace api_sisgen.Migrations
{
    public partial class seagregaunidaddemedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnmdItem",
                table: "Detalles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnmdItem",
                table: "Detalles");
        }
    }
}
