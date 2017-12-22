using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{

    public class Historic
    {

        public int HistoricID { get; set; }

        public int TimeTaken { get; set; }
        public string Observations { get; set; }
        public DateTime RealizationDate { get; set; }

        

        public Difficulty Difficulty  { get; set; }
        public int? DifficultyID { get; set; }


        public Trail Trail { get; set; }
        public int TrailID { get; set; }

        public Tourist Tourist { get; set; }
        public int TouristID { get; set; }

    }
}
