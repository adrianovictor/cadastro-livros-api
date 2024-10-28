using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStoreManagerService.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Eager<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
        where T : class
    {
        return source.Include(path);
    }

    public static IQueryable<T> Eager<T>(this IQueryable<T> source, string path)
        where T : class
    {
        return source.Include(path);
    }

}
