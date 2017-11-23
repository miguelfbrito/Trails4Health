using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Stage_Trail
    {
        public int StageId { get; set; }
        public Stage Stage { get; set; }

        public int TrailId { get; set; }
        public Trail Trail { get; set; }

        public int Order { get; set; }
        public bool IsActivated { get; set; }

        

    }
}
