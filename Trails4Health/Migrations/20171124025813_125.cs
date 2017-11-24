using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class _125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    DifficultyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true)
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
                    Comment = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slopes", x => x.SlopeID);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Geolocalization = table.Column<string>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    StageEndLoc = table.Column<string>(nullable: false),
                    StageName = table.Column<string>(nullable: false),
                    StageStartLoc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
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
                name: "Tourists",
                columns: table => new
                {
                    TouristID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    CC = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.TouristID);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DifficultyID = table.Column<int>(nullable: false),
                    DistanceToTravel = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EndLoc = table.Column<string>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SeasonID = table.Column<int>(nullable: false),
                    SlopeID = table.Column<int>(nullable: false),
                    StartLoc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailID);
                    table.ForeignKey(
                        name: "FK_Trails_Difficulties_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulties",
                        principalColumn: "DifficultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trails_Seasons_SeasonID",
                        column: x => x.SeasonID,
                        principalTable: "Seasons",
                        principalColumn: "SeasonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trails_Slopes_SlopeID",
                        column: x => x.SlopeID,
                        principalTable: "Slopes",
                        principalColumn: "SlopeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historics",
                columns: table => new
                {
                    TouristID = table.Column<int>(nullable: false),
                    TrailID = table.Column<int>(nullable: false),
                    DifficultyID = table.Column<int>(nullable: true),
                    Observations = table.Column<string>(nullable: true),
                    RealizationDate = table.Column<string>(nullable: true),
                    TimeTaken = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historics", x => new { x.TouristID, x.TrailID });
                    table.ForeignKey(
                        name: "FK_Historics_Difficulties_DifficultyID",
                        column: x => x.DifficultyID,
                        principalTable: "Difficulties",
                        principalColumn: "DifficultyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historics_Tourists_TouristID",
                        column: x => x.TouristID,
                        principalTable: "Tourists",
                        principalColumn: "TouristID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historics_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "StageId",
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
                name: "IX_Historics_DifficultyID",
                table: "Historics",
                column: "DifficultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Historics_TrailID",
                table: "Historics",
                column: "TrailID");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_Trails_TrailID",
                table: "Stages_Trails",
                column: "TrailID");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Trails_TrailID",
                table: "Status_Trails",
                column: "TrailID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historics");

            migrationBuilder.DropTable(
                name: "Stages_Trails");

            migrationBuilder.DropTable(
                name: "Status_Trails");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Slopes");
        }
    }
}
