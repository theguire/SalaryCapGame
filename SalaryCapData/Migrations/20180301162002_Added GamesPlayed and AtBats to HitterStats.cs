using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class AddedGamesPlayedandAtBatstoHitterStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtBats",
                table: "HitterStats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "HitterStats",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtBats",
                table: "HitterStats");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "HitterStats");
        }
    }
}
