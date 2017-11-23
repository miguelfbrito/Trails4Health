using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Slope
    {
        public int SlopeID { get; set; }
        public string SlopeType { get; set; }
        public string SlopeComment { get; set; }
        public ICollection<Trail> Trails { get; set; }
    }
}