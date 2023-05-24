using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class changeRoleIdToNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants");

            //migrationBuilder.Sql("UPDATE Participants SET RoleId = 0 WHERE RoleId IS NULL"); - Doesn't work
            
            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
