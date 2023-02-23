using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_MinuteSets_MinuteSetId",
                table: "Processes");

            migrationBuilder.DropTable(
                name: "MinuteSets");

            migrationBuilder.DropIndex(
                name: "IX_Processes_MinuteSetId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "MinuteSetId",
                table: "Processes",
                newName: "MinuteSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinuteSet",
                table: "Processes",
                newName: "MinuteSetId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Processes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MinuteSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinuteSets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_MinuteSetId",
                table: "Processes",
                column: "MinuteSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_MinuteSets_MinuteSetId",
                table: "Processes",
                column: "MinuteSetId",
                principalTable: "MinuteSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
