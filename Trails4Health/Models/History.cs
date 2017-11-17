using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    //DIFICULDADES
    


    public class History
    {
        public static int DIFICULDADE_FACIL = 1;
        public static int DIFICULDADE_INTERMEDIA = 2;
        public static int DIFICULDADE_DIFICIL = 3;

        public int idTrilho { get; set; }
        public int tempoDemorado { get; set; }
        public String observacoes { get; set; }
        public DateTime dataRealizacao { get; set; }
        public int dificuldade { get; set; }
    }
}
