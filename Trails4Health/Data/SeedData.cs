using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class SeedData
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
            dbContext.Difficulties.AddRange(
                new Difficulty { DifficultyLevel = "Very Hard", DifficultyComment = "Hard Trail" }
            );
            dbContext.Seasons.AddRange(
                new Season { SeasonName = "Winter" }
            );
            dbContext.Slopes.AddRange(
                new Slope { SlopeType = "Very Declive", SlopeComment = "Hard Trail" }
            );
            dbContext.Trails.AddRange(
                new Trail { Name = "Trilho Serra 1",IsActivated=true, Duration = 120, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 1, SeasonID = 1, SlopeID = 1 }
    
                );
            
        }
    }
}
