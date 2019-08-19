// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueObject.cs" company="Gift Ltd">
//   © Copyright 2019 - All rights reserved
// </copyright>
// <summary>
//   The value object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace conference_registration.common.SharedKernel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    // source: https://github.com/jhewlett/ValueObject

    /// <summary>
    /// The value object.
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        /// <summary>
        /// The properties.
        /// </summary>
        private List<PropertyInfo> properties;

        /// <summary>
        /// The fields.
        /// </summary>
        private List<FieldInfo> fields;

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="obj1">
        /// The obj 1.
        /// </param>
        /// <param name="obj2">
        /// The obj 2.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator ==(ValueObject obj1, ValueObject obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="obj1">
        /// The obj 1.
        /// </param>
        /// <param name="obj2">
        /// The obj 2.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool operator !=(ValueObject obj1, ValueObject obj2)
        {
            return !(obj1 == obj2);
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
        public bool Equals(ValueObject obj)
        {
            return this.Equals(obj as object);
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
            if (obj == null || this.GetType() != obj.GetType()) return false;

            return this.GetProperties().All(p => this.PropertiesAreEqual(obj, p))
                && this.GetFields().All(f => this.FieldsAreEqual(obj, f));
        }

        /// <summary>
        /// The properties are equal.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool PropertiesAreEqual(object obj, PropertyInfo p)
        {
            return Equals(p.GetValue(this, null), p.GetValue(obj, null));
        }

        /// <summary>
        /// The fields are equal.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="f">
        /// The f.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool FieldsAreEqual(object obj, FieldInfo f)
        {
            return Equals(f.GetValue(this), f.GetValue(obj));
        }

        /// <summary>
        /// The get properties.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (this.properties == null)
            {
                this.properties = this.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                    .ToList();

                // Not available in Core
                // !Attribute.IsDefined(p, typeof(IgnoreMemberAttribute))).ToList();
            }

            return this.properties;
        }

        /// <summary>
        /// The get fields.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>IEnumerable</cref>
        ///     </see>
        ///     .
        /// </returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            if (this.fields == null)
            {
                this.fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                    .ToList();
            }

            return this.fields;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            // allow overflow
            unchecked
            {
                int hash = 17;
                foreach (var prop in this.GetProperties())
                {
                    var value = prop.GetValue(this, null);
                    hash = this.HashValue(hash, value);
                }

                foreach (var field in this.GetFields())
                {
                    var value = field.GetValue(this);
                    hash = this.HashValue(hash, value);
                }

                return hash;
            }
        }

        /// <summary>
        /// The hash value.
        /// </summary>
        /// <param name="seed">
        /// The seed.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int HashValue(int seed, object value)
        {
            var currentHash = value != null
                ? value.GetHashCode()
                : 0;

            return seed * 23 + currentHash;
        }
    }
}
