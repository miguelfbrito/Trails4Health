using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDSeason",
                table: "Trails",
                newName: "SlopeID");

            migrationBuilder.RenameColumn(
                name: "IDDifficulty",
                table: "Trails",
                newName: "SeasonID");

            migrationBuilder.AddColumn<int>(
                name: "DifficultyID",
                table: "Trails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    DifficultyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyComment = table.Column<string>(nullable: true),
                    DifficultyLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.DifficultyID);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeasonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonID);
                });

            migrationBuilder.CreateTable(
                name: "Slopes",
                columns: table => new
                {
                    SlopeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SlopeComment = table.Column<string>(nullable: true),
                    SlopeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slopes", x => x.SlopeID);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Geolocation = table.Column<string>(nullable: true),
                    StageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Stages_Trails",
                columns: table => new
                {
                    StageID = table.Column<int>(nullable: false),
                    TrailID = table.Column<int>(nullable: false),
                    Activated = table.Column<bool>(nullable: false),
                    StageOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages_Trails", x => new { x.StageID, x.TrailID });
                    table.ForeignKey(
                        name: "FK_Stages_Trails_Stages_StageID",
                        column: x => x.StageID,
                        principalTable: "Stages",
                        principalColumn: "StageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stages_Trails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Trails_SeasonID",
                table: "Trails",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_SlopeID",
                table: "Trails",
                column: "SlopeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_Trails_TrailID",
                table: "Stages_Trails",
                column: "TrailID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Difficulties_DifficultyID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Seasons_SeasonID",
                table: "Trails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trails_Slopes_SlopeID",
                table: "Trails");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Slopes");

            migrationBuilder.DropTable(
                name: "Stages_Trails");

            migrationBuilder.DropTable(
                name: "Status_Trails");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Trails_DifficultyID",
                table: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_SeasonID",
                table: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_SlopeID",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "DifficultyID",
                table: "Trails");

            migrationBuilder.RenameColumn(
                name: "SlopeID",
                table: "Trails",
                newName: "IDSeason");

            migrationBuilder.RenameColumn(
                name: "SeasonID",
                table: "Trails",
                newName: "IDDifficulty");
        }
    }
}
