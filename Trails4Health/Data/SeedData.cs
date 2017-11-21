using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            ApplicationDbContext dbContext = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            PopulatedProducts(dbContext);
        }

        private static void PopulatedProducts(ApplicationDbContext dbContext)
        {
            if (!dbContext.Stages.Any())
            {
                dbContext.Stages.AddRange(
                new Stage {StageName = "Lagoas", StageStartLoc = "Lagoa Comprida", StageEndLoc = "Lagoa Pequena", Distance = 2, Duration = 4 },
                new Stage {StageName = "Manteigas", StageStartLoc = "Manteigas", StageEndLoc = "Floresta", Distance = 1, Duration = 2 }
                );
            }
            dbContext.SaveChanges();
        }
    }
}
