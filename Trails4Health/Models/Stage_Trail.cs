using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Stage_Trail
    {
        //FK Trilhos
        public int TrailID { get; set; }
        public Trail Trail { get; set; }

        //FK Etapas
        public int StageID { get; set; }
        public Stage Stage { get; set; }

        public int StageOrder { get; set; }
        public bool Activated { get; set; }

    }
}

