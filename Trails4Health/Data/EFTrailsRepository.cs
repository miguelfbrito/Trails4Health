using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EFTrailsRepository : ITrailsRepository
    {
        private ApplicationDbContext dbContext;

        public EFTrailsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public IEnumerable<Trail> Trails => dbContext.Trails;
    }
}
