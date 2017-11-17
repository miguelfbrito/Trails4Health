using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class FakeHistoryRepository : IHistoryRepository
    {

        IEnumerable<History> IHistoryRepository.History => new List<History>
        {

            new History {tempoDemorado = 60, dataRealizacao = new DateTime(2017, 10, 20), observacoes = "Trilho agradável, boas paisagens", dificuldade = History.DIFICULDADE_FACIL},
            new History {tempoDemorado = 120, dataRealizacao = new DateTime(2017, 10, 24), observacoes = "Trilho montanhoso, boas paisagens", dificuldade = History.DIFICULDADE_DIFICIL},
            new History {tempoDemorado = 90, dataRealizacao = new DateTime(2017, 10, 25), observacoes = "Trilho agradável, boas paisagens", dificuldade = History.DIFICULDADE_INTERMEDIA},
        };

    }
}
