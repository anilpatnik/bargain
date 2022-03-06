using Bargain.Models;
using Bargain.Services.Common;
using System.Threading.Tasks;

namespace Bargain.Services.Interfaces
{
    public interface IUserService
    {
        Task<Response<dynamic>> GetAuthUserAsync(User payload);
    }
}
