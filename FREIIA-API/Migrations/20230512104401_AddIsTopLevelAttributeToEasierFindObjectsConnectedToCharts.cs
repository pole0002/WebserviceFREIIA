using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class AddIsTopLevelAttributeToEasierFindObjectsConnectedToCharts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTopLevel",
                table: "Participants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTopLevel",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopLevel",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "IsTopLevel",
                table: "Groups");
        }
    }
}
