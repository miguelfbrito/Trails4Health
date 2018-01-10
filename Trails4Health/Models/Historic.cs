using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{

    public class Historic
    {

        public int HistoricID { get; set; }

        [Range(30, 500, ErrorMessage = "Tempo limitado entre 30 e 500 minutos.")]
        public int TimeTaken { get; set; }

        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Tamanho limitado entre 10 e 2000 caracteres.")]
        public string Observations { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [CheckDateRange()]
        public DateTime RealizationDate { get; set; }

  
        public Difficulty Difficulty  { get; set; }
        public int? DifficultyID { get; set; }


        public Trail Trail { get; set; }
        public int TrailID { get; set; }

        public Tourist Tourist { get; set; }
        public int TouristID { get; set; }



    }

}

public class CheckDateRangeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dataInicioPlataforma = DateTime.Parse("01/01/2017");
        DateTime d = (DateTime)value;
        if (d <= DateTime.Now && d >= dataInicioPlataforma )
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Data inválida");
    }

}