using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabeticalNavigation.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            pagination.Setup(queryable.Count());

            return queryable
                        .Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                        .Take(pagination.RecordsPerPage);

        }
    }
}
