using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy_eTikets.Data.Base;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext appDbContext): base(appDbContext) { }
        
    }
}
