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

        /* 
         * 
             
        public int HistoricID { get; set; }
        public int TouristID { get; set; }
        public int TrailID{ get; set; }
        public int DifficultyID { get; set; }
        public int TimeTaken { get; set; }
        public String Observations { get; set; }
        public string RealizationDate { get; set; }*/
        private static void EnsureHistoricPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Historics.AddRange(
                new Historic { TouristID = 1, TrailID = 1, DifficultyID = 1, TimeTaken = 120, Observations = "No observations", RealizationDate = "21/10/2017" },
                new Historic { TouristID = 2, TrailID = 2, DifficultyID = 2, TimeTaken = 76, Observations = "No observations", RealizationDate = "20/10/2017" },
                new Historic { TouristID = 1, TrailID = 2, DifficultyID = 3, TimeTaken = 146, Observations = "No observations", RealizationDate = "19/10/2017" },
                new Historic { TouristID = 2, TrailID = 1, DifficultyID = 2, TimeTaken = 200, Observations = "No observations", RealizationDate = "22/10/2017" }
            );

            dbContext.Tourists.AddRange(
                new Tourist { Name = "João Silva", Age = 25, CC = "14255115", Phone = "926263745", Email = "joaoooo@gmail.com" },
                new Tourist { Name = "Paulo Costa", Age = 35, CC = "14535115", Phone = "943685296", Email = "pcosta1231@gmail.com" },
                new Tourist { Name = "Rute Marreco", Age = 57, CC = "14256115", Phone = "927979829", Email = "marrecokkk@gmail.com" }
            );


        }
    }

}
