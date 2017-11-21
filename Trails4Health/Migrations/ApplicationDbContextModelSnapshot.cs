using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Data;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trails4Health.Models.Stage", b =>
                {
                    b.Property<int>("StageID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Distance");

                    b.Property<int>("Duration");

                    b.Property<string>("StageEndLoc");

                    b.Property<string>("StageName");

                    b.Property<string>("StageStartLoc");

                    b.HasKey("StageID");

                    b.ToTable("Stages");
                });
        }
    }
}
