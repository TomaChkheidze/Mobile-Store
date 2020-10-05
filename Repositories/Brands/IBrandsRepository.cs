using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Repositories
{
    public interface IBrandsRepository
    {
        Task<List<Brand>> GetAllAsync();
    }
}
