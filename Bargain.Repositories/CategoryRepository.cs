using System.Collections.Generic;
using System.Threading.Tasks;
using Bargain.Models;
using Bargain.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Bargain.Repositories.Interfaces;
using System;

namespace Bargain.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> FindByIdAsync(string id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.RecordId == new Guid(id));
        }

        public void Add(Category payload)
        {
            _context.Categories.Add(payload);
        }

        public void Update(Category payload)
        {
            _context.Categories.Update(payload);
        }
    }
}
