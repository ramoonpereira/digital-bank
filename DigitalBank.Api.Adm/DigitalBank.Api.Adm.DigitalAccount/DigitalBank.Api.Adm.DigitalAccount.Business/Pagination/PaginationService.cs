using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Api.Adm.DigitalAccount.Business.Pagination
{
    public static class PaginationService
    {
        public static async Task<PagedResultBase<T>> GetPagination<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            PagedResultBase<T> pagination = new PagedResultBase<T>
            {
                TotalItems = query.Count(),
                PageSize = pageSize,
                CurrentPage = page,
            };

            pagination.TotalPages = ((int)Math.Ceiling((double)pagination.TotalItems / pagination.PageSize));

            int skip = (page - 1) * pageSize;

            pagination.Result = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return pagination;
        }
    }
}
