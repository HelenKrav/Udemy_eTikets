using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Udemy_eTikets.Data.Base;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class MovieService: EntityBaseRepository<Movie> , IMovieService
    {

        private readonly AppDbContext _appDbContext;


        public MovieService(AppDbContext appDbContext):base(appDbContext)
        {
                _appDbContext = appDbContext;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _appDbContext.Movies
                                                            .Include(c=>c.Cinema)
                                                            .Include(p=>p.Producer)
                                                            .Include(am=>am.Actors_Movies)
                                                            .ThenInclude(a=>a.Actor)
                                                            .FirstOrDefaultAsync(n=>n.Id == id);

            return await movieDetails;
        }
    }
}
