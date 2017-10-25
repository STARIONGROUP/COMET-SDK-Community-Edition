// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UmlInformationAttribute.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
