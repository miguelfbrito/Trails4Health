using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Health.Models.ViewModels
{
    public class ViewModelTrailsDetails
    {
        public Trail trail;
        public IQueryable<Status_Trail> status_trail;
    }
}
