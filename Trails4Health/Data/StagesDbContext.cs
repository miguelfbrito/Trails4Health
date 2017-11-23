using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class StagesDbContext : DbContext
    {
        public StagesDbContext(
DbContextOptions<StagesDbContext> options) : base(options) {
        }
        public DbSet<Stage> Stages;
        public DbSet<Trail> Trails;
        public DbSet<Stage_Trail> StagesTrails;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stage_Trail>()
            .HasKey(st => new { st.StageId, st.TrailId });

            modelBuilder.Entity<Stage_Trail>()
            .HasOne(st => st.Stage)
            .WithMany(t => t.StagesTrails)
            .HasForeignKey(st => st.StageId);

            modelBuilder.Entity<Stage_Trail>()
            .HasOne(st => st.Trail)
            .WithMany(s => s.StagesTrails)
            .HasForeignKey(st => st.TrailId);
        }

    }
}
