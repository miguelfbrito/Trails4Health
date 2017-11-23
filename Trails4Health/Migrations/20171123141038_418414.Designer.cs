using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171123141038_418414")]
    partial class _418414
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
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
