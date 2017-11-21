using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FakeStageRepository : IStageRepository
    {

        IEnumerable<Stage> Stages => new List<Stage>

       {

            new Stage {StageID = 1, StageName = "Etapa adjacente a Lagoa Comprida",
                StageStartLoc = "Lagoa Comprida", StageEndLoc = "Segunda Lagoa",
                Distance = 10, Duration = 4 //dist kms duração horas
            },
            new Stage {StageID = 1, StageName = "Etapa do Sabugueiro ",
                StageStartLoc = "Floresta", StageEndLoc = "Sabugueiro",
                Distance = 1, Duration = 1 //dist kms duração horas
            }


    };

    }
}
