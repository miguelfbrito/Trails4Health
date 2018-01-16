using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trails4Health.Models
{
    public class EFHistoricRepository : ITourist_TrailRepository
    {
        private ApplicationDbContext dbContext;

        public EFHistoricRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Tourist_Trail> Historics => dbContext.Tourist_Trails;
    }
}