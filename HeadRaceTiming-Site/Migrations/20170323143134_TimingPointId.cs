using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadRaceTimingSite.Migrations
{
    public partial class TimingPointId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "TimingPointId",
                table: "Results",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimingPointId",
                table: "Results",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Results",
                nullable: false,
                defaultValue: 0);
        }
    }
}
