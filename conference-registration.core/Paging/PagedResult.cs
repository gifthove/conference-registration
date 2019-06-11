// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedResult.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the PagedResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Paging
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The paged result.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PagedResult<T> : PagedResultBase where T : class
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public IList<T> Results { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
        /// </summary>
        public PagedResult()
        {
            this.Results = new List<T>();
        }
    }
}
