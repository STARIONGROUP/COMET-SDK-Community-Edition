// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingFormatterResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2023 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4MessagePackSerializer
{
    using global::MessagePack;
    using global::MessagePack.Formatters;
    
    /// <summary>
    /// The purpose of the <see cref="ThingFormatterResolver"/> is to provide the model
    /// <see cref="IMessagePackFormatter"/> for all concrete classes
    /// </summary>
    public class ThingFormatterResolver : IFormatterResolver
    {
        // Resolver should be singleton.
        public static readonly IFormatterResolver Instance = new ThingFormatterResolver();

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingFormatterResolver"/> class
        /// </summary>
        private ThingFormatterResolver()
        {
        }

        /// <summary>
        /// Gets an <see cref="T:MessagePack.Formatters.IMessagePackFormatter`1" /> instance that can serialize or deserialize some type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of value to be serialized or deserialized.</typeparam>
        /// <returns>A formatter, if this resolver supplies one for type <typeparamref name="T" />; otherwise <see langword="null" />.</returns>
        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        /// <summary>
        /// A cache from which <see cref="IMessagePackFormatter"/> can be resolved
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static class FormatterCache<T>
        {
            public static readonly IMessagePackFormatter<T> Formatter;

            // generic's static constructor should be minimized for reduce type generation size!
            // use outer helper method.
            static FormatterCache()
            {
                var type = typeof(T);

                Formatter = (IMessagePackFormatter<T>)ThingResolverGetFormatterHelper.GetFormatter(type);
            }
        }
    }
}
