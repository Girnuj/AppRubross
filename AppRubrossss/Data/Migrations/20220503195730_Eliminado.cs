using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppRubrossss.Data.Migrations
{
    public partial class Eliminado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Rubro",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Rubro");
        }
    }
}
