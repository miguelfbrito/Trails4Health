using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health
{
    public class CheckCartaoCidadao : ValidationAttribute
    {
        //

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if(value != null)
            {
                string id = value.ToString();
                if (id.Length >= 9)
                {
                    int total = 0;
                    int m = 2;
                    for (int i = 0; i < 8; i++)
                    {
                        total += m * (int)id[i];
                        m++;
                    }

                    total = total % 11;

                    if (total.ToString() == id[8].ToString())
                    {
                        return ValidationResult.Success;
                    }
                }
            }
           

          

            return new ValidationResult(ErrorMessage ?? "Dados inválidos");
        }

    }
}
