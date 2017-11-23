using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models
{
    public class EFHistoricRepository : IHistoricRepository {
        private ApplicationDbContext dbContext;

        public EFHistoricRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Historic> Historics => dbContext.Historics;

    }
}
