using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FakeTrailsRepository : ITrailsRepository
    {
        //public IEnumerable<Trail> Trails => new List<Trail>
        //{
        //  new Trail {Name="Trilho Serra 1", AverageDuration=120, DistanceToTravel=10,Start_Loc="Manteigas",End_Loc="Serra",RecommendedTime="Summer",Is_Activated=true,ID_Difficulty=1}
        //};
        public IEnumerable<Trail> Trails => new List<Trail>
        {
            new Trail {Name="Trilho Serra 1", Duration=120, DistanceToTravel=10,StartLoc="Manteigas",EndLoc="Serra"}
        };
    }
}
