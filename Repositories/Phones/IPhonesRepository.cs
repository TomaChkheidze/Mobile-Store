using Mobile_Store.Commons;
using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Repositories
{
    public interface IPhonesRepository
    {
        Task<Phone> GetAsync(int id);
        Task<PagedResult<Phone>> GetAllAsync(Func<IQueryable<Phone>, IQueryable<Phone>> filter, int pageIndex, int pageSize);
    }
}
