using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;

namespace Bargain.Services.Interfaces
{
    public interface IMoviesService
    {
        Task<IEnumerable<dynamic>> ListAsync();

        Task<Movie> GetAsync(int id);

        Task<Response<Movie>> SaveAsync(Movie movie);
        
        Task<Response<Movie>> UpdateAsync(int id, Movie movie);
        
        Task<Response<Movie>> DeleteAsync(int id);
    }
}
