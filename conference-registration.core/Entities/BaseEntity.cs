// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the BaseEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All
namespace conference_registration.core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using MediatR;

    /// <summary>
    /// The base entity.
    /// </summary>
    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
    public abstract class BaseEntity
    {
        /// <summary>
        /// The _requested hash code.
        /// </summary>
        private int? _requestedHashCode;

        /// <summary>
        /// The _ id.
        /// </summary>
        private int _Id;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public virtual int Id
        {
            get => this._Id;
            protected set => this._Id = value;
        }

        /// <summary>
        /// The _domain events.
        /// </summary>
        private List<INotification> _domainEvents;

        /// <summary>
        /// The domain events.
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => this._domainEvents?.AsReadOnly();

        /// <summary>
        /// The add domain event.
        /// </summary>
        /// <param name="eventItem">
        /// The event item.
        /// </param>
        public void AddDomainEvent(INotification eventItem)
        {
            this._domainEvents = this._domainEvents ?? new List<INotification>();
            this._domainEvents.Add(eventItem);
        }

        /// <summary>
        /// The remove domain event.
        /// </summary>
        /// <param name="eventItem">
        /// The event item.
        /// </param>
        public void RemoveDomainEvent(INotification eventItem)
        {
            this._domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// The clear domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            this._domainEvents?.Clear();
        }

        /// <summary>
        /// The is transient.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsTransient()
        {
            return this.Id == default(int);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            BaseEntity item = (BaseEntity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this._requestedHashCode.HasValue) this._requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return this._requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            else
                return left.Equals(right);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }
    }
}
