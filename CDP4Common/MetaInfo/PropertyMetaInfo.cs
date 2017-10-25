// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyMetaInfo.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    /// <summary>
    /// A class that contains the metadata of the property of a class
    /// </summary>
    public class PropertyMetaInfo : UmlInformationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyMetaInfo"/> class
        /// </summary>
        /// <param name="name">The name of the property which meta-data are copied in this<see cref="PropertyMetaInfo"/></param>
        /// <param name="typeName">The name of the property type</param>
        /// <param name="propertyKind">The <see cref="PropertyKind"/></param>
        /// <param name="aggregation">The <see cref="AggregationKind"/></param>
        /// <param name="isDerived">A value indicating whether the property is derived</param>
        /// <param name="isOrdered">A value indicating whether the property is ordered</param>
        /// <param name="isPersistent">A value indicating whether the property is persisted</param>
        /// <param name="lowerCardinality">The lower cardinality of the property</param>
        /// <param name="upperCardinality">The upper cardinality</param>
        /// <param name="isDataMember">A value indicating whether the property shall be serialized or deserialized</param>
        public PropertyMetaInfo(string name, string typeName, PropertyKind propertyKind, AggregationKind aggregation, bool isDerived, bool isOrdered, bool isPersistent, int? lowerCardinality, string upperCardinality, bool isDataMember)
            : base(aggregation, isDerived, isOrdered, lowerCardinality == 0 && upperCardinality == "1", isPersistent)
        {
            this.Name = name;
            this.TypeName = typeName;
            this.PropertyKind = propertyKind;
            this.LowerCardinality = lowerCardinality;
            this.UpperCardinality = upperCardinality;
            this.IsDataMember = isDataMember;
        }

        /// <summary>
        /// Gets the name of the property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the property type
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets the lower cardinality value
        /// </summary>
        public int? LowerCardinality { get; private set; }

        /// <summary>
        /// Gets the upper cardinality value
        /// </summary>
        public string UpperCardinality { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the property has the Data-Member attribute on
        /// </summary>
        public bool IsDataMember { get; private set; }

        /// <summary>
        /// Gets the <see cref="PropertyKind"/>
        /// </summary>
        public PropertyKind PropertyKind { get; private set; }
    }
}