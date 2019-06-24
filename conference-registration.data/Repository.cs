// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the Repository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using conference_registration.core.Entities;
    using conference_registration.core.Interfaces;
    using conference_registration.core.Paging;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly ConferenceContext _context;

        /// <summary>
        /// The _db set.
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        public Repository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public Repository(ConferenceContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        public IEnumerable<TEntity> List()
        {
            return this._dbSet.ToList();
        }

        /// <inheritdoc />
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
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filterQuery)
        {
            var entities = this._dbSet.Where(filterQuery).ToList();
            return entities;
        }

        /// <summary>
        /// The get paged result for query.
        /// </summary>
        /// <param name="filterQuery">
        /// The filter query.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>PagedResult</cref>
        ///     </see>
        ///     .
        /// </returns>
        public PagedResult<TEntity> GetPagedResultForQuery(Expression<Func<TEntity, bool>> filterQuery, int page, int pageSize)
        {
            var query = this._dbSet.Where(filterQuery);
            var result = new PagedResult<TEntity> { CurrentPage = page, PageSize = pageSize, TotalCount = query.Count() };
            var pageCount = (double)result.TotalCount / pageSize;
            result.PagesCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public TEntity GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(TEntity entity)
        {
            this._dbSet.Add(entity);
            this._context.SaveChanges();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(TEntity entity)
        {
            this._dbSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var entityToDelete = this._dbSet.Find(id);
            this._dbSet.Remove(entityToDelete);
            this._context.SaveChanges();
        }
    }
}
