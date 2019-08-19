// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferenceContextConfiguration.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the ConferenceContextConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.data.Mapping
{
    using conference_registration.core.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// The conference context configuration.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public abstract class ConferenceContextConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        #region Utilities

        /// <summary>
        /// Developers can override this method in custom partial classes in order to add some custom configuration code
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        #endregion
    }
}
