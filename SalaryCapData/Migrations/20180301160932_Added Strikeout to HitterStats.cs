using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class AddedStrikeouttoHitterStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats");

            migrationBuilder.DropIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats");

            migrationBuilder.AddColumn<int>(
                name: "Strikeouts",
                table: "HitterStats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats");

            migrationBuilder.DropIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats");

            migrationBuilder.DropColumn(
                name: "Strikeouts",
                table: "HitterStats");

            migrationBuilder.CreateIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats",
                column: "PlayerId");
        }
    }
}
