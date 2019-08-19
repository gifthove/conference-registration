// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MediatorExtension.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the MediatorExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace conference_registration.data
{
    using System.Linq;
    using System.Threading.Tasks;

    using conference_registration.core.Entities;

    using MediatR;

    /// <summary>
    /// The mediator extension.
    /// </summary>
    public static class MediatorExtension
    {
        /// <summary>
        /// The dispatch domain events async.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="ctx">
        /// The ctx.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, ConferenceContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
