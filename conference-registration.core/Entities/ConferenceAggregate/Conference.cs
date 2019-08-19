// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conference.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the Conference type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Entities.ConferenceAggregate
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// The conference.
    /// </summary>
    public class Conference : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The _items.
        /// </summary>
        private readonly List<Session> _sessions = new List<Session>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Conference"/> class.
        /// </summary>
        public Conference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conference"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public Conference(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// The sessions.
        /// </summary>
        public IReadOnlyCollection<Session> Sessions => this._sessions.AsReadOnly();

        /// <summary>
        /// The add session.
        /// </summary>
        /// <param name="topic">
        /// The topic.
        /// </param>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        /// <param name="endTime">
        /// The end time.
        /// </param>
        public void AddSession(string topic, DateTime startTime, DateTime endTime)
        {
            this._sessions.Add(new Session()
            {
                Topic = topic,
                StartTime = startTime,
                EndTime = endTime
            });
        }
    }
}
