using Microsoft.EntityFrameworkCore;
using LibraryApi.Services.Base;

namespace LibraryApi.Services.Extensions
{
    public static class IQueryableExtensions
    {
        private static IQueryable<T> Set<T>()
        {
            return Enumerable.Empty<T>().AsQueryable();
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, BaseFilter filter)
        {
            return query.Skip((filter.Page.Value - 1) * filter.PageSize.Value).Take(filter.PageSize.Value);
        }

        public static async Task<PagedResponseModel<T>> ReadPage<T>(BaseFilter filter, Func<IEnumerable<T>, IQueryable<T>> queryAction)
        {
            IQueryable<T> query = Set<T>();

            query = queryAction.Invoke(query);

            int total = await query.CountAsync();
            IEnumerable<T> data = await query.Page(filter).ToListAsync();

            return new PagedResponseModel<T>(total, filter, data);
        }
    }
}