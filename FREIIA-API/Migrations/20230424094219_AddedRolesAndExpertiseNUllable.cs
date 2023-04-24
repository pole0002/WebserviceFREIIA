using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesAndExpertiseNUllable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Participants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertiseParticipant",
                columns: table => new
                {
                    ExpertisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipantsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertiseParticipant", x => new { x.ExpertisesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_ExpertiseParticipant_Expertises_ExpertisesId",
                        column: x => x.ExpertisesId,
                        principalTable: "Expertises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertiseParticipant_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_RoleId",
                table: "Participants",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseParticipant_ParticipantsId",
                table: "ExpertiseParticipant",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Roles_RoleId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "ExpertiseParticipant");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropIndex(
                name: "IX_Participants_RoleId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Participants");
        }
    }
}
