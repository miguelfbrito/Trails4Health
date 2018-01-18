using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrail
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome Invalido - Menos de 3 caracteres ou mais de 50.")]
        [RegularExpression(@"[a-zA-Z0-9\s\\._\\-]{3,}", ErrorMessage = "Nome Inválido - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza o nome do trilho")]
        public string Name { get; set; }
        [Range(5, 6000, ErrorMessage = "O valor da Duração so pode ser entre 30 e 6000")]
        [Required(ErrorMessage = "Por favor introduza a duração do trilho")]
        public int Duration { get; set; }
        [Range(1, 100, ErrorMessage = "O valor da distancia so pode ser entre 0 e 100")]
        [Required(ErrorMessage = "Por favor introduza a distância a percorrer")]
        public int DistanceToTravel { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Localização de Inicio Invalida - Menos de 3 caracteres ou mais de 50.")]
        [RegularExpression(@"[a-zA-Z\s\\._\\-]{3,}", ErrorMessage = "Localizacao de Inicio Inválida - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza a localização inicial do trilho")]
        public string StartLoc { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Localização de Fim Inválida - Menos de 3 caracteres ou mais de 30.")]
        [RegularExpression(@"[a-zA-Z\s\\._\\-]{3,}", ErrorMessage = "Localizacao de Fim Inválida - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza a localização final do trilho")]
        public string EndLoc { get; set; }

        public int SeasonID { get; set; }
        public int SlopeID { get; set; }
        public int StatusID { get; set; }
        public bool IsActivated { get; set; }
        

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Por favor introduza uma imagem para o trilho! (Imagem não poderá ser alterada no futuro)")]
        public IFormFile ImageFile { get;set; }

        [StringLength(5000, MinimumLength = 3, ErrorMessage = "Descrição Inválida - Menos de 3 caracteres ou mais de 5000.")]
        [Required(ErrorMessage = "Por favor introduza uma descrição válida")]
        public string Description { get; set; }


    }
}
