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

    using conference_registration.core.Entities.RegistrationAggregate;
    using conference_registration.core.Extensions;
    using conference_registration.core.Interfaces;
    using conference_registration.core.Paging;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The registration repository.
    /// </summary>
    public class RegistrationRepository : IRepository<Registration>
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly ConferenceContext _context;

        /// <summary>
        /// The _db set.
        /// </summary>
        private readonly DbSet<Registration> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationRepository"/> class. 
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        public RegistrationRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationRepository"/> class. 
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public RegistrationRepository(ConferenceContext context)
        {
            this._context = context;
            this._dbSet = context.Set<Registration>();
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
        public IEnumerable<Registration> List()
        {
            return this._dbSet.Include(a => a.Attendee)
                .Include(c => c.AttendingSessions).ThenInclude(S => S.Session)
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
        public IEnumerable<Registration> FindBy(Expression<Func<Registration, bool>> filterQuery)
        {
            var registrations = this._dbSet.Where(filterQuery).ToList();
            return registrations;
        }

        /// <inheritdoc />
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
        ///         <cref>PagedList</cref>
        ///     </see>
        ///     .
        /// </returns>
        public PagedList<Registration> GetPagedResultForQuery(
            Expression<Func<Registration, bool>> filterQuery,
            int page,
            int pageSize)
        {
            var result = this._dbSet.Include(a => a.Attendee)
                .Include(c => c.AttendingSessions)
                .ThenInclude(S => S.Session)
                .Where(filterQuery)
                .ToPagedList(page, pageSize);

            return result;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Registration"/>.
        /// </returns>
        public Registration GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Registration entity)
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
        public void Update(Registration entity)
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
