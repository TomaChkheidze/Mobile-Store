using Microsoft.EntityFrameworkCore;
using Mobile_Store.Commons;
using Mobile_Store.Data;
using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Repositories
{
    public class PhonesRepository : IPhonesRepository
    {
        private readonly MobileStoreContext _context;

        public PhonesRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<Phone> GetAsync(int id)
        {
            return await _context.Phones.Where(x => x.Id == id).Include(x => x.Brand).FirstOrDefaultAsync();
        }

        public async Task<PagedResult<Phone>> GetAllAsync(Func<IQueryable<Phone>, IQueryable<Phone>> filter, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Phone> query = filter(_context.Phones.Include(x => x.Brand).AsQueryable());
            return await PagedResult<Phone>.CreateAsync(query, pageIndex, pageSize);
        }
    }
}
