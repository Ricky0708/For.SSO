using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For.SSO.Services.Repository
{
    public static class RepositoryIQueryableExtensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            var objectQuery = source as ObjectQuery<T>;
            if (objectQuery != null)
            {
                return objectQuery.Include(path);
            }
            return source;
        }
    }
}
