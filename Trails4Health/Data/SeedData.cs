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
                new Difficulty { DifficultyLevel = "Facil", DifficultyComment = "Trilho para Iniciantes" },
                new Difficulty { DifficultyLevel = "Normal", DifficultyComment = "Trilho para pessoas que praticam com alguma frequencia" },
                new Difficulty { DifficultyLevel = "Dificil", DifficultyComment = "Trilho para aqueles que querem aumentar o nivel de dificuldade dos seus percursos" },
                new Difficulty { DifficultyLevel = "Muito Dificil", DifficultyComment = "Trilho recomendado a profissionais de desporto fisico" }
            );
            dbContext.Seasons.AddRange(
                new Season { SeasonName = "Primavera" },
                 new Season { SeasonName = "Verao" },
                  new Season { SeasonName = "Outono" },
                   new Season { SeasonName = "Inverno" }

            );
            dbContext.Slopes.AddRange(
                new Slope { SlopeType = "Pouco Inclinado", SlopeComment = "Trilho com baixa inclinacao durante a sua maior parte do percurso" },
                 new Slope { SlopeType = "Inclinacao Normal", SlopeComment = "Trilho com uma inclinacao bastante plana na sua maior parte do percurso" },
                  new Slope { SlopeType = "Inclinacao Elevada", SlopeComment = "Trilho com inclinacao elevada" },
                   new Slope { SlopeType = "Muito Inclinada", SlopeComment = "Trilho com inclinacao muito elevada. Recomendado a profissionais de desporto fisico" }

            );
            dbContext.Trails.AddRange(
                new Trail { Name = "Trilho Serra 1",IsActivated=true, Duration = 120, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 1, SeasonID = 1, SlopeID = 1 }
    
                );
            
        }
    }
}
