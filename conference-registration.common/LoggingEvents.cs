// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingEvents.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the LoggingEvents type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.common
{
    /// <summary>
    /// The logging events.
    /// </summary>
    public class LoggingEvents
    {
        /// <summary>
        /// The generate items.
        /// </summary>
        public const int GenerateItems = 1000;

        /// <summary>
        /// The list items.
        /// </summary>
        public const int ListItems = 1001;

        /// <summary>
        /// The get item.
        /// </summary>
        public const int GetItem = 1002;

        /// <summary>
        /// The insert item.
        /// </summary>
        public const int InsertItem = 1003;

        /// <summary>
        /// The update item.
        /// </summary>
        public const int UpdateItem = 1004;

        /// <summary>
        /// The delete item.
        /// </summary>
        public const int DeleteItem = 1005;

        /// <summary>
        /// The get item not found.
        /// </summary>
        public const int GetItemNotFound = 4000;

        /// <summary>
        /// The update item not found.
        /// </summary>
        public const int UpdateItemNotFound = 4001;
    }
}
