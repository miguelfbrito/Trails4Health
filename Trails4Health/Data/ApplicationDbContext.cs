    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Trails4Health.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Slope> Slopes{ get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Stage_Trail> Stages_Trails { get; set; }
        public DbSet<Status_Trail> Status_Trails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Foreign Keys Trail----------------------------------------------------------------
            //Dificuldade
            

            //Season
            modelBuilder.Entity<Trail>()
                .HasOne(trail => trail.Season)
                .WithMany(season => season.Trails)
                .HasForeignKey(trail => trail.SeasonID);
            modelBuilder.Entity<Trail>()
                .HasOne(trail => trail.Difficulty)
                .WithMany(difficulty => difficulty.Trails)
                .HasForeignKey(trail => trail.DifficultyID);

            //Desnível
            modelBuilder.Entity<Trail>()
                .HasOne(trail => trail.Slope)
                .WithMany(slope => slope.Trails)
                .HasForeignKey(trail => trail.SlopeID);

            //--------------------------------------------------------------------------------

            //Stage_Trail---------------------------------------------------------------------
            //Primary Key Stage_Trail
            modelBuilder.Entity<Stage_Trail>()
                .HasKey(st => new { st.StageID, st.TrailID });
            //Foreign Keys Stage_Trail
            modelBuilder.Entity<Stage_Trail>()
                .HasOne(st => st.Trail)
                .WithMany(trail => trail.StagesTrails)
                .HasForeignKey(st => st.TrailID);

            modelBuilder.Entity<Stage_Trail>()
                .HasOne(st => st.Stage)
                .WithMany(stage => stage.StagesTrails)
                .HasForeignKey(st => st.StageID);

            // -----------------------------------------------------------------------------------------

            //Status_Trail-------------------------------------------------------------------------
            
            //Primary Key Status_Trail
            modelBuilder.Entity<Status_Trail>()
                .HasKey(st => new { st.StatusID, st.TrailID });
            //Foreign Keys Status_Trail
            modelBuilder.Entity<Status_Trail>()
                .HasOne(st => st.Trail)
                .WithMany(trail => trail.StatusTrails)
                .HasForeignKey(st => st.TrailID);

            modelBuilder.Entity<Status_Trail>()
                .HasOne(st => st.Status)
                .WithMany(status => status.StatusTrails)
                .HasForeignKey(st => st.StatusID);
            //-------------------------------------------------------------------------------------------

        }
    }
}
