// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TypePolyfills.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexandervan Delft, Nathanael Smiechowski, Ahmed Abulwafa Ahmed
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Polyfills
{
    using System;
    using System.Reflection;

#if NETFRAMEWORK

    /// <summary>
    /// The purpose of the <see cref="TypePolyfills"/> class is to provide extension methods on the <see cref="Type"/>
    /// class that can be used from the full dotnet framework and dotnetstandard. All the methods start with the word
    /// Query to distinquish them from the methods that are available in the dotnet framework and netstandard
    /// </summary>
    public static class TypePolyfills
    {
        /// <summary>
        /// Gets the System.Reflection.Assembly in which the type is declared. For generic
        ///  types, gets the System.Reflection.Assembly in which the generic type is defined.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// An System.Reflection.Assembly instance that describes the assembly containing
        /// the current type. For generic types, the instance describes the assembly that
        /// contains the generic type definition, not the assembly that creates and uses
        /// a particular constructed type.
        /// </returns>
        public static Assembly QueryAssembly(this Type type)
        {
            return type.Assembly;
        }

        /// <summary>
        /// Gets a value indicating whether the System.Type is a value type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is a value type; otherwise, false.
        /// </returns>
        public static bool QueryIsValueType(this Type type)
        {
            return type.IsValueType;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is abstract and must be overridden.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is abstract; otherwise, false.
        /// </returns>
        public static bool QueryIsAbstract(this Type type)
        {
            return type.IsAbstract;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is one of the primitive types.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the System.Type is one of the primitive types; otherwise, false.
        /// </returns>
        public static bool QueryIsPrimitive(this Type type)
        {
            return type.IsPrimitive;
        }

        /// <summary>
        /// Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type is a generic type; otherwise, false.
        /// </returns>
        public static bool QueryIsGenericType(this Type type)
        {
            return type.IsGenericType;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Type"/> has been decorated with the provided <see cref="Attribute"/>
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type has been decorated with the specified <see cref="Attribute"/>; otherwise, false.
        /// </returns>
        public static bool QueryIsAttributeDefined<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the <see cref="Attribute"/> of the specified type
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// an instance of the specified <see cref="Attribute"/>; otherwise, null.
        /// </returns>
        public static Attribute QueryGetCustomAttribute<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return attribute;
                }
            }

            return null;
        }

        /// <summary>
        /// Determines whether an instance of a specified type can be assigned to the current type instance.
        /// </summary>
        /// <param name="type">
        /// The current <see cref="Type"/>
        /// </param>
        /// <param name="c">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if any of the following conditions is true: c and the current instance represent
        /// the same type. c is derived either directly or indirectly from the current instance.
        /// The current instance is an interface that c implements. c is a generic type parameter,
        /// and the current instance represents one of the constraints of c. c represents
        /// a value type, and the current instance represents Nullable.
        /// false if none of these conditions are true, or if c is null.
        /// </returns>
        public static bool QueryIsAssignableFrom(this Type type, Type c)
        {
            return type.IsAssignableFrom(c);
        }

        /// <summary>
        /// Queries the type from which the <paramref name="type"/> directly inherits.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// The <see cref="Type" /> from which the <paramref name="type"/> directly inherits,
        /// or null <paramref name="type"/> represents the <see cref="System.Object" /> class or an interface.
        /// </returns>
        public static Type QueryBaseType(this Type type)
        {
            return type.BaseType;
        }

        /// <summary>
        /// Determines whether the <paramref name="type"/> derives from the specified <see cref="System.Type" />.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <param name="c">
        /// The type to compare with the current type.
        /// </param>
        /// <returns>
        /// true if the current the <paramref name="type"/> derives from <paramref name="c" />; otherwise, false.
        /// This method also returns false if <paramref name="c" /> and <paramref name="type"/> are equal.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="c" /> is null.
        /// </exception>
        public static bool QueryIsSubclassOf(this Type type, Type c)
        {
            return type.IsSubclassOf(c);
        }

        /// <summary>
        /// Searches for the public field with the specified name.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <param name="name">
        /// The string containing the name of the data field to get.
        /// </param>
        /// <returns>
        /// An object representing the public field with the specified name, if found; otherwise, null.
        /// </returns>
        public static FieldInfo QueryField(this Type type, string name)
        {
            return type.GetField(name);
        }
    }
#else

    /// <summary>
    /// The purpose of the <see cref="TypePolyfills"/> class is to provide extension methods on the <see cref="Type"/>
    /// class that can be used from the full dotnet framework and dotnetstandard. All the methods start with the word
    /// Query to distinquish them from the methods that are available in the dotnet framework and netstandard
    /// </summary>
    public static class TypePolyfills
    {
        /// <summary>
        /// Gets the System.Reflection.Assembly in which the type is declared. For generic
        ///  types, gets the System.Reflection.Assembly in which the generic type is defined.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// An System.Reflection.Assembly instance that describes the assembly containing
        /// the current type. For generic types, the instance describes the assembly that
        /// contains the generic type definition, not the assembly that creates and uses
        /// a particular constructed type.
        /// </returns>
        public static Assembly QueryAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        /// <summary>
        /// Gets a value indicating whether the System.Type is a value type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is a value type; otherwise, false.
        /// </returns>
        public static bool QueryIsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is abstract and must be overridden.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is abstract; otherwise, false.
        /// </returns>
        public static bool QueryIsAbstract(this Type type)
        {
            return type.GetTypeInfo().IsAbstract;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is one of the primitive types.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the System.Type is one of the primitive types; otherwise, false.
        /// </returns>
        public static bool QueryIsPrimitive(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive;
        }

        /// <summary>
        /// Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type is a generic type; otherwise, false.
        /// </returns>
        public static bool QueryIsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Type"/> has been decorated with the provided <see cref="Attribute"/>
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type has been decorated with the specified <see cref="Attribute"/>; otherwise, false.
        /// </returns>
        public static bool QueryIsAttributeDefined<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the <see cref="Attribute"/> of the specified type
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// an instance of the specified <see cref="Attribute"/>; otherwise, null.
        /// </returns>
        public static Attribute QueryGetCustomAttribute<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return attribute;
                }
            }

            return null;
        }

        /// <summary>
        ///  Determines whether an instance of a specified type can be assigned to the current type instance.
        /// </summary>
        /// <param name="type">
        /// The current <see cref="Type"/>
        /// </param>
        /// <param name="c">
        /// The specified <see cref="Type"/> 
        /// </param>
        /// <returns>
        /// true if any of the following conditions is true: c and the current instance represent
        /// the same type. c is derived either directly or indirectly from the current instance.
        /// The current instance is an interface that c implements. c is a generic type parameter,
        /// and the current instance represents one of the constraints of c. c represents
        /// a value type, and the current instance represents Nullable.
        /// false if none of these conditions are true, or if c is null.
        /// </returns>
        public static bool QueryIsAssignableFrom(this Type type, Type c)
        {
            return type.GetTypeInfo().IsAssignableFrom(c);
        }

        /// <summary>
        /// Queries the type from which the <paramref name="type"/> directly inherits.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// The <see cref="Type" /> from which the <paramref name="type"/> directly inherits,
        /// or null <paramref name="type"/> represents the <see cref="System.Object" /> class or an interface.
        /// </returns>
        public static Type QueryBaseType(this Type type)
        {
            return type.GetTypeInfo().BaseType;
        }

        /// <summary>
        /// Determines whether the <paramref name="type"/> derives from the specified <see cref="System.Type" />.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <param name="c">
        /// The type to compare with the current type.
        /// </param>
        /// <returns>
        /// true if the current the <paramref name="type"/> derives from <paramref name="c" />; otherwise, false.
        /// This method also returns false if <paramref name="c" /> and <paramref name="type"/> are equal.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="c" /> is null.
        /// </exception>
        public static bool QueryIsSubclassOf(this Type type, Type c)
        {
            return type.GetTypeInfo().IsSubclassOf(c);
        }

        /// <summary>
        /// Searches for the public field with the specified name.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <param name="name">
        /// The string containing the name of the data field to get.
        /// </param>
        /// <returns>
        /// An object representing the public field with the specified name, if found; otherwise, null.
        /// </returns>
        public static FieldInfo QueryField(this Type type, string name)
        {
            return type.GetTypeInfo().GetField(name);
        }
    }

#endif
}