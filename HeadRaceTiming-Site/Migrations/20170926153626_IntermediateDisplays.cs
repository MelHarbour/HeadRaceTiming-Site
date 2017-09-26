using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Migrations
{
    public partial class IntermediateDisplays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Competitions_CompetitionId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Crews_CrewId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TimingPoints_Competitions_CompetitionId",
                table: "TimingPoints");

            migrationBuilder.AddColumn<bool>(
                name: "ShowFirstIntermediate",
                table: "Competitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowSecondIntermediate",
                table: "Competitions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Competitions_CompetitionId",
                table: "Crews",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Crews_CrewId",
                table: "Results",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "CrewId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results",
                column: "TimingPointId",
                principalTable: "TimingPoints",
                principalColumn: "TimingPointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimingPoints_Competitions_CompetitionId",
                table: "TimingPoints",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Competitions_CompetitionId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Crews_CrewId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_TimingPoints_Competitions_CompetitionId",
                table: "TimingPoints");

            migrationBuilder.DropColumn(
                name: "ShowFirstIntermediate",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "ShowSecondIntermediate",
                table: "Competitions");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Competitions_CompetitionId",
                table: "Crews",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Crews_CrewId",
                table: "Results",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "CrewId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_TimingPoints_TimingPointId",
                table: "Results",
                column: "TimingPointId",
                principalTable: "TimingPoints",
                principalColumn: "TimingPointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimingPoints_Competitions_CompetitionId",
                table: "TimingPoints",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
