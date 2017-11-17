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

            new History {IdTourist = 1, IdTrail = 1, IdDifficulty=1,TimeTaken = 60, RealizationDate = new DateTime(2017, 10, 20), Observations = "Trilho agradável, boas paisagens"},
            new History {IdTourist = 2, IdTrail = 2, IdDifficulty=3,TimeTaken = 120, RealizationDate = new DateTime(2017, 10, 24), Observations = "Trilho montanhoso, boas paisagens"},
            new History {IdTourist = 3, IdTrail = 3, IdDifficulty=2,TimeTaken = 90, RealizationDate = new DateTime(2017, 10, 25), Observations = "Trilho agradável, boas paisagens"},
        };

    }
}
