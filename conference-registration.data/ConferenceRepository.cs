// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationRepository.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The registration repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using conference_registration.core.Entities.ConferenceAggregate;
    using conference_registration.core.Interfaces;
    using conference_registration.core.Paging;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The conference repository.
    /// </summary>
    public class ConferenceRepository : IRepository<Conference>
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly ConferenceContext _context;

        /// <summary>
        /// The _db set.
        /// </summary>
        private readonly DbSet<Conference> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceRepository"/> class.
        /// </summary>
        public ConferenceRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public ConferenceRepository(ConferenceContext context)
        {
            this._context = context;
            this._dbSet = context.Set<Conference>();
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
        public IEnumerable<Conference> List()
        {
            return this._dbSet.Include(a => a.Sessions)
                .ToList();
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
        public IEnumerable<Conference> FindBy(Expression<Func<Conference, bool>> filterQuery)
        {
            var conferences = this._dbSet.Where(filterQuery).ToList();
            return conferences;
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
        /// The <see cref="PagedResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public PagedResult<Conference> GetPagedResultForQuery(Expression<Func<Conference, bool>> filterQuery, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Conference"/>.
        /// </returns>
        public Conference GetById(int id)
        {
            return this._dbSet.Where(x => x.Id == id)
                .Include(s => s.Sessions)
                .Single();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Conference entity)
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
        public void Update(Conference entity)
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
