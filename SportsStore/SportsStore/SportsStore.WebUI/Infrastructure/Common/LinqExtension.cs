using System.Collections.Generic;
using System.Linq;

namespace SportsStore.WebUI.Infrastructure.Common
{
    public static class LinqExtension
    {
        public static IEnumerable<T> GetDataOfPage<T>(this IEnumerable<T> data, int page, int pageSize)
        {
            var result = data.Skip((page - 1) * pageSize)
                           .Take(pageSize);            

            return result;
        }
    }
}