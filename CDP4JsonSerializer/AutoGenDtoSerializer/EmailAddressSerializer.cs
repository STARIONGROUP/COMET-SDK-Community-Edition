#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The purpose of the <see cref="EmailAddressSerializer"/> class is to provide a <see cref="EmailAddress"/> specific serializer
    /// </summary>
    public class EmailAddressSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "value", value => new JValue(value) },
            { "vcardType", vcardType => new JValue(vcardType.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="EmailAddress"/>
        /// </summary>
        /// <param name="emailAddress">The <see cref="EmailAddress"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EmailAddress emailAddress)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), emailAddress.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](emailAddress.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](emailAddress.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](emailAddress.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](emailAddress.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](emailAddress.RevisionNumber));
            jsonObject.Add("value", this.PropertySerializerMap["value"](emailAddress.Value));
            jsonObject.Add("vcardType", this.PropertySerializerMap["vcardType"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.VcardEmailAddressKind), emailAddress.VcardType)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EmailAddress"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var emailAddress = thing as EmailAddress;
            if (emailAddress == null)
            {
                throw new InvalidOperationException("The thing is not a EmailAddress.");
            }

            return this.Serialize(emailAddress);
        }
    }
}
