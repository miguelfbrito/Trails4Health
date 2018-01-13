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
      //  [CheckDateRange(FirstDate = "01/01/1900", EndDate = "01/01/2012" )]
        public DateTime? DateOfBirth { get; set; }

        public String CC { get; set; }

        [RegularExpression("^[92]{1}[1236]{1}[0-9]{1}[\\s|-]?[0-9]{3}[\\s|-]?[0-9]{3}", ErrorMessage = "Formato incorreto")]
        public String Phone { get; set; }

        [EmailAddress]
        public String Email { get; set; }
        public String TipoUtilizador { get; set; }

        public ICollection<Historic> Historics { get; set; }
    }
}

