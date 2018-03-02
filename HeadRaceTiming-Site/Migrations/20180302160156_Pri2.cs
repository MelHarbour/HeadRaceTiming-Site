﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HeadRaceTimingSite.Migrations
{
    public partial class Pri2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pri",
                table: "Athlete");

            migrationBuilder.DropColumn(
                name: "PriMax",
                table: "Athlete");

            migrationBuilder.AddColumn<int>(
                name: "Pri",
                table: "CrewAthlete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriMax",
                table: "CrewAthlete",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pri",
                table: "CrewAthlete");

            migrationBuilder.DropColumn(
                name: "PriMax",
                table: "CrewAthlete");

            migrationBuilder.AddColumn<int>(
                name: "Pri",
                table: "Athlete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriMax",
                table: "Athlete",
                nullable: false,
                defaultValue: 0);
        }
    }
}
