using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cric_api.DTOs.Utilities
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByColumn<T>(
        this IQueryable<T> source,
        string columnName,
        bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Column name cannot be null or empty.", nameof(columnName));

            // Validate the property exists on the type
            var property = typeof(T).GetProperty(columnName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
                throw new ArgumentException($"No property '{columnName}' found on type '{typeof(T).Name}'.");

            // Build the expression: x => x.ColumnName
            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // Determine method name: OrderBy / OrderByDescending
            string methodName = ascending ? "OrderBy" : "OrderByDescending";

            // Create the method call expression
            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExpression);
        }



    }
}
