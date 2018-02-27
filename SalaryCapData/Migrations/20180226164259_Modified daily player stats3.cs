using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class Modifieddailyplayerstats3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InningsPitched",
                table: "PitcherStats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "CompleteGames",
                table: "PitcherStats",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "WHIP",
                table: "PitcherStats",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalBases",
                table: "HitterStats",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WHIP",
                table: "PitcherStats");

            migrationBuilder.AlterColumn<int>(
                name: "InningsPitched",
                table: "PitcherStats",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "CompleteGames",
                table: "PitcherStats",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "TotalBases",
                table: "HitterStats",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
