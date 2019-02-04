using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadRaceTimingSite.Migrations
{
    public partial class HandicapReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HandicapReferenceTimes",
                columns: table => new
                {
                    HandicapReferenceTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandardTime = table.Column<TimeSpan>(nullable: false),
                    Seconds = table.Column<int>(nullable: false),
                    MastersCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandicapReferenceTimes", x => x.HandicapReferenceTimeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HandicapReferenceTimes");
        }
    }
}
