using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models
{
    public class EFProductRepository : IHistoricRepository {
        private ApplicationDbContext dbContext;

        public EFProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Historic> Historics => dbContext.Historics;

    }
}
