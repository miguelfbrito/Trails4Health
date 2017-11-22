using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Stage
    {
        public int StageID { get; set; }
        public string StageName { get; set; }
        public string Geolocation { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
        
        //Tabela Stage_Trail
        public ICollection<Stage_Trail> StagesTrails { get; set; }
    }
}
