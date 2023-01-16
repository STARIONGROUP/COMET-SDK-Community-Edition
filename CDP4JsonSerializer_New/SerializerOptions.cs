// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerOptions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
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

namespace CDP4JsonSerializer_SystemTextJson
{
    using System.Text.Json;

    /// <summary>
    /// Static class with the options used in the serializer
    /// </summary>
    public class SerializerOptions
    {
        /// <summary>
        /// Creates a new instance of type <see cref="SerializerOptions"/>
        /// </summary>
        private SerializerOptions() { }

        /// <summary>
        /// Backing field for the <see cref="Options"/> property
        /// </summary>
        private static JsonSerializerOptions options;

        /// <summary>
        /// Object to lock the options
        /// </summary>
        private static readonly object Lock = new object();

        /// <summary>
        /// Gets the instance that it's been used of this <see cref="SerializerOptions"/>
        /// </summary>
        public static JsonSerializerOptions Options
        {
            get
            {
                if(options == null)
                {
                    lock (Lock)
                    {
                        if(options == null)
                        {
                            options = new JsonSerializerOptions()
                            {
                                WriteIndented = false,
                                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,                             
                                PropertyNameCaseInsensitive = true,
                                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
                            };                            
                        }
                    }
                }

                return options;
            }
        }

        /// <summary>
        /// Copies the <see cref="JsonSerializerOptions"/> and returns a new instance
        /// </summary>
        /// <returns>the new instance</returns>
        public static JsonSerializerOptions Copy()
        {
            return new JsonSerializerOptions(Options);
        }
    }
}
