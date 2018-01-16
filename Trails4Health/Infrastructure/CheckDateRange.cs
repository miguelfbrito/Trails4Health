using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health
{
    public class CheckDateRange : ValidationAttribute
    {
        public String FirstDate { get; set; }
        public String EndDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dataB = DateTime.ParseExact(FirstDate, "dd/MM/yyyy", null);

            if (EndDate == "NOW")
            {
                EndDate = DateTime.Now.ToString("dd/MM/yyyy");
            }

            DateTime dataE = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);

           

            DateTime d = (DateTime)value;
            if (d <= dataE && d >= dataB)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Data inválida");
        }

    }
}
