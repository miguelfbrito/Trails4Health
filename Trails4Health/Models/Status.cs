using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Status
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }

        //Tabela Status_Trail
        public ICollection<Status_Trails> StatusTrails { get; set; }

    }
}

