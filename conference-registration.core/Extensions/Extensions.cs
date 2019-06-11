// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Extensions
{
    using System;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using conference_registration.core.Paging;

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
        ///         <cref>PagedResult</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize)
            where T : class
        {
            var result = new PagedResult<T> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };

            var pageCount = (double)result.RowCount / pageSize;
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
        ///         <cref>PagedResult</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static PagedResult<U> GetPaged<T, U>(this IQueryable<T> query, int page, int pageSize)
            where U : class
        {
            var result = new PagedResult<U> { CurrentPage = page, PageSize = pageSize, RowCount = query.Count() };

            var pageCount = (double)result.RowCount / pageSize;
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
