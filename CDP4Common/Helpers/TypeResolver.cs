// -----------------------------------------------------------------------------------------------
// <copyright file="TypeResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -----------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
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
        /// The assembly in which <see cref="baseType"/>
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Type}"/> of all the derived types of the <see cref="baseType"/>
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
        /// Assertion whether <see cref="subType"/> is a sub type of <see cref="superType"/>
        /// </summary>
        /// <param name="subType"> the <see cref="Type"/> that is being asserted.</param>
        /// <param name="superType"> The <see cref="Type"/> of which <see cref="subType"/> may be a sub type</param>
        /// <returns>
        /// true if <see cref="subType"/> is a subtype of <see cref="superType"/>
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
    }
}
