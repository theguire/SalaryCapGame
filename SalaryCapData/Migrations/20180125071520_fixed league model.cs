using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalaryCapData.Migrations
{
    public partial class fixedleaguemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Owners_CommissionerOwnerId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_CommissionerOwnerId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CommissionerOwnerId",
                table: "Leagues");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Leagues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_OwnerId",
                table: "Leagues",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Owners_OwnerId",
                table: "Leagues",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Owners_OwnerId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_OwnerId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Leagues");

            migrationBuilder.AddColumn<int>(
                name: "CommissionerOwnerId",
                table: "Leagues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_CommissionerOwnerId",
                table: "Leagues",
                column: "CommissionerOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Owners_CommissionerOwnerId",
                table: "Leagues",
                column: "CommissionerOwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
