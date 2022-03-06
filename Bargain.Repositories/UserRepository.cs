using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Bargain.Repositories.Interfaces;
using System.Linq;

namespace Bargain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }        

        public async Task<User> FindByEmailAsync(User payload)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(x => !x.Inactive)
                .Where(x => x.RecordId == payload.RecordId)
                .Where(x => x.Email == payload.Email)                
                .FirstOrDefaultAsync();
        }
    }
}
