using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zemoga.BlogEngine.Services
{
    /// <summary>
    /// Extension class with methods to extend IQueryable
    /// </summary>
    public static class IQueryableExtensions
    {
        #region OrderBy extensions

        /// <summary>
        /// Sorts (ascendinglyy) a IQueryable instance by property name
        /// </summary>
        /// <typeparam name="T">Type of items in the IQueryable instance</typeparam>
        /// <param name="source">IQueryable instance</param>
        /// <param name="property">Property name to sort the collection</param>
        /// <returns>IQueryable with Order by clause</returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        /// <summary>
        /// Sorts (descendingly) a IQueryable instance by property name
        /// </summary>
        /// <typeparam name="T">Type of items in the IQueryable instance</typeparam>
        /// <param name="source">IQueryable instance</param>
        /// <param name="property">Property name to sort the collection</param>
        /// <returns>IQueryable with Order by clause</returns>
        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        /// <summary>
        /// Applies a ThenBy sorting (ascendingly) to an instance of IQueryable
        /// </summary>
        /// <typeparam name="T">Type of items in the IQueryable instance</typeparam>
        /// <param name="source">IQueryable instance</param>
        /// <param name="property">Property name to sort the collection</param>
        /// <returns>IQueryable with Then by clause</returns>
        public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }

        /// <summary>
        /// Applies a ThenBy sorting (descendingly) to an instance of IQueryable
        /// </summary>
        /// <typeparam name="T">Type of items in the IQueryable instance</typeparam>
        /// <param name="source">IQueryable instance</param>
        /// <param name="property">Property name to sort the collection</param>
        /// <returns>IQueryable with Order by clause</returns>
        public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        /// <summary>
        /// Apply sorting specifications to an IQueryable instance
        /// </summary>
        /// <typeparam name="T">Type of items in the IQueryable instance</typeparam>
        /// <param name="source">IQueryable instance</param>
        /// <param name="property">Property name to sort the collection</param>
        /// <param name="methodName">One of the sorting method names (OrderBy, OrderByDescending, ThenBy, ThenByDescending)</param>
        /// <returns></returns>
        static IQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)result;
        }
        #endregion
    }
}
