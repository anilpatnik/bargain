using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;

namespace Bargain.Services.Interfaces
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> ListAsync();
        
        Task<Response<Genre>> SaveAsync(Genre genre);
        
        Task<Response<Genre>> UpdateAsync(int id, Genre genre);
        
        Task<Response<Genre>> DeleteAsync(int id);
    }
}
