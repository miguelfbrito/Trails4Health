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
        protected DateTime begginingDate;
        protected DateTime endingDate;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dataB = DateTime.Parse(FirstDate);
            DateTime dataE = DateTime.Parse(EndDate);

            if (EndDate == "NOW")
            {
                dataE = DateTime.Now;
            }

            DateTime d = (DateTime)value;
            if (d <= dataE && d >= dataB)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Data inválida");
        }

    }
}
