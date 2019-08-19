// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConferenceContext.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the ConferenceContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable UnusedMember.Local
// ReSharper disable ConsiderUsingConfigureAwait
// ReSharper disable UnusedVariable
namespace conference_registration.data
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using core.Entities.ConferenceAggregate;
    using core.Entities.RegistrationAggregate;

    using Mapping;

    using MediatR;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// The conference context.
    /// </summary>
    public class ConferenceContext : DbContext
    {
        /// <summary>
        /// The _mediator.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// The _current transaction.
        /// </summary>
        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// The get current transaction.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbContextTransaction"/>.
        /// </returns>
        public IDbContextTransaction GetCurrentTransaction() => this._currentTransaction;

        /// <summary>
        /// The has active transaction.
        /// </summary>
        public bool HasActiveTransaction => this._currentTransaction != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        private ConferenceContext(DbContextOptions<ConferenceContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConferenceContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="mediator"></param>
        public ConferenceContext(DbContextOptions<ConferenceContext> options, IMediator mediator) : base(options)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            // ReSharper disable once VirtualMemberCallInConstructor
            System.Diagnostics.Debug.WriteLine("ConferenceContext::ctor ->" + this.GetHashCode());
        }

        /// <summary>
        /// Gets or sets the attendees.
        /// </summary>
        public DbSet<Attendee> Attendees { get; set; }

        /// <summary>
        /// Gets or sets the conferences.
        /// </summary>
        public DbSet<Conference> Conferences { get; set; }

        /// <summary>
        /// Gets or sets the conference sessions.
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the registrations.
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// Gets or sets the attendee session registration.
        /// </summary>
        public DbSet<AttendeeSessionRegistration> AttendeeSessionRegistrations { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && (type.BaseType.GetGenericTypeDefinition() == typeof(ConferenceContextConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                dynamic configuration = Activator.CreateInstance(typeConfiguration);
                builder.ApplyConfiguration(configuration);
            }

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// The save entities async.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await this._mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await this.SaveChangesAsync(cancellationToken);

            return true;
        }

        /// <summary>
        /// The begin transaction async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (this._currentTransaction != null) return null;

            this._currentTransaction = await this.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return this._currentTransaction;
        }

        /// <summary>
        /// The commit transaction async.
        /// </summary>
        /// <param name="transaction">
        /// The transaction.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != this._currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await this.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                this.RollbackTransaction();
                throw;
            }
            finally
            {
                if (this._currentTransaction != null)
                {
                    this._currentTransaction.Dispose();
                    this._currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// The rollback transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                this._currentTransaction?.Rollback();
            }
            finally
            {
                if (this._currentTransaction != null)
                {
                    this._currentTransaction.Dispose();
                    this._currentTransaction = null;
                }
            }
        }
    }
}
