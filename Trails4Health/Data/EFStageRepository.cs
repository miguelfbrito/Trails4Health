using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trails4Health.Models;

namespace Trails4Health.Data
{
    public class EFStageRepository : IStageRepository
    {
        private ApplicationDbContext dbContext;

        public EFStageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Stage> Products => dbContext.Stages;
    }
}
