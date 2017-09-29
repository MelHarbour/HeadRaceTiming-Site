using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Migrations
{
    public partial class CompetitionTextColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Argb",
                table: "Competitions");

            migrationBuilder.AddColumn<int>(
                name: "BackgroundArgb",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TextArgb",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundArgb",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "TextArgb",
                table: "Competitions");

            migrationBuilder.AddColumn<int>(
                name: "Argb",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
