using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171121150250_Initial2")]
    partial class Initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.Property<int>("TrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DistanceToTravel");

                    b.Property<int>("Duration");

                    b.Property<string>("EndLoc");

                    b.Property<int>("IDDifficulty");

                    b.Property<int>("IDSeason");

                    b.Property<bool>("IsActivated");

                    b.Property<string>("Name");

                    b.Property<string>("StartLoc");

                    b.HasKey("TrailID");

                    b.ToTable("Trails");
                });
        }
    }
}
