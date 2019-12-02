using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieShop.Entities.Common
{
    public class PaginatedList<T>: List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            AddRange(items);
        }

        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < TotalPages);

        public static PaginatedList<T> GetPaged(IQueryable<T> source, int pageIndex, int pageSize,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null,
                                                Expression<Func<T, bool>> filter = null)
        {

            IQueryable<T> query = source;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderedQuery != null)
            {
                query = orderedQuery(query);
            }

           
            var count = query.Count();
            var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}