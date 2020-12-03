using Microsoft.EntityFrameworkCore.Migrations;

namespace api_sisgen.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleBoletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NmbItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnmdItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyItem = table.Column<int>(type: "int", nullable: false),
                    PrcItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BoletaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleBoletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleBoletas_Boletas_BoletaId",
                        column: x => x.BoletaId,
                        principalTable: "Boletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Encabezado",
                columns: table => new
                {
                    BoletaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encabezado", x => x.BoletaId);
                    table.ForeignKey(
                        name: "FK_Encabezado_Boletas_BoletaId",
                        column: x => x.BoletaId,
                        principalTable: "Boletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emisor",
                columns: table => new
                {
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    RUTEmisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RznSoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiroEmis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acteco = table.Column<int>(type: "int", nullable: false),
                    CdgSIISucur = table.Column<int>(type: "int", nullable: false),
                    DirOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmnaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emisor", x => x.EncabezadoId);
                    table.ForeignKey(
                        name: "FK_Emisor_Encabezado_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "Encabezado",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdDoc",
                columns: table => new
                {
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    TipoDTE = table.Column<int>(type: "int", nullable: false),
                    Folio = table.Column<int>(type: "int", nullable: false),
                    FchEmis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndServicio = table.Column<int>(type: "int", nullable: false),
                    IndMntNeto = table.Column<int>(type: "int", nullable: false),
                    PeriodoDesde = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodoHasta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FchVenc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdDoc", x => x.EncabezadoId);
                    table.ForeignKey(
                        name: "FK_IdDoc_Encabezado_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "Encabezado",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptor",
                columns: table => new
                {
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    RUTRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CdgIntRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RznSocRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmnaRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadRecep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CmnaPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadPostal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptor", x => x.EncabezadoId);
                    table.ForeignKey(
                        name: "FK_Receptor_Encabezado_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "Encabezado",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Totales",
                columns: table => new
                {
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    MntNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MntExe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MntTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Totales", x => x.EncabezadoId);
                    table.ForeignKey(
                        name: "FK_Totales_Encabezado_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "Encabezado",
                        principalColumn: "BoletaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleBoletas_BoletaId",
                table: "DetalleBoletas",
                column: "BoletaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleBoletas");

            migrationBuilder.DropTable(
                name: "Emisor");

            migrationBuilder.DropTable(
                name: "IdDoc");

            migrationBuilder.DropTable(
                name: "Receptor");

            migrationBuilder.DropTable(
                name: "Totales");

            migrationBuilder.DropTable(
                name: "Encabezado");

            migrationBuilder.DropTable(
                name: "Boletas");
        }
    }
}
