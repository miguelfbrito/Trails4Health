using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public interface IHistoryRepository
    {
        IEnumerable<History> History { get; }
    }
}
