// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedResultBase.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   Defines the PagedResultBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.core.Paging
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The paged result base.
    /// </summary>
    public abstract class PagedResultBase
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        public int PagesCount { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
