using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;

namespace Bargain.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<dynamic>> ListAsync();

        Task<Movie> GetAsync(int id);

        Task AddAsync(Movie movie);
        
        Task<Movie> FindByIdAsync(int id);
        
        void Update(Movie movie);
        
        void Remove(Movie movie);
    }
}
