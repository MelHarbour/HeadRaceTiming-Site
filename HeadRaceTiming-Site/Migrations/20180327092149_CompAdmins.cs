using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Migrations
{
    public partial class CompAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionAdministrators",
                columns: table => new
                {
                    CompetitionAdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameIdentifier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionAdministrators", x => x.CompetitionAdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "CompCompAdmin",
                columns: table => new
                {
                    CompetitionAdministratorId = table.Column<int>(nullable: false),
                    CompetitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompCompAdmin", x => new { x.CompetitionAdministratorId, x.CompetitionId });
                    table.ForeignKey(
                        name: "FK_CompCompAdmin_CompetitionAdministrators_CompetitionAdministratorId",
                        column: x => x.CompetitionAdministratorId,
                        principalTable: "CompetitionAdministrators",
                        principalColumn: "CompetitionAdministratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompCompAdmin_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompCompAdmin_CompetitionId",
                table: "CompCompAdmin",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompCompAdmin");

            migrationBuilder.DropTable(
                name: "CompetitionAdministrators");
        }
    }
}
