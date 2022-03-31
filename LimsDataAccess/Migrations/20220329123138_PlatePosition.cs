using Microsoft.EntityFrameworkCore.Migrations;

namespace LimsDataAccess.Migrations
{
    public partial class PlatePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElisaPlatePosition",
                table: "Test",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElisaPlatePosition",
                table: "Test");
        }
    }
}
