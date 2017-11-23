using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Difficulty
    {
        public int DifficultyID { get; set; }
        public string Level { get; set; }
        public string Comment { get; set; }
        public ICollection<Trail> Trails { get; set; }
        public ICollection<Historic> Historics { get; set; }
    }
}
