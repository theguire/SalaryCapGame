using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class AddedJsonHandlingforDailyStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HitterStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Doubles = table.Column<int>(nullable: false),
                    ExtraBases = table.Column<int>(nullable: false),
                    Hits = table.Column<int>(nullable: false),
                    HomeRuns = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    RBI = table.Column<int>(nullable: false),
                    Runs = table.Column<int>(nullable: false),
                    Sacrifices = table.Column<int>(nullable: false),
                    StolenBases = table.Column<int>(nullable: false),
                    Triples = table.Column<int>(nullable: false),
                    Walks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitterStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PitcherStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompleteGames = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EarnedRunsAllowed = table.Column<int>(nullable: false),
                    HitsAllowed = table.Column<int>(nullable: false),
                    Holds = table.Column<int>(nullable: false),
                    InningsPitched = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    PickOffs = table.Column<int>(nullable: false),
                    PitcherWalks = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Saves = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitcherStats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HitterStats");

            migrationBuilder.DropTable(
                name: "PitcherStats");
        }
    }
}
