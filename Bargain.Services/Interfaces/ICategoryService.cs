using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Services.Common;

namespace Bargain.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync(bool? inactive);

        Task<Response<Category>> FindByIdAsync(string id);

        Task<Response<Category>> SaveAsync(Category payload);
        
        Task<Response<Category>> UpdateAsync(string id, Category payload);
    }
}
