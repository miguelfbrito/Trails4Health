using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Trails4Health.Models;

namespace Trails4Health.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180112162106_initial3")]
    partial class initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Trails4Health.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Trails4Health.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Level");

                    b.HasKey("DifficultyID");

                    b.ToTable("Difficulties");
                });

            modelBuilder.Entity("Trails4Health.Models.Historic", b =>
                {
                    b.Property<int>("HistoricID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DifficultyID");

                    b.Property<string>("Observations")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("RealizationDate");

                    b.Property<int>("TimeTaken");

                    b.Property<int>("TouristID");

                    b.Property<int>("TrailID");

                    b.HasKey("HistoricID");

                    b.HasIndex("DifficultyID");

                    b.HasIndex("TouristID");

                    b.HasIndex("TrailID");

                    b.ToTable("Historics");
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

                    b.Property<string>("Comment");

                    b.Property<string>("Type");

                    b.HasKey("SlopeID");

                    b.ToTable("Slopes");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DifficultyID");

                    b.Property<int>("Distance");

                    b.Property<int>("Duration");

                    b.Property<string>("Geolocalization")
                        .IsRequired();

                    b.Property<bool>("IsActivated");

                    b.Property<string>("StageEndLoc")
                        .IsRequired();

                    b.Property<string>("StageName")
                        .IsRequired();

                    b.Property<string>("StageStartLoc")
                        .IsRequired();

                    b.HasKey("StageId");

                    b.HasIndex("DifficultyID");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Trails4Health.Models.Stage_Trail", b =>
                {
                    b.Property<int>("StageID");

                    b.Property<int>("TrailID");

                    b.Property<bool>("Activated");

                    b.Property<double>("StageDifficulty");

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

            modelBuilder.Entity("Trails4Health.Models.StatusTrails", b =>
                {
                    b.Property<int>("StatusTrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("StatusID");

                    b.Property<int>("TrailID");

                    b.HasKey("StatusTrailID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TrailID");

                    b.ToTable("StatusTrails");
                });

            modelBuilder.Entity("Trails4Health.Models.Tourist", b =>
                {
                    b.Property<int>("TouristID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("CC");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("TipoUtilizador");

                    b.HasKey("TouristID");

                    b.ToTable("Tourists");
                });

            modelBuilder.Entity("Trails4Health.Models.Trail", b =>
                {
                    b.Property<int>("TrailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DistanceToTravel");

                    b.Property<int>("Duration");

                    b.Property<string>("EndLoc")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("IsActivated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("SeasonID");

                    b.Property<int>("SlopeID");

                    b.Property<string>("StartLoc")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<byte[]>("TrailImage");

                    b.HasKey("TrailID");

                    b.HasIndex("SeasonID");

                    b.HasIndex("SlopeID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Trails4Health.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Trails4Health.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Historic", b =>
                {
                    b.HasOne("Trails4Health.Models.Difficulty", "Difficulty")
                        .WithMany("Historics")
                        .HasForeignKey("DifficultyID");

                    b.HasOne("Trails4Health.Models.Tourist", "Tourist")
                        .WithMany("Historics")
                        .HasForeignKey("TouristID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Trails4Health.Models.Trail", "Trail")
                        .WithMany("Historics")
                        .HasForeignKey("TrailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Trails4Health.Models.Stage", b =>
                {
                    b.HasOne("Trails4Health.Models.Difficulty", "Difficulty")
                        .WithMany("Stages")
                        .HasForeignKey("DifficultyID")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Trails4Health.Models.StatusTrails", b =>
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
