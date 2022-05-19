using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRubrossss.Data.Migrations
{
    public partial class _1Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    RubroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.RubroID);
                });

            migrationBuilder.CreateTable(
                name: "SubRubro",
                columns: table => new
                {
                    SubrubroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RubroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRubro", x => x.SubrubroID);
                    table.ForeignKey(
                        name: "FK_SubRubro_Rubro_RubroID",
                        column: x => x.RubroID,
                        principalTable: "Rubro",
                        principalColumn: "RubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltAct = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentajeGanancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubrubroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticuloID);
                    table.ForeignKey(
                        name: "FK_Articulo_SubRubro_SubrubroID",
                        column: x => x.SubrubroID,
                        principalTable: "SubRubro",
                        principalColumn: "SubrubroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_SubrubroID",
                table: "Articulo",
                column: "SubrubroID");

            migrationBuilder.CreateIndex(
                name: "IX_SubRubro_RubroID",
                table: "SubRubro",
                column: "RubroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "SubRubro");

            migrationBuilder.DropTable(
                name: "Rubro");
        }
    }
}
