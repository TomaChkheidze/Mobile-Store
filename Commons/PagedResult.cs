using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Commons
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool HasNextPage
        {
            get { return (PageIndex < TotalPages); }
        }

        public PagedResult()
        {

        }

        public PagedResult(List<T> items, int count, int pageIndex = 1, int pageSize = 5)
        {
            Data = items;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public static async Task<PagedResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            List<T> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<T>(items, count, pageIndex, pageSize);
        }
    }
}
