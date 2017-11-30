﻿using System;
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


            if (!dbContext.Seasons.Any())
            {
                EnsureSeasonsPopulated(dbContext);
            }

            dbContext.SaveChanges();

            if (!dbContext.Difficulties.Any())
            {
                EnsureDifficultiesPopulated(dbContext);
            }

            dbContext.SaveChanges();

            if (!dbContext.Slopes.Any())
            {
                EnsureSlopesPopulated(dbContext);
            }

            dbContext.SaveChanges();



            if (!dbContext.Trails.Any())
            {
                EnsureTrailsPopulated(dbContext);
            }

            dbContext.SaveChanges();

            if (!dbContext.Tourists.Any())
            {
                EnsureTouristsPopulated(dbContext);
            }

            dbContext.SaveChanges();

            if (!dbContext.Stages.Any())
            {
                EnsureStagesPopulated(dbContext);
            }

            dbContext.SaveChanges();

            if (!dbContext.Historics.Any())
            {
                EnsureHistoricsPopulated(dbContext);
            }

            dbContext.SaveChanges();
        }

        private static void EnsureDifficultiesPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Difficulties.AddRange(
                new Difficulty { Level = "Facil", Comment = "Trilho para Iniciantes" },
                new Difficulty { Level = "Normal", Comment = "Trilho para pessoas que praticam com alguma frequencia" },
                new Difficulty { Level = "Dificil", Comment = "Trilho para aqueles que querem aumentar o nivel de dificuldade dos seus percursos" },
                new Difficulty { Level = "Muito Dificil", Comment = "Trilho recomendado a profissionais de desporto fisico" }
            );

        }


        private static void EnsureSeasonsPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Seasons.AddRange(
                    new Season { SeasonName = "Primavera" },
                     new Season { SeasonName = "Verao" },
                      new Season { SeasonName = "Outono" },
                       new Season { SeasonName = "Inverno" }

                );
        }

        private static void EnsureSlopesPopulated(ApplicationDbContext dbContext)
        {

            dbContext.Slopes.AddRange(
                new Slope { Type = "Pouco Inclinado", Comment = "Trilho com baixa inclinacao durante a sua maior parte do percurso" },
                 new Slope { Type = "Inclinacao Normal", Comment = "Trilho com uma inclinacao bastante plana na sua maior parte do percurso" },
                  new Slope { Type = "Inclinacao Elevada", Comment = "Trilho com inclinacao elevada" },
                   new Slope { Type = "Muito Inclinada", Comment = "Trilho com inclinacao muito elevada. Recomendado a profissionais de desporto fisico" }


            );
        }

        private static void EnsureTrailsPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Trails.AddRange(
               new Trail { Name = "Trilho Serra 1", IsActivated = true, Duration = 120, DistanceToTravel = 10, StartLoc = "Manteigas", EndLoc = "Serra", DifficultyID = 1, SeasonID = 1, SlopeID = 1 },
                new Trail { Name = "Trilho Serra 2", IsActivated = true, Duration = 130, DistanceToTravel = 20, StartLoc = "Guarda", EndLoc = "Serra", DifficultyID = 2, SeasonID = 3, SlopeID = 2 },
                 new Trail { Name = "Trilho Serra 3", IsActivated = true, Duration = 140, DistanceToTravel = 20, StartLoc = "Manteigas", EndLoc = "Guarda", DifficultyID = 4, SeasonID = 1, SlopeID = 4 },
                  new Trail { Name = "Trilho Serra 4", IsActivated = true, Duration = 200, DistanceToTravel = 50, StartLoc = "Guarda", EndLoc = "Gouveia", DifficultyID = 3, SeasonID = 4, SlopeID = 3 }
               );
        }

        private static void EnsureTouristsPopulated(ApplicationDbContext dbContext)
        {
            dbContext.Tourists.AddRange(
              new Tourist { Name = "João Silva", Age = 25, CC = "14255115", Phone = "926263545", Email = " joaoooo@gmail.com " },
               new Tourist { Name = "Carlos Alberto", Age = 25, CC = "14255123", Phone = "926263245", Email = " carloooos@gmail.com " },
                new Tourist { Name = "Rute Marreco", Age = 25, CC = "14255131", Phone = "926263145", Email = " ruuuuute@gmail.com " },
                    new Tourist
                    {
                        Name = "Carlos Ferreira",
                        Age = 25,
                        CC = "14255123",
                        Phone = "926263245",
                        Email = " carloooos@gmail.com "
                    }
          );
        }

        private static void EnsureStagesPopulated(ApplicationDbContext dbContext)
        {

            dbContext.Stages.AddRange(
                new Stage { StageName = "Etapa Grande", Geolocalization = "G(13)", StageStartLoc = "Guarda", StageEndLoc = "Floresta", IsActivated = true, Distance = 5, Duration = 60 },
                new Stage { StageName = "Etapa Curta", Geolocalization = "G(15)", StageStartLoc = "Seia", StageEndLoc = "Torre", IsActivated = false, Distance = 10, Duration = 120 }
                );
        }

        private static void EnsureHistoricsPopulated(ApplicationDbContext dbContext)
        {
                    dbContext.Historics.AddRange(
            new Historic { TrailID = 1, TouristID = 1, TimeTaken = 120, Observations = "No observations", RealizationDate = "21/10/2017" },
            new Historic { TrailID = 2, TouristID = 2, TimeTaken = 75, Observations = "No observations", RealizationDate = "22/10/2017" },
            new Historic { TrailID = 3, TouristID = 3, TimeTaken = 180, Observations = "No observations", RealizationDate = "23/10/2017" },
            new Historic { TrailID = 4, TouristID = 4, TimeTaken = 200, Observations = "No observations", RealizationDate = "24/10/2017" }
         );
        }






    }
}
