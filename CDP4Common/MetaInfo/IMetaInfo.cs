// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetaInfo.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.MetaInfo
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;
    using CDP4Common.Exceptions;
    using CDP4Common.Types;
    
    /// <summary>
    /// The MetaInfo interface.
    /// </summary>
    public interface IMetaInfo
    {
        /// <summary>
        /// Gets the base type name of this class.
        /// </summary>
        string BaseType { get; }

        /// <summary>
        /// Gets the CDP class version.
        /// </summary>
        string ClassVersion { get; }

        /// <summary>
        /// Get the data model version of the supplied property.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// The version number as specified property otherwise the default data model version.
        /// </returns>
        string GetPropertyVersion(string propertyName);

        /// <summary>
        /// Returns the <see cref="Thing"/> containment property info from the supplied property name.
        /// </summary>
        /// <param name="propertyName">
        /// The containment property name.
        /// </param>
        /// <returns>
        /// The type info of the containment property.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="Thing"/>.
        /// </exception>
        PropertyMetaInfo GetContainmentType(string propertyName);

        /// <summary>
        /// Check if the supplied property name is scalar.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// True if the supplied property name is a scalar property.
        /// </returns>
        bool IsScalar(string propertyName);

        /// <summary>
        /// Gets a value indicating whether this type should be deprecated upon Delete.
        /// </summary>
        bool IsDeprecatableThing { get; }

        /// <summary>
        /// Gets a value indicating whether this type is a top container.
        /// </summary>
        bool IsTopContainer { get; }

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/>s for the represented <see cref="Thing"/>
        /// </summary>
        IEnumerable<PropertyMetaInfo> Properties { get; }

        /// <summary>
        /// Returns the <see cref="PropertyMetaInfo"/> for the property of a <see cref="Thing"/>
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The type info of the property.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        PropertyMetaInfo GetPropertyMetaInfo(string propertyName);

        /// <summary>
        /// Returns the container property for the supplied type name is a possible container for <see cref="Thing"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="Thing"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="Thing"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="Thing"/> and sets the container property name.
        /// </returns>
        bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty);

        /// <summary>
        /// Returns a deserialized object from the supplied value string for the property name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="value">
        /// The value to deserialize from its current string form.
        /// </param>
        /// <returns>
        /// A deserialized object from the supplied value.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        object DeserializeCollectionValue(string propertyName, object value);

        /// <summary>
        /// Apply the value update to the supplied property name of the updatable <see cref="Thing"/> instance.
        /// </summary>
        /// <param name="updatableThing">
        /// The <see cref="Thing"/> instance to which to apply the property value update.
        /// </param>
        /// <param name="propertyName">
        /// The property name of the <see cref="Thing"/> to which to apply the value update.
        /// </param>
        /// <param name="value">
        /// The updated value to apply.
        /// </param>
        /// <returns>
        /// True if the value update was successfully applied.
        /// </returns>
        bool ApplyPropertyUpdate(Thing updatableThing, string propertyName, object value);

        /// <summary>
        /// Returns the value of the property of a Thing
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="thing">
        /// The Thing object
        /// </param>
        /// <returns>
        /// The value of the property of a Thing
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        object GetValue(string propertyName, Thing thing);

        /// <summary>
        /// Gets the collection of property names for a <see cref="Thing"/>
        /// </summary>
        IEnumerable<string> GetPropertyNameCollection();

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        void Validate(Thing thing);

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        void Validate(Thing thing, Func<string, bool> validateProperty);

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        bool TryValidate(Thing thing);

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        bool TryValidate(Thing thing, Func<string, bool> validateProperty);

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="Thing"/>.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="Thing"/>.
        /// </exception>
        IEnumerable<Guid> GetContainmentIds(Thing thing, string propertyName);

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="Thing"/>.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="Thing"/>.
        /// </exception>
        IEnumerable<OrderedItem> GetOrderedContainmentIds(Thing thing, string propertyName);

        /// <summary>
        /// Instantiates a <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="Thing"/>
        /// </returns>
        DTO.Thing InstantiateDto(Guid guid, int revisionNumber);
    }
}