using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    //DIFICULDADES
    


    public class History
    {
        public static int DIFFICULTY_EASY = 1;
        public static int DIFFICULTY_INTERMEDIATE = 2;
        public static int DIFFICULTY_HARD = 3;
        
        public int IdHistory { get; set; }
        public int IdTourist { get; set; }
        public int IdTrail { get; set; }
        public int IdDifficulty { get; set; }
        public int TimeTaken { get; set; }
        public String Observations { get; set; }
        public DateTime RealizationDate { get; set; }

    }
}
