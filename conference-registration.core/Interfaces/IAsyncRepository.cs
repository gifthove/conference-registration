// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAsyncRepository.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the IAsyncRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using conference_registration.core.Entities;

    /// <summary>
    /// The AsyncRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IAsyncRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// The list all async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// The insert async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task DeleteAsync(T entity);
    }
}
