// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IgnoreMemberAttribute.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The ignore member attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.common.SharedKernel
{
    using System;

    // source: https://github.com/jhewlett/ValueObject

    /// <summary>
    /// The ignore member attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IgnoreMemberAttribute : Attribute
    {
    }
}
