using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class Trail
    {


        public int TrailID { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome Invalido - Menos de 3 caracteres ou mais de 30.")]
        [RegularExpression(@"[a-zA-Z0-9\s\\._\\-]{3,}", ErrorMessage = "Nome Inválido - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza o nome do trilho")]
        public string Name { get; set; }
        [Range(0, 1000, ErrorMessage = "O valor da Duração so pode ser entre 0 e 1000")]
        [Required(ErrorMessage = "Por favor introduza a duração do trilho")]
        public int Duration { get; set; }
        [Range(0, 100, ErrorMessage = "O valor da distancia so pode ser entre 0 e 100")]
        [Required(ErrorMessage = "Por favor introduza a distância a percorrer")]
        public int DistanceToTravel { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Localização de Inicio Invalida - Menos de 3 caracteres ou mais de 30.")]
        [RegularExpression(@"[a-zA-Z\s\\._\\-]{3,}", ErrorMessage = "Localizacao de Inicio Inválida - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza a localização inicial do trilho")]
        public string StartLoc { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Localização de Fim Inválida - Menos de 3 caracteres ou mais de 30.")]
        [RegularExpression(@"[a-zA-Z\s\\._\\-]{3,}", ErrorMessage = "Localizacao de Fim Inválida - Contém caracteres inválidos")]
        [Required(ErrorMessage = "Por favor introduza a localização final do trilho")]
        public string EndLoc { get; set; }

        public bool IsActivated { get; set; }

        public byte[] TrailImage { get; set; }

        //Tabela Season

        public Season Season { get; set; }

        public int SeasonID { get; set; }

        //Tabela Desnível
        public Slope Slope { get; set; }
        public int SlopeID { get; set; }


        //Tabela Status_Trail
        public ICollection<Status_Trails> StatusTrails { get; set; }


        //Tabela Stage_Trail
        public ICollection<Stage_Trail> StagesTrails { get; set; }

        public ICollection<Historic> Historics { get; set; }
    }
}


