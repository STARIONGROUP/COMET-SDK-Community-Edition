// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeResolver.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    using CommonData;

    using CDP4Common.Polyfills;

    /// <summary>
    /// The purpose of the <see cref="TypeResolver"/> is to provide subType information on super and sub classes of any
    /// class in E-TM-10-25 
    /// </summary>
    public static class TypeResolver
    {
        /// <summary>
        /// Gets all the derived types of the specified <see cref="Type"/> in the specified Assembly
        /// </summary>
        /// <param name="baseType">
        /// The <see cref="Type"/> for which all subtypes need to be returned
        /// </param>
        /// <param name="assembly">
        /// The assembly in which <paramref name="baseType"/> resides
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Type}"/> of all the derived types of the <paramref name="baseType"/>
        /// </returns>
        public static IEnumerable<Type> GetDerivedTypes(Type baseType, Assembly assembly)
        {
            // Get all types from the given assembly
            var types = assembly.GetTypes();
            var derivedTypes = new List<Type>();

            for (int i = 0, count = types.Length; i < count; i++)
            {
                var type = types[i];

                if (IsSubclassOf(type, baseType))
                {
                    derivedTypes.Add(type);
                }
            }

            return derivedTypes;
        }

        /// <summary>
        /// Returns all the super-types of a <see cref="Thing"/>.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to have its <see cref="Type"/> analyzed</param>
        /// <returns>The <see cref="IEnumerable{T}"/> of <see cref="Type"/>s that are super-types of the provided <see cref="Thing"/>.</returns>
        public static IEnumerable<Type> GetAllSuperTypes(Thing thing)
        {
            var result = new List<Type>();

            var typeOfThing = thing.GetType();
            result.Add(typeOfThing);

            while (true)
            {
                if (typeOfThing == typeof(Thing) || typeOfThing == null)
                {
                    break;
                }

                typeOfThing = typeOfThing.QueryBaseType();
                result.Add(typeOfThing);
            }

            return result;
        }

        /// <summary>
        /// Assertion whether <paramref name="subType"/> is a sub type of <paramref name="superType"/>
        /// </summary>
        /// <param name="subType"> the <see cref="Type"/> that is being asserted.</param>
        /// <param name="superType"> The <see cref="Type"/> of which <paramref name="subType"/> may be a sub type</param>
        /// <returns>
        /// true if <paramref name="subType"/> is a subtype of <paramref name="superType"/>
        /// </returns>
        public static bool IsSubclassOf(Type subType, Type superType)
        {
            if (subType == null || superType == null || subType == superType)
            {
                return false;
            }
            
            if (!superType.QueryIsGenericType())
            {
                if (!subType.QueryIsGenericType())
                {
                    return subType.QueryIsSubclassOf(superType);
                }
            }
            else
            {
                superType = superType.GetGenericTypeDefinition();
            }

            subType = subType.QueryBaseType();
            var objectType = typeof(object);

            while (subType != objectType && subType != null)
            {
                var curentType = subType.QueryIsGenericType() ? subType.GetGenericTypeDefinition() : subType;

                if (curentType == superType)
                {
                    return true;
                }
                
                subType = subType.QueryBaseType();
            }

            return false;
        }

        /// <summary>
        /// Queries the super (base) types and interfaces of a give <see cref="Type"/>
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Type}"/> which may be empty
        /// </returns>
        public static IEnumerable<Type> QueryBaseClassesAndInterfaces(this Type type)
        {
            return type.QueryBaseType() == typeof(object)
                ? type.GetInterfaces()
                : Enumerable
                    .Repeat(type.QueryBaseType(), 1)
                    .Concat(type.GetInterfaces())
                    .Concat(type.QueryBaseType().QueryBaseClassesAndInterfaces())
                    .Distinct();
        }
    }
}