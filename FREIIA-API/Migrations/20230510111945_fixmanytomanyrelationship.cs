using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class fixmanytomanyrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExpertiseParticipant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExpertiseParticipant",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
