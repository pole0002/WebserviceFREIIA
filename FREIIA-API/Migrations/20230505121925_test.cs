using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RGBA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertises_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ChartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Charts_ChartId",
                        column: x => x.ChartId,
                        principalTable: "Charts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zones_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    LineStyleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionStyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectionStyles_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionStyles_LineStyles_LineStyleId",
                        column: x => x.LineStyleId,
                        principalTable: "LineStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ChartId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Charts_ChartId",
                        column: x => x.ChartId,
                        principalTable: "Charts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groups_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ContactInfoId = table.Column<int>(type: "int", nullable: true),
                    ChartId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Charts_ChartId",
                        column: x => x.ChartId,
                        principalTable: "Charts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_ParticipantContactInfos_ContactInfoId",
                        column: x => x.ContactInfoId,
                        principalTable: "ParticipantContactInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participants_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionStyleId = table.Column<int>(type: "int", nullable: false),
                    FirstZoneId = table.Column<int>(type: "int", nullable: true),
                    SecondZoneId = table.Column<int>(type: "int", nullable: true),
                    FirstGroupId = table.Column<int>(type: "int", nullable: true),
                    SecondGroupId = table.Column<int>(type: "int", nullable: true),
                    FirstParticipantId = table.Column<int>(type: "int", nullable: true),
                    SecondParticipantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_ConnectionStyles_ConnectionStyleId",
                        column: x => x.ConnectionStyleId,
                        principalTable: "ConnectionStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connections_Groups_FirstGroupId",
                        column: x => x.FirstGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connections_Groups_SecondGroupId",
                        column: x => x.SecondGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connections_Participants_FirstParticipantId",
                        column: x => x.FirstParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connections_Participants_SecondParticipantId",
                        column: x => x.SecondParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connections_Zones_FirstZoneId",
                        column: x => x.FirstZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Connections_Zones_SecondZoneId",
                        column: x => x.SecondZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertiseParticipant",
                columns: table => new
                {
                    ExpertisesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ConnectionStyleId",
                table: "Connections",
                column: "ConnectionStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_FirstGroupId",
                table: "Connections",
                column: "FirstGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_FirstParticipantId",
                table: "Connections",
                column: "FirstParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_FirstZoneId",
                table: "Connections",
                column: "FirstZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_SecondGroupId",
                table: "Connections",
                column: "SecondGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_SecondParticipantId",
                table: "Connections",
                column: "SecondParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_SecondZoneId",
                table: "Connections",
                column: "SecondZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionStyles_ColorId",
                table: "ConnectionStyles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionStyles_LineStyleId",
                table: "ConnectionStyles",
                column: "LineStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseParticipant_ParticipantsId",
                table: "ExpertiseParticipant",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_ColorId",
                table: "Expertises",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ChartId",
                table: "Groups",
                column: "ChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ColorId",
                table: "Groups",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ZoneId",
                table: "Groups",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ChartId",
                table: "Participants",
                column: "ChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ContactInfoId",
                table: "Participants",
                column: "ContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_GroupId",
                table: "Participants",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_RoleId",
                table: "Participants",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ZoneId",
                table: "Participants",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ColorId",
                table: "Roles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ChartId",
                table: "Zones",
                column: "ChartId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ColorId",
                table: "Zones",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "ExpertiseParticipant");

            migrationBuilder.DropTable(
                name: "ConnectionStyles");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "LineStyles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ParticipantContactInfos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Charts");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
