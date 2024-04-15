using Microsoft.EntityFrameworkCore;

namespace Reddit.Repositories
{
    public class PagedList<T>
    {
        private PagedList(List<T> items, int pageNumber, int pageSize, int totalCount) {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Items { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasNextPage => (PageSize * PageNumber) < TotalCount;

        public bool HasPreviousPage => PageNumber > 1;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<T>(items, pageNumber, pageSize, totalCount);
        }
    }
}
