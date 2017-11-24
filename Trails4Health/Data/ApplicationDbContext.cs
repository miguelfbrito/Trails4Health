using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Historic> Historics { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Stage_Trail> Stages_Trails { get; set; }
        public DbSet<Status_Trail> Status_Trails { get; set; }       
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*   public int TouristID { get; set; }
        public int TimeTaken { get; set; }
        public String Observations { get; set; }
        public string RealizationDate { get; set; }
        
        public Difficulty Difficulty { get; set; }
        public int DifficultyID { get; set; }

        public Trail Trail { get; set; }
        public int TrailID { get; set; }*/

            //Historic
            /*
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }*/

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



            // TURISTA

            /*
               public int TouristID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String CC { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
*/

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

         //   modelBuilder.Entity<Historic>()
           //    .HasOne(t => t.Trail).WithMany(h => h.Historics).IsRequired().OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

            //modelBuilder.Entity<Historic>()
              // .HasOne(t => t.Tourist).WithMany(h => h.Historics).IsRequired().OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

                

            modelBuilder.Entity<Historic>().HasKey(h => new { h.TouristID, h.TrailID});


            /*modelBuilder.Entity<Historic>()
               .HasOne(h => h.Difficulty)
               .WithMany(d => d.Historics)
               .HasForeignKey(h => h.DifficultyID);
            ;*/

            modelBuilder.Entity<Historic>()
                 .HasOne(h => h.Trail)
                 .WithMany(t => t.Historics)
                 .HasForeignKey(h => h.TrailID);

            modelBuilder.Entity<Historic>()
                 .HasOne(h => h.Tourist)
                 .WithMany(t => t.Historics)
                 .HasForeignKey(h => h.TouristID);//.OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);


        }
    }
}
 

