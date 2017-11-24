using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Season
    {
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        public ICollection<Trail> Trails { get; set; }
    }
}

