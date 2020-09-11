using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Contexts;
using Bargain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bargain.Repositories
{
    public class MoviesRepository : BaseRepository, IMoviesRepository
    {
        public MoviesRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<dynamic>> ListAsync()
        {
            return await _context.Movie
                .AsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Code,
                    x.Slug,
                    x.GenreId,
                    Genre = x.Genre.Desc
                })
                .ToListAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _context.Movie.Include(x => x.Genre).AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            return await _context.Movie.Include(p => p.Genre).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            _context.Movie.Update(movie);
        }

        public void Remove(Movie movie)
        {
            _context.Movie.Remove(movie);
        }
    }
}
