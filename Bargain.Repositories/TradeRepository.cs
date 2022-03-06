using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Bargain.Repositories.Interfaces;
using System.Linq;

namespace Bargain.Repositories
{
    public class TradeRepository : BaseRepository, ITradeRepository
    {
        public TradeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Trade>> ListAsync(int id)
        {
            return await _context.Trades
                .Include(x => x.TradeFiles)
                .Where(x => x.TradeUsers.Any(y => y.UserId == id))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Trade> FindByIdAsync(int id)
        {
            return await _context.Trades.FindAsync(id);
        }

        public void Add(Trade payload)
        {
            _context.Trades.Add(payload);
        }

        public void Update(Trade payload)
        {
            _context.Trades.Update(payload);
        }

        public void Remove(Trade payload)
        {
            _context.Trades.Remove(payload);
        }
    }
}
