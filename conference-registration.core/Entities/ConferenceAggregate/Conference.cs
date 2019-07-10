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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The _items.
        /// </summary>
        private readonly List<Session> _sessions = new List<Session>();

        /// <summary>
        /// The sessions.
        /// </summary>
        public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

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
            _sessions.Add(new Session()
                {
                    Topic = topic,
                    StartTime = startTime,
                    EndTime = endTime
            });
        }
    }
}
