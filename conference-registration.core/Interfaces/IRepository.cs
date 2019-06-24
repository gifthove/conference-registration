// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using conference_registration.core.Entities;
    using conference_registration.core.Paging;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity 
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<TEntity> List();

        /// <summary>
        /// The find by.
        /// </summary>
        /// <param name="filterQuery">
        /// The filter query.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filterQuery);

        /// <summary>
        /// The get paged result for query.
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <param name="page">
        ///     The page.
        /// </param>
        /// <param name="pageSize">
        ///     The page size.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>PagedList</cref>
        ///     </see>
        ///     .
        /// </returns>
        PagedList<TEntity> GetPagedResultForQuery(Expression<Func<TEntity, bool>> filterQuery, int page, int pageSize);

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity GetById(int id);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Insert(TEntity entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
