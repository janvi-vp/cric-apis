using cric_api.DTOs.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.Repository.Utilities
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResponse<T>> ToPaginatedAsync<T>(this IQueryable<T> source,
            IPaginationRequest paginationRequest) where T : class
        {
            var pageNumber = paginationRequest.PageNumber;
            var pageSize = paginationRequest.PageSize;
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));

            IQueryable<T> baseQuery = source.AsNoTracking();

            var total = await baseQuery.CountAsync(ct);

            var paged = baseQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var items = await paged.ToListAsync(ct);

            return new PaginatedResponse<T>(items, total, pageNumber, pageSize);
        }
    }
}
