using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trails4Health.Migrations
{
    public partial class _341 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historics_Tourists_TouristID",
                table: "Historics");

            migrationBuilder.DropForeignKey(
                name: "FK_Historics_Trails_TrailID",
                table: "Historics");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Trails_Stages_StageID",
                table: "Stages_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Trails_Trails_TrailID",
                table: "Stages_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Trails_Status_StatusID",
                table: "Status_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Trails_Trails_TrailID",
                table: "Status_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Seasons_SeasonID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Slopes_SlopeID",
                table: "Trails");

            migrationBuilder.AddForeignKey(
                name: "FK_Historics_Tourists_TouristID",
                table: "Historics",
                column: "TouristID",
                principalTable: "Tourists",
                principalColumn: "TouristID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Historics_Trails_TrailID",
                table: "Historics",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Trails_Stages_StageID",
                table: "Stages_Trails",
                column: "StageID",
                principalTable: "Stages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Trails_Trails_TrailID",
                table: "Stages_Trails",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Trails_Status_StatusID",
                table: "Status_Trails",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Trails_Trails_TrailID",
                table: "Status_Trails",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Seasons_SeasonID",
                table: "Trails",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "SeasonID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Slopes_SlopeID",
                table: "Trails",
                column: "SlopeID",
                principalTable: "Slopes",
                principalColumn: "SlopeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historics_Tourists_TouristID",
                table: "Historics");

            migrationBuilder.DropForeignKey(
                name: "FK_Historics_Trails_TrailID",
                table: "Historics");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Trails_Stages_StageID",
                table: "Stages_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Trails_Trails_TrailID",
                table: "Stages_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Trails_Status_StatusID",
                table: "Status_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Trails_Trails_TrailID",
                table: "Status_Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Seasons_SeasonID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Slopes_SlopeID",
                table: "Trails");

            migrationBuilder.AddForeignKey(
                name: "FK_Historics_Tourists_TouristID",
                table: "Historics",
                column: "TouristID",
                principalTable: "Tourists",
                principalColumn: "TouristID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Historics_Trails_TrailID",
                table: "Historics",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Difficulties_DifficultyID",
                table: "Stages",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Trails_Stages_StageID",
                table: "Stages_Trails",
                column: "StageID",
                principalTable: "Stages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Trails_Trails_TrailID",
                table: "Stages_Trails",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Trails_Status_StatusID",
                table: "Status_Trails",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Trails_Trails_TrailID",
                table: "Status_Trails",
                column: "TrailID",
                principalTable: "Trails",
                principalColumn: "TrailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Seasons_SeasonID",
                table: "Trails",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "SeasonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Slopes_SlopeID",
                table: "Trails",
                column: "SlopeID",
                principalTable: "Slopes",
                principalColumn: "SlopeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
