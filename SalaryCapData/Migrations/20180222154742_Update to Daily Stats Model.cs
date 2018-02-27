using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class UpdatetoDailyStatsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_HitterStats_Players_PlayerId",
                table: "HitterStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PitcherStats_Players_PlayerId",
                table: "PitcherStats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HitterStats_Players_PlayerId",
                table: "HitterStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PitcherStats_Players_PlayerId",
                table: "PitcherStats");

            migrationBuilder.DropIndex(
                name: "IX_PitcherStats_PlayerId",
                table: "PitcherStats");

            migrationBuilder.DropIndex(
                name: "IX_HitterStats_PlayerId",
                table: "HitterStats");
        }
    }
}
