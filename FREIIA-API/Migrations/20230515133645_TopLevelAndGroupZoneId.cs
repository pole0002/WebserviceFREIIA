using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class TopLevelAndGroupZoneId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Charts_ChartId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Charts_ChartId",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "ChartId",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ChartId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChartId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChartId",
                table: "Expertises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Charts_ChartId",
                table: "Groups",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Charts_ChartId",
                table: "Participants",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Charts_ChartId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Charts_ChartId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ChartId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ChartId",
                table: "Expertises");

            migrationBuilder.AlterColumn<int>(
                name: "ChartId",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChartId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Charts_ChartId",
                table: "Groups",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Charts_ChartId",
                table: "Participants",
                column: "ChartId",
                principalTable: "Charts",
                principalColumn: "Id");
        }
    }
}
