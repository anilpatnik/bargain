using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;

namespace Bargain.Repositories.Interfaces
{
    public interface IGenresRepository
    {
        Task<IEnumerable<Genre>> ListAsync();
        
        Task AddAsync(Genre genre);
        
        Task<Genre> FindByIdAsync(int id);
        
        void Update(Genre genre);
        
        void Remove(Genre genre);
    }
}
