// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="ContractChangeNoticeSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using ContractChangeNotice = CDP4Common.DTO.ContractChangeNotice;

    /// <summary>
    /// The purpose of the <see cref="ContractChangeNoticeSerializer"/> class is to provide a <see cref="ContractChangeNotice"/> specific serializer
    /// </summary>
    public class ContractChangeNoticeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ContractChangeNotice" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ContractChangeNotice" />.
        /// When a Requested Data Model version for Serialization is lower than this, the object will not be Serialized, just ignored.
        /// NO error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version thingMinimalAllowedDataModelVersion = Version.Parse("1.1.0");

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ContractChangeNotice" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ContractChangeNotice contractChangeNotice)
            {
                throw new ArgumentException("The thing shall be a ContractChangeNotice", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of ContractChangeNotice.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ContractChangeNotice since Version is below 1.1.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing ContractChangeNotice for Version 1.1.0");
                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in contractChangeNotice.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(contractChangeNotice.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in contractChangeNotice.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("changeProposal"u8);
                    writer.WriteStringValue(contractChangeNotice.ChangeProposal);
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(contractChangeNotice.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(contractChangeNotice.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(contractChangeNotice.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(contractChangeNotice.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in contractChangeNotice.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(contractChangeNotice.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(contractChangeNotice.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(contractChangeNotice.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(contractChangeNotice.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if (contractChangeNotice.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(contractChangeNotice.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in contractChangeNotice.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(contractChangeNotice.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(contractChangeNotice.ShortName);
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(contractChangeNotice.Status.ToString());
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(contractChangeNotice.Title);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing ContractChangeNotice for Version 1.2.0");
                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in contractChangeNotice.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(contractChangeNotice.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in contractChangeNotice.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("changeProposal"u8);
                    writer.WriteStringValue(contractChangeNotice.ChangeProposal);
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(contractChangeNotice.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(contractChangeNotice.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(contractChangeNotice.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(contractChangeNotice.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in contractChangeNotice.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(contractChangeNotice.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(contractChangeNotice.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(contractChangeNotice.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(contractChangeNotice.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if (contractChangeNotice.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(contractChangeNotice.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in contractChangeNotice.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(contractChangeNotice.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(contractChangeNotice.ShortName);
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(contractChangeNotice.Status.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(contractChangeNotice.ThingPreference);
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(contractChangeNotice.Title);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing ContractChangeNotice for Version 1.3.0");
                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in contractChangeNotice.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(contractChangeNotice.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in contractChangeNotice.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("changeProposal"u8);
                    writer.WriteStringValue(contractChangeNotice.ChangeProposal);
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(contractChangeNotice.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(contractChangeNotice.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(contractChangeNotice.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(contractChangeNotice.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in contractChangeNotice.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(contractChangeNotice.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(contractChangeNotice.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(contractChangeNotice.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(contractChangeNotice.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if (contractChangeNotice.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(contractChangeNotice.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in contractChangeNotice.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(contractChangeNotice.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(contractChangeNotice.ShortName);
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(contractChangeNotice.Status.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(contractChangeNotice.ThingPreference);
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(contractChangeNotice.Title);
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ContractChangeNotice" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not ContractChangeNotice contractChangeNotice)
            {
                throw new ArgumentException("The thing shall be a ContractChangeNotice", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WriteStartArray("approvedBy"u8);

                foreach(var approvedByItem in contractChangeNotice.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(approvedByItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("author"u8);
                writer.WriteStringValue(contractChangeNotice.Author);

                writer.WriteStartArray("category"u8);

                foreach(var categoryItem in contractChangeNotice.Category.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(categoryItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("changeProposal"u8);
                writer.WriteStringValue(contractChangeNotice.ChangeProposal);
                writer.WritePropertyName("classification"u8);
                writer.WriteStringValue(contractChangeNotice.Classification.ToString());
                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(contractChangeNotice.ClassKind.ToString());
                writer.WritePropertyName("content"u8);
                writer.WriteStringValue(contractChangeNotice.Content);
                writer.WritePropertyName("createdOn"u8);
                writer.WriteStringValue(contractChangeNotice.CreatedOn.ToString(SerializerHelper.DateTimeFormat));

                writer.WriteStartArray("discussion"u8);

                foreach(var discussionItem in contractChangeNotice.Discussion.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(discussionItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(contractChangeNotice.Iid);
                writer.WritePropertyName("languageCode"u8);
                writer.WriteStringValue(contractChangeNotice.LanguageCode);
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(contractChangeNotice.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("owner"u8);
                writer.WriteStringValue(contractChangeNotice.Owner);
                writer.WritePropertyName("primaryAnnotatedThing"u8);

                if (contractChangeNotice.PrimaryAnnotatedThing.HasValue)
                {
                    writer.WriteStringValue(contractChangeNotice.PrimaryAnnotatedThing.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WriteStartArray("relatedThing"u8);

                foreach(var relatedThingItem in contractChangeNotice.RelatedThing.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(relatedThingItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(contractChangeNotice.RevisionNumber);
                writer.WritePropertyName("shortName"u8);
                writer.WriteStringValue(contractChangeNotice.ShortName);

                writer.WriteStartArray("sourceAnnotation"u8);

                foreach(var sourceAnnotationItem in contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(sourceAnnotationItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(contractChangeNotice.Status.ToString());
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(contractChangeNotice.ThingPreference);
                writer.WritePropertyName("title"u8);
                writer.WriteStringValue(contractChangeNotice.Title);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="ContractChangeNotice"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            if(!AllowedVersionsPerProperty[propertyName].Contains(requestedVersion))
            {
                return;
            }

            this.SerializeProperty(propertyName, value, writer);
        }

        /// <summary>
        /// Serialize a value for a <see cref="ContractChangeNotice"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
                case "approvedby":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListApprovedBy && objectListApprovedBy.Any())
                    {
                        writer.WriteStartArray("approvedBy"u8);

                        foreach(var approvedByItem in objectListApprovedBy.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(approvedByItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "author":
                    writer.WritePropertyName("author"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "category":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListCategory && objectListCategory.Any())
                    {
                        writer.WriteStartArray("category"u8);

                        foreach(var categoryItem in objectListCategory.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(categoryItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "changeproposal":
                    writer.WritePropertyName("changeProposal"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "classification":
                    writer.WritePropertyName("classification"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((AnnotationClassificationKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "classkind":
                    writer.WritePropertyName("classKind"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((ClassKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "content":
                    writer.WritePropertyName("content"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "createdon":
                    writer.WritePropertyName("createdOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "discussion":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListDiscussion && objectListDiscussion.Any())
                    {
                        writer.WriteStartArray("discussion"u8);

                        foreach(var discussionItem in objectListDiscussion.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(discussionItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "excludeddomain":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListExcludedDomain && objectListExcludedDomain.Any())
                    {
                        writer.WriteStartArray("excludedDomain"u8);

                        foreach(var excludedDomainItem in objectListExcludedDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedDomainItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "excludedperson":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListExcludedPerson && objectListExcludedPerson.Any())
                    {
                        writer.WriteStartArray("excludedPerson"u8);

                        foreach(var excludedPersonItem in objectListExcludedPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedPersonItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "iid":
                    writer.WritePropertyName("iid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "languagecode":
                    writer.WritePropertyName("languageCode"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "modifiedon":
                    writer.WritePropertyName("modifiedOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "owner":
                    writer.WritePropertyName("owner"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "primaryannotatedthing":
                    writer.WritePropertyName("primaryAnnotatedThing"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "relatedthing":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListRelatedThing && objectListRelatedThing.Any())
                    {
                        writer.WriteStartArray("relatedThing"u8);

                        foreach(var relatedThingItem in objectListRelatedThing.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(relatedThingItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "revisionnumber":
                    writer.WritePropertyName("revisionNumber"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((int)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "shortname":
                    writer.WritePropertyName("shortName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "sourceannotation":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListSourceAnnotation && objectListSourceAnnotation.Any())
                    {
                        writer.WriteStartArray("sourceAnnotation"u8);

                        foreach(var sourceAnnotationItem in objectListSourceAnnotation.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(sourceAnnotationItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "status":
                    writer.WritePropertyName("status"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((AnnotationStatusKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "thingpreference":
                    writer.WritePropertyName("thingPreference"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "title":
                    writer.WritePropertyName("title"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ContractChangeNotice");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "approvedBy", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "author", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "category", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "changeProposal", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "classification", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "content", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "createdOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "discussion", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "languageCode", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "owner", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "primaryAnnotatedThing", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "relatedThing", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "sourceAnnotation", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "status", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
            { "title", new []{ "1.1.0", "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
