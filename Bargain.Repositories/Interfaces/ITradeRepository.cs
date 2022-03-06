using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;

namespace Bargain.Repositories.Interfaces
{
    public interface ITradeRepository
    {
        Task<IEnumerable<Trade>> ListAsync(int id);

        Task<Trade> FindByIdAsync(int id);

        void Add(Trade payload);
        
        void Update(Trade payload);
        
        void Remove(Trade payload);
    }
}
