using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Status_Trail
    {

        //FK Trilhos
        public int TrailID { get; set; }
        public Trail Trail { get; set; }

        //FK Status
        public int StatusID { get; set; }
        public Status Status { get; set; }
    }
}

