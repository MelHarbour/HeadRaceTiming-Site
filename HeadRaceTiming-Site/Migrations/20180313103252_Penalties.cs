using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Migrations
{
    public partial class Penalties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewAthlete_Athlete_AthleteId",
                table: "CrewAthlete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Athlete",
                table: "Athlete");

            migrationBuilder.RenameTable(
                name: "Athlete",
                newName: "Athletes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes",
                column: "AthleteId");

            migrationBuilder.CreateTable(
                name: "Penalties",
                columns: table => new
                {
                    PenaltyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CrewId = table.Column<int>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Value = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalties", x => x.PenaltyId);
                    table.ForeignKey(
                        name: "FK_Penalties_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "CrewId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalties_CrewId",
                table: "Penalties",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewAthlete_Athletes_AthleteId",
                table: "CrewAthlete",
                column: "AthleteId",
                principalTable: "Athletes",
                principalColumn: "AthleteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewAthlete_Athletes_AthleteId",
                table: "CrewAthlete");

            migrationBuilder.DropTable(
                name: "Penalties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Athletes",
                table: "Athletes");

            migrationBuilder.RenameTable(
                name: "Athletes",
                newName: "Athlete");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Athlete",
                table: "Athlete",
                column: "AthleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewAthlete_Athlete_AthleteId",
                table: "CrewAthlete",
                column: "AthleteId",
                principalTable: "Athlete",
                principalColumn: "AthleteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
