using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {
        public int TrailID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int DistanceToTravel { get; set; }
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public bool IsActivated { get; set; }
        
            //Tabela Dificuldade
        public Difficulty Difficulty { get; set; }
        public int DifficultyID { get; set; }

        //Tabela Season
        public Season Season{ get; set; }
        public int SeasonID { get; set; }

        //Tabela Desnível
        public Slope Slope { get; set; }
        public int SlopeID { get; set; }

        //Tabela Status_Trail
        public ICollection<Status_Trail> StatusTrails { get; set; }
        
        //Tabela Stage_Trail
        public ICollection<Stage_Trail> StagesTrails { get; set; }

    }
}
