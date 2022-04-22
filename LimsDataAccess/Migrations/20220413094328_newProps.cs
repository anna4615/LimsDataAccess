using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LimsDataAccess.Migrations
{
    public partial class newProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Concentration",
                table: "Test",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MeasureValue",
                table: "Test",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFinished",
                table: "Elisa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concentration",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "MeasureValue",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "DateFinished",
                table: "Elisa");
        }
    }
}
