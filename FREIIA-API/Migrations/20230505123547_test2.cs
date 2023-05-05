using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseParticipant_Expertises_ExpertisesId",
                table: "ExpertiseParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseParticipant_Participants_ParticipantsId",
                table: "ExpertiseParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpertiseParticipant",
                table: "ExpertiseParticipant");

            migrationBuilder.DropIndex(
                name: "IX_ExpertiseParticipant_ParticipantsId",
                table: "ExpertiseParticipant");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "ExpertiseParticipant",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExpertisesId",
                table: "ExpertiseParticipant",
                newName: "ParticipantId");

            migrationBuilder.AddColumn<int>(
                name: "ExpertiseId",
                table: "ExpertiseParticipant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpertiseParticipant",
                table: "ExpertiseParticipant",
                columns: new[] { "ExpertiseId", "ParticipantId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseParticipant_ParticipantId",
                table: "ExpertiseParticipant",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseParticipant_Expertises_ExpertiseId",
                table: "ExpertiseParticipant",
                column: "ExpertiseId",
                principalTable: "Expertises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseParticipant_Participants_ParticipantId",
                table: "ExpertiseParticipant",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseParticipant_Expertises_ExpertiseId",
                table: "ExpertiseParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertiseParticipant_Participants_ParticipantId",
                table: "ExpertiseParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpertiseParticipant",
                table: "ExpertiseParticipant");

            migrationBuilder.DropIndex(
                name: "IX_ExpertiseParticipant_ParticipantId",
                table: "ExpertiseParticipant");

            migrationBuilder.DropColumn(
                name: "ExpertiseId",
                table: "ExpertiseParticipant");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExpertiseParticipant",
                newName: "ParticipantsId");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "ExpertiseParticipant",
                newName: "ExpertisesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpertiseParticipant",
                table: "ExpertiseParticipant",
                columns: new[] { "ExpertisesId", "ParticipantsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseParticipant_ParticipantsId",
                table: "ExpertiseParticipant",
                column: "ParticipantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseParticipant_Expertises_ExpertisesId",
                table: "ExpertiseParticipant",
                column: "ExpertisesId",
                principalTable: "Expertises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertiseParticipant_Participants_ParticipantsId",
                table: "ExpertiseParticipant",
                column: "ParticipantsId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
