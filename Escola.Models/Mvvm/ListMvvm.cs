using Microsoft.EntityFrameworkCore;

namespace eGreja.Models.Mvvm
{
    public class ListMvvm<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }

        public ListMvvm(List<T> items, int totalItems, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalItems == 0
                ? 0
                : (int)Math.Ceiling(totalItems / (double)pageSize);

            AddRange(items);
        }

        public static async Task<ListMvvm<T>> CreateAsync(IQueryable<T> source, int pageIndex = 1, int pageSize = 30, bool withPagination = true)
        {
            if (pageIndex <= 0)
                pageIndex = 1;

            if (pageSize <= 0)
                pageSize = 30;

            var totalItems = await source.CountAsync();

            if (!withPagination)
                pageSize = totalItems;

            List<T> items;

            if (totalItems > pageSize)
            {
                items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                items = await source.ToListAsync();
            }

            return new ListMvvm<T>(items, totalItems, pageIndex, pageSize);
        }

        public object GetPagination()
        {
            return new
            {
                PageIndex,
                PageSize,
                TotalPages,
                TotalItems,
                withPagination = true
            };
        }
    }
}