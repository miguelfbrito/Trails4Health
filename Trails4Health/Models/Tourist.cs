using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Tourist
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int TouristID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String CC { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }

        public ICollection<Historic> Historics { get; set; }
    }
}
