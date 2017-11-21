using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class SeedData
    {
    
            public static void EnsurePopulated(IServiceProvider serviceProvider)
            {
                ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

                if (!dbContext.Historics.Any())
                {
                    EnsureHistoricPopulated(dbContext);
                }

                dbContext.SaveChanges();
            }

            private static void EnsureHistoricPopulated(ApplicationDbContext dbContext)
            {
                dbContext.Historics.AddRange(
                    new Historic { TrailID = 1, DifficultyID = 1, Observations = "Observations", TimeTaken = 60, TouristID = 1},
                    new Historic { TrailID = 2, DifficultyID = 3, Observations = "Observations", TimeTaken = 45, TouristID = 2},
                    new Historic { TrailID = 3, DifficultyID = 2, Observations = "Observations", TimeTaken = 64, TouristID = 3}
                );
            }
        }

}
