using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trails4Health.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    TrailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistanceToTravel = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EndLoc = table.Column<string>(nullable: true),
                    IDDifficulty = table.Column<int>(nullable: false),
                    IDSeason = table.Column<int>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartLoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.TrailID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trails");
        }
    }
}
