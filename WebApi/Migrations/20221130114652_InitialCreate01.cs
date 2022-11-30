using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinuteTypeId",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "StopTime",
                table: "Processes",
                newName: "EndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Processes",
                newName: "StopTime");

            migrationBuilder.AddColumn<int>(
                name: "MinuteTypeId",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
