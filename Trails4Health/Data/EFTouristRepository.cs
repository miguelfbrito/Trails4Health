using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models
{
    public class EFTouristRepository : ITouristRepository
    {
        private ApplicationDbContext dbContext;

        public EFTouristRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Tourist> Tourists => dbContext.Tourists;

    }
}
