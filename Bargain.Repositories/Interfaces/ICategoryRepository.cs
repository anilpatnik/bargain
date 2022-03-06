using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;

namespace Bargain.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<Category> FindByIdAsync(string id);

        void Add(Category payload);
        
        void Update(Category payload);
    }
}
