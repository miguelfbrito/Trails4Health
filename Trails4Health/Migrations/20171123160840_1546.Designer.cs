using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Data;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(StagesDbContext))]
    [Migration("20171123160840_1546")]
    partial class _1546
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Distance");

                    b.Property<int>("Duration");

                    b.Property<string>("Geolocalization");

                    b.Property<string>("StageEndLoc");

                    b.Property<string>("StageName");

                    b.Property<string>("StageStartLoc");

                    b.HasKey("StageId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage_Trail", b =>
                {
                    b.Property<int>("StageId");

                    b.Property<int>("TrailId");

                    b.Property<bool>("IsActivated");

                    b.Property<int>("Order");

                    b.HasKey("StageId", "TrailId");

                    b.HasIndex("TrailId");

                    b.ToTable("Stage_Trail");
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.Property<int>("TrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DistanceToTravel");

                    b.Property<int>("Duration");

                    b.Property<string>("EndLoc");

                    b.Property<bool>("IsActivated");

                    b.Property<string>("Name");

                    b.Property<string>("StartLoc");

                    b.HasKey("TrailID");

                    b.ToTable("Trail");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage_Trail", b =>
                {
                    b.HasOne("Trails4Health.Models.Stage", "Stage")
                        .WithMany("StagesTrails")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trail", "Trail")
                        .WithMany("StagesTrails")
                        .HasForeignKey("TrailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
