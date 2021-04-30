using Library.Common.Types;
using Library.Data.Request.Filters.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Library.Data.Extensions
{
    internal static class IQueryableExtensions
    {
        #region EXTENSION METHODS

        internal static IQueryable<TObject> OrderBy<TObject>(this IQueryable<TObject> @this, IFilter filter)
        {
            var type = typeof(TObject);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var property = properties.FirstOrDefault(p => p.Name.ToLower().Equals(filter.OrderBy)) ??
                throw new Exception("Invalid Ordering Query!");

            var parameter = Expression.Parameter(type, "p");

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            MethodCallExpression resultExp = CallMethod(@this, orderByExp, property, type, filter);

            return @this.Provider.CreateQuery<TObject>(resultExp);
        }

        #endregion

        #region PRIVATE METHODS

        private static MethodCallExpression CallMethod<TObject>(IQueryable<TObject> @this, LambdaExpression expression,
            PropertyInfo property, Type type, IFilter filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            return filter.Ordering.ToLower().Equals(OrderingTypes.DESCENDING) ?
                Expression.Call(typeof(Queryable), "OrderByDescending",
                new Type[] { type, property.PropertyType },
                @this.Expression,
                Expression.Quote(expression))
                :
                Expression.Call(typeof(Queryable), "OrderBy",
                new Type[] { type, property.PropertyType },
                @this.Expression,
                Expression.Quote(expression));
        }

        #endregion
    }
}
