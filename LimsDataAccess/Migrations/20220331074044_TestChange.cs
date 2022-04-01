using Microsoft.EntityFrameworkCore.Migrations;

namespace LimsDataAccess.Migrations
{
    public partial class TestChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Elisa_ElisaId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "IhcId",
                table: "Test");

            migrationBuilder.AlterColumn<int>(
                name: "ElisaPlatePosition",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ElisaId",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Elisa_ElisaId",
                table: "Test",
                column: "ElisaId",
                principalTable: "Elisa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Elisa_ElisaId",
                table: "Test");

            migrationBuilder.AlterColumn<int>(
                name: "ElisaPlatePosition",
                table: "Test",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ElisaId",
                table: "Test",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IhcId",
                table: "Test",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Elisa_ElisaId",
                table: "Test",
                column: "ElisaId",
                principalTable: "Elisa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
