using Bargain.Models;
using Bargain.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bargain.Services.Interfaces
{
    public interface ITradeService
    {
        Task<IEnumerable<Trade>> ListAsync(int id);

        Task<Response<Trade>> FindByIdAsync(int id);

        Task<Response<Trade>> SaveAsync(Trade payload);

        Task<Response<Trade>> UpdateAsync(int id, Trade payload);

        Task<Response<Trade>> DeleteAsync(int id);
    }
}
