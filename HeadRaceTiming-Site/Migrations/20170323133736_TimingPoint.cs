using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HeadRaceTimingSite.Migrations
{
    public partial class TimingPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Sections_SectionId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Results_SectionId",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "TimingPointId",
                table: "Results",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TimingPoints",
                columns: table => new
                {
                    TimingPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimingPoints", x => x.TimingPointId);
                    table.ForeignKey(
                        name: "FK_TimingPoints_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_TimingPointId",
                table: "Results",
                column: "TimingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_TimingPoints_CompetitionId",
                table: "TimingPoints",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results",
                column: "TimingPointId",
                principalTable: "TimingPoints",
                principalColumn: "TimingPointId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "TimingPoints");

            migrationBuilder.DropIndex(
                name: "IX_Results_TimingPointId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TimingPointId",
                table: "Results");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompetitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_SectionId",
                table: "Results",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CompetitionId",
                table: "Sections",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Sections_SectionId",
                table: "Results",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
