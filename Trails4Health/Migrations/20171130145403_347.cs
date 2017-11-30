using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trails4Health.Migrations
{
    public partial class _347 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyID",
                table: "Stages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_DifficultyID",
                table: "Stages",
                column: "DifficultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Stages_DifficultyID",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "DifficultyID",
                table: "Stages");
        }
    }
}
