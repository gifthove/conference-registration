// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using conference_registration.core.Paging;

namespace conference_registration.core.Extensions
{
    using System;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    /// <summary>
    /// The extension.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The get paged.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>PagedList</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, int page, int pageSize)
            where T : class
        {
            var result = new PagedList<T> { CurrentPage = page, PageSize = pageSize, TotalCount = query.Count() };

            var pageCount = (double)result.TotalCount / pageSize;
            result.PagesCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        /// <summary>
        /// The get paged.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <typeparam name="U">
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>PagedList</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static PagedList<U> ToPagedList<T, U>(this IQueryable<T> query, int page, int pageSize)
            where U : class
        {
            var result = new PagedList<U> { CurrentPage = page, PageSize = pageSize, TotalCount = query.Count() };

            var pageCount = (double)result.TotalCount / pageSize;
            result.PagesCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip)
                .Take(pageSize)
                .ProjectTo<U>()
                .ToList();

            return result;
        }
    }

}
