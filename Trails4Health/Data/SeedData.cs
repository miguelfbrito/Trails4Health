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
                dbContext.SaveChanges();
            }
            

        }

        public int HistoricID { get; set; }
        public int TouristID { get; set; }
        public int TrailID { get; set; }
        public int DifficultyID { get; set; }
        public int TimeTaken { get; set; }
        public String Observations { get; set; }
        public string RealizationDate { get; set; }
        private static void EnsureHistoricPopulated(ApplicationDbContext dbContext)
        {
            
            dbContext.Difficulties.AddRange(
                    new Difficulty { Level = "Facil", Comment = "Dificuldade Facil" },
                    new Difficulty { Level = "Intermedia", Comment = "Dificuldade Intermedia" },
                    new Difficulty { Level = "Dificil", Comment = "Dificuldade Dificil" }
                );
            dbContext.Seasons.AddRange(
                new Season { SeasonName = "Primavera" },
                new Season { SeasonName = "Verao" },
                new Season { SeasonName = "Outono" },
                new Season { SeasonName = "Invera" }

            );
            dbContext.Slopes.AddRange(
                new Slope { SlopeType = "Inclinacao Baixa", SlopeComment = "Trail" },
                new Slope { SlopeType = "Inclinacao Media", SlopeComment = "Trail" },
                new Slope { SlopeType = "Inclinacao Alta", SlopeComment = "Trail" }
            );
            dbContext.Trails.AddRange(
                new Trail { Name = "Trilho Serra 1", IsActivated = true, Duration = 90, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 1, SeasonID = 1, SlopeID = 1 },
                   new Trail { Name = "Trilho Serra 2", IsActivated = true, Duration = 120, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 2, SeasonID = 2, SlopeID = 3 },
                   new Trail { Name = "Trilho Serra 3", IsActivated = false, Duration = 160, DistanceToTravel = 13, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 2, SeasonID = 3, SlopeID = 2 },
                   new Trail { Name = "Trilho Serra 4", IsActivated = true, Duration = 200, DistanceToTravel = 15, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 2, SeasonID = 2, SlopeID = 1 }
                );

            dbContext.Tourists.AddRange(
                new Tourist { Name = "João Silva", Age = 25, CC = "14255115", Phone = "926263545", Email = "joaoooo@gmail.com" },
                 new Tourist { Name = "Carlos Alberto", Age = 25, CC = "14255123", Phone = "926263245", Email = "carloooos@gmail.com" },
                  new Tourist { Name = "Rute Marreco", Age = 25, CC = "14255131", Phone = "926263145", Email = "ruuuuute@gmail.com" }
            );

            dbContext.Historics.AddRange(
              new Historic { TrailID = 1, TouristID = 1, TimeTaken = 120, Observations = "No observations", RealizationDate = "21/10/2017" },
              new Historic { TrailID = 2, TouristID = 1, TimeTaken = 75, Observations = "No observations", RealizationDate = "22/10/2017" },
              new Historic { TrailID = 3, TouristID = 1, TimeTaken = 180, Observations = "No observations", RealizationDate = "23/10/2017" },
              new Historic { TrailID = 4, TouristID = 1, TimeTaken = 200, Observations = "No observations", RealizationDate = "24/10/2017" }
           );


        }
    }

}
