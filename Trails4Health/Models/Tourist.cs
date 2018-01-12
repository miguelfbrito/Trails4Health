using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trails4Health.Models
{
    public class Tourist
    {

        public int TouristID { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Complete o seu nome")]
        public String Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [CheckDateRange(FirstDate = "a", EndDate = "b")]
        public DateTime DateOfBirth { get; set; }
        public String CC { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String TipoUtilizador { get; set; }

        public ICollection<Historic> Historics { get; set; }
    }
}

