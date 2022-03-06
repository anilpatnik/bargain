using System.Threading.Tasks;
using Bargain.Repositories.Contexts;
using Bargain.Repositories.Interfaces;

namespace Bargain.Repositories
{
    public class SaveRepository : BaseRepository, ISaveRepository
    {        
        public SaveRepository(AppDbContext context) : base(context) { }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
