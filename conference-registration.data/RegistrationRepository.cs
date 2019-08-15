// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationRepository.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The registration repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using conference_registration.core.Paging;

namespace conference_registration.data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using core.Entities.RegistrationAggregate;
    using core.Extensions;
    using core.Interfaces;
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
            _context = context;
            _dbSet = context.Set<Registration>();
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
            return _dbSet.Include(a => a.Attendee)
                .Include(c => c.AttendingSessions)
                .ThenInclude(S => S.Session)
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
            var registrations = _dbSet.Where(filterQuery).ToList();
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
            var result = _dbSet.Include(a => a.Attendee)
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
            return _dbSet.Find(id);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Registration entity)
        {
            _dbSet.Add(entity);
            //_context.SaveChanges();
            var result =_context.SaveEntitiesAsync(new CancellationToken()).Result;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Registration entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
