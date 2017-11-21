using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    //DIFICULDADES
    


    public class Historic
    {
        public static int DIFFICULTY_EASY = 1;
        public static int DIFFICULTY_INTERMEDIATE = 2;
        public static int DIFFICULTY_HARD = 3;
        
        public int HistoricID { get; set; }
        public int TouristID { get; set; }
        public int TrailID{ get; set; }
        public int DifficultyID { get; set; }
        public int TimeTaken { get; set; }
        public String Observations { get; set; }
        public string RealizationDate { get; set; }

    }
}
