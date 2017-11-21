using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            ApplicationDbContext dbContext = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (!dbContext.Trails.Any()) { 
            EnsureTrailsPopulated(dbContext);
            }
            dbContext.SaveChanges();
        }

        private static void EnsureTrailsPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Trails.AddRange(
                new Trail { Name = "Trilho Serra 1", Duration = 120, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", IDSeason = 1, IsActivated = true, IDDifficulty = 1 },
                new Trail { Name = "Trilho Serra 2", Duration = 180, DistanceToTravel = 50, StartLoc = "Guarda", EndLoc = "Serra", IDSeason = 2, IsActivated = true, IDDifficulty = 2 }
                );
            
        }
    }
}
