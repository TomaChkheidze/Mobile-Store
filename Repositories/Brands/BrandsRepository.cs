using Microsoft.EntityFrameworkCore;
using Mobile_Store.Data;
using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly MobileStoreContext _context;

        public BrandsRepository(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
