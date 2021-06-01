using Library.Common.Collections;
using Library.Common.Requests.Filters.Abstractions;
using Library.Common.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Extensions
{
    public static class IQueryableExtensions
    {
        #region EXTENSION METHODS

        public static IQueryable<TObject> OrderBy<TObject>(this IQueryable<TObject> @this, IFilter filter)
        {
            var type = typeof(TObject);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var property = properties.FirstOrDefault(p => p.Name.ToLower().Equals(filter.OrderBy.ToLower())) ??
                throw new Exception("Invalid Ordering Query!");

            var parameter = Expression.Parameter(type, "p");

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            MethodCallExpression resultExp = CallMethod(@this, orderByExp, property, type, filter);

            return @this.Provider.CreateQuery<TObject>(resultExp);
        }

        public async static Task<PagedList<TObject>> ToPagedListAsync<TObject>(this IQueryable<TObject> @this,
            int pageNumber,
            string url,
            int pageSize = 15)
            where TObject : class
        => await PagedList<TObject>.CreatePagedListAsync(@this, url, pageNumber, pageSize);

        #endregion

        #region PRIVATE METHODS

        private static MethodCallExpression CallMethod<TObject>(IQueryable<TObject> @this, LambdaExpression expression,
            PropertyInfo property, Type type, IFilter filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            if (filter.Ordering.ToUpper().Equals(OrderingTypes.DESCENDING))
                return Expression.Call(typeof(Queryable), "OrderByDescending",
                new Type[] { type, property.PropertyType },
                @this.Expression,
                Expression.Quote(expression));
            else
                return Expression.Call(typeof(Queryable), "OrderBy",
                new Type[] { type, property.PropertyType },
                @this.Expression,
                Expression.Quote(expression));

        }

        #endregion
    }
}
