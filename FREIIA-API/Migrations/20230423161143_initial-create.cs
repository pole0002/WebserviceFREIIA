using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FREIIA_API.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Font = table.Column<string>(type: "TEXT", nullable: false),
                    LineStyle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantContactInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChartId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Charts_ChartId",
                        column: x => x.ChartId,
                        principalTable: "Charts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChartId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZoneId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_Groups_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FromCompany = table.Column<string>(type: "TEXT", nullable: true),
                    ContactInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChartId = table.Column<int>(type: "INTEGER", nullable: true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZoneId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_Participants_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ConnectionStyleId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstZoneId = table.Column<int>(type: "INTEGER", nullable: true),
                    SecondZoneId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    SecondGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstParticipantId = table.Column<int>(type: "INTEGER", nullable: true),
                    SecondParticipantId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "IX_Groups_ChartId",
                table: "Groups",
                column: "ChartId");

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
                name: "IX_Participants_ZoneId",
                table: "Participants",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ChartId",
                table: "Zones",
                column: "ChartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "ConnectionStyles");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ParticipantContactInfos");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Charts");
        }
    }
}
