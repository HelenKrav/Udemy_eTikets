using System.Threading.Tasks;
using Udemy_eTikets.Data.Base;
using Udemy_eTikets.Data.ViewModels;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public interface IMovieService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
    }
}
