using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Trails4Health.Models
{
    public class Stage
    {



        public int StageId { get; set; }

        [RegularExpression(@"[a-zA-Z0-9\\._\\-\\ ]{3,}", ErrorMessage = "Nome de etapa Errado, caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Por favor escreva o nome da Etapa")]
        public string StageName { get; set; }

        [RegularExpression(@"[a-zA-Z\\._\\-\\ ]{3,}", ErrorMessage = "Nome de inicio Errado, numeros e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Por favor escreva a localizacao de inicio")]
        public string StageStartLoc { get; set; }

        [RegularExpression(@"[a-zA-Z\\._\\-\\ ]{3,}", ErrorMessage = "Nome de fim Errado, numeros e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Por favor escreva a localizacao de fim")]
        public string StageEndLoc { get; set; }

        public bool IsActivated { get; set; }

        [RegularExpression(@"[a-zA-Z0-9\\._\\-\\ ]{3,}", ErrorMessage = "Geolocalizacao errada, caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Por favor indique a geolocalizacao")]
        public string Geolocalization { get; set; }

        [RegularExpression(@"[\d]{1,}", ErrorMessage = "Distancia errada, letras e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Por favor indique a distancia")]
        public int Distance { get; set; }

        [RegularExpression(@"[\d]{1,}", ErrorMessage = "Duracao errada, letras e caracteres especiais nao permitidoso")]
        [Required(ErrorMessage = "Por favor indique a duracao")]
        public int Duration { get; set; }

        public ICollection<Stage_Trail> StagesTrails { get; set; }
    }
}
