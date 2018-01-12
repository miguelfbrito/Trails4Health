using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations.ApplicationDb
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails");

            migrationBuilder.DropTable(
                name: "Status_Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "DifficultyID",
                table: "Trails");

            migrationBuilder.AlterColumn<string>(
                name: "StartLoc",
                table: "Trails",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trails",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EndLoc",
                table: "Trails",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<byte[]>(
                name: "TrailImage",
                table: "Trails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyID",
                table: "Stages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusTrails",
                columns: table => new
                {
                    StatusTrailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTrails", x => x.StatusTrailID);
                    table.ForeignKey(
                        name: "FK_StatusTrails_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusTrails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stages_DifficultyID",
                table: "Stages",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTrails_StatusID",
                table: "StatusTrails",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTrails_TrailID",
                table: "StatusTrails",
                column: "TrailID");

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

            migrationBuilder.DropTable(
                name: "StatusTrails");

            migrationBuilder.DropIndex(
                name: "IX_Stages_DifficultyID",
                table: "Stages");

            migrationBuilder.DropColumn(
                name: "TrailImage",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "DifficultyID",
                table: "Stages");

            migrationBuilder.AlterColumn<string>(
                name: "StartLoc",
                table: "Trails",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Trails",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "EndLoc",
                table: "Trails",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyID",
                table: "Trails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status_Trails",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Trails", x => new { x.StatusID, x.TrailID });
                    table.ForeignKey(
                        name: "FK_Status_Trails_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Status_Trails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Trails_TrailID",
                table: "Status_Trails",
                column: "TrailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails",
                column: "DifficultyID",
                principalTable: "Difficulties",
                principalColumn: "DifficultyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
