// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlInformationAttribute.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;

    /// <summary>
    /// <see cref="AggregationKind"/> is an Enumeration for specifying the kind of aggregation of a Property.
    /// </summary>
    public enum AggregationKind
    {
        /// <summary>
        /// Indicates that the Property has no aggregation.
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the Property has shared aggregation.
        /// </summary>
        Shared,

        /// <summary>
        /// Indicates that the Property is aggregated compositely, i.e., the composite object has responsibility for the existence and storage of the composed objects (parts).
        /// </summary>
        Composite
    }

    /// <summary>
    /// The property kind which is applied to the metadata of a property. This is directly related to its cardinality and stereotypes applied in the uml model.
    /// </summary>
    public enum PropertyKind
    {
        /// <summary>
        /// Assertion that the property is a single scalar value property.
        /// </summary>
        Scalar,

        /// <summary>
        /// Assertion that the property is an unordered collection property.
        /// </summary>
        List,

        /// <summary>
        /// Assertion that the property is an ordered collection property.
        /// </summary>
        OrderedList,

        /// <summary>
        /// Assertion that the property is a value array property.
        /// </summary>
        ValueArray
    }

    /// <summary>
    /// The purpose of the <see cref="UmlInformationAttribute"/> is to decorate properties of classes
    /// to be able to use reflection to compute what kind of Aggregation of the property is.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UmlInformationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UmlInformationAttribute"/> class.
        /// </summary>
        /// <param name="aggregation">The kind of aggregation</param>
        /// <param name="isDerived">A value indicating whether the property is derived</param>
        /// <param name="isOrdered">A value indicating whether the property is ordered</param>
        /// <param name="isNullable">A value indicating whether the property may be null</param>
        /// <param name="isPersistent">A value indicating whether the property is persistent in a data-store</param>
        public UmlInformationAttribute(AggregationKind aggregation, bool isDerived, bool isOrdered, bool isNullable = false, bool isPersistent = true)
        {
            this.IsDerived = isDerived;
            this.IsOrdered = isOrdered;
            this.Aggregation = aggregation;
            this.IsNullable = isNullable;
            this.IsPersistent = isPersistent;
        }

        /// <summary>
        /// Gets the <see cref="AggregationKind"/> of the decorated property
        /// </summary>
        public AggregationKind Aggregation { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the property is ordered
        /// </summary>
        public bool IsOrdered { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the property is derived
        /// </summary>
        public bool IsDerived { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the property is nullable
        /// </summary>
        public bool IsNullable { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the property is non-persistent
        /// </summary>
        public bool IsPersistent { get; private set; }
    }
}