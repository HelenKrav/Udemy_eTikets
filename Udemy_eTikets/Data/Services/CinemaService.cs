using Udemy_eTikets.Data.Base;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class CinemaService: EntityBaseRepository<Cinema> , ICinemaService
    {
        public CinemaService(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
