using System.Threading.Tasks;

namespace Bargain.Repositories.Interfaces
{
    public interface ISaveRepository
    {
        Task CompleteAsync();
    }
}
