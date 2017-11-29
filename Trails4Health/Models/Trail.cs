﻿using System;
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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome Invalido")]
        [RegularExpression(@"[a-zA-Z0-9\s\\._\\-\\ ]{3,}", ErrorMessage = "Nome Invalido, caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Please enter the Trail Name")]
        public string Name { get; set; }
        [RegularExpression(@"[\d]{1,}", ErrorMessage = "Duracao errada, letras e caracteres especiais nao permitidoso")]
        [Required(ErrorMessage = "Please enter the Duration")]
        public int Duration { get; set; }
        [RegularExpression(@"[\d]{1,}", ErrorMessage = "Distancia errada, letras e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Please enter the Distance")]
        public int DistanceToTravel { get; set; }
        [RegularExpression(@"[a-zA-Z\s\\._\\-\\ ]{3,}", ErrorMessage = "Localizacao de Inicio Invalida,  numeros e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Please enter the Start Location")]
        public string StartLoc { get; set; }
        [RegularExpression(@"[a-zA-Z\s\\._\\-\\ ]{3,}", ErrorMessage = "Localizacao de Fim Invalida,  numeros e caracteres especiais nao permitidos")]
        [Required(ErrorMessage = "Please enter the End Location")]
        public string EndLoc { get; set; }
        public bool IsActivated { get; set; }

        //Tabela Dificuldade
        public Difficulty Difficulty { get; set; }
        public int DifficultyID { get; set; }

        //Tabela Season

        public Season Season { get; set; }

        public int SeasonID { get; set; }

        //Tabela Desnível
        public Slope Slope { get; set; }
        public int SlopeID { get; set; }

        //Tabela Status_Trail
        public ICollection<Status_Trail> StatusTrails { get; set; }


        //Tabela Stage_Trail
        public ICollection<Stage_Trail> StagesTrails { get; set; }

        public ICollection<Historic> Historics { get; set; }
    }
}