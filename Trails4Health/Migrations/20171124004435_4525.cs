using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class _4525 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stage",
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
                    table.PrimaryKey("PK_Stage", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Trail",
                columns: table => new
                {
                    TrailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistanceToTravel = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EndLoc = table.Column<string>(nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartLoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trail", x => x.TrailID);
                });

            migrationBuilder.CreateTable(
                name: "Stage_Trail",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false),
                    TrailId = table.Column<int>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage_Trail", x => new { x.StageId, x.TrailId });
                    table.ForeignKey(
                        name: "FK_Stage_Trail_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stage_Trail_Trail_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trail",
                        principalColumn: "TrailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stage_Trail_TrailId",
                table: "Stage_Trail",
                column: "TrailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stage_Trail");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "Trail");
        }
    }
}
