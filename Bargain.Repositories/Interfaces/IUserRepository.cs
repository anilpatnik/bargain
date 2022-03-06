using System.Threading.Tasks;
using Bargain.Models;

namespace Bargain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(User payload);        
    }
}
