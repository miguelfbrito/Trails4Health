﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyComment");

                    b.Property<string>("DifficultyLevel");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Trails4Health.Models.Season", b =>
                {
                    b.Property<int>("SeasonID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SeasonName");

                    b.HasKey("SeasonID");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Trails4Health.Models.Slope", b =>
                {
                    b.Property<int>("SlopeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SlopeComment");

                    b.Property<string>("SlopeType");

                    b.HasKey("SlopeID");

                    b.ToTable("Slopes");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage", b =>
                {
                    b.Property<int>("StageID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Distance");

                    b.Property<int>("Duration");

                    b.Property<string>("Geolocation");

                    b.Property<string>("StageName");

                    b.HasKey("StageID");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage_Trail", b =>
                {
                    b.Property<int>("StageID");

                    b.Property<int>("TrailID");

                    b.Property<bool>("Activated");

                    b.Property<int>("StageOrder");

                    b.HasKey("StageID", "TrailID");

                    b.HasIndex("TrailID");

                    b.ToTable("Stages_Trails");
                });

            modelBuilder.Entity("Trails4Health.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StatusName");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Trails4Health.Models.Status_Trail", b =>
                {
                    b.Property<int>("StatusID");

                    b.Property<int>("TrailID");

                    b.HasKey("StatusID", "TrailID");

                    b.HasIndex("TrailID");

                    b.ToTable("Status_Trails");
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.Property<int>("TrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyID");

                    b.Property<int>("DistanceToTravel");

                    b.Property<int>("Duration");

                    b.Property<string>("EndLoc")
                        .IsRequired();

                    b.Property<bool>("IsActivated");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("SeasonID");

                    b.Property<int>("SlopeID");

                    b.Property<string>("StartLoc")
                        .IsRequired();

                    b.HasKey("TrailID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("SeasonID");

                    b.HasIndex("SlopeID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage_Trail", b =>
                {
                    b.HasOne("Trails4Health.Models.Stage", "Stage")
                        .WithMany("StagesTrails")
                        .HasForeignKey("StageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trail", "Trail")
                        .WithMany("StagesTrails")
                        .HasForeignKey("TrailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Status_Trail", b =>
                {
                    b.HasOne("Trails4Health.Models.Status", "Status")
                        .WithMany("StatusTrails")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trail", "Trail")
                        .WithMany("StatusTrails")
                        .HasForeignKey("TrailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.HasOne("Trails4Health.Models.Difficulty", "Difficulty")
                        .WithMany("Trails")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Season", "Season")
                        .WithMany("Trails")
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Slope", "Slope")
                        .WithMany("Trails")
                        .HasForeignKey("SlopeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
