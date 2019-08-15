// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedList.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the PagedList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace conference_registration.core.Paging
{
    /// <inheritdoc />
    /// <summary>
    /// The paged result.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PagedList<T> : PagedResultBase where T : class
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IList<T> Results { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        public PagedList()
        {
            this.Results = new List<T>();
        }
    }
}
