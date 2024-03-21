// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancySerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using ReviewItemDiscrepancy = CDP4Common.DTO.ReviewItemDiscrepancy;

    /// <summary>
    /// The purpose of the <see cref="ReviewItemDiscrepancySerializer"/> class is to provide a <see cref="ReviewItemDiscrepancy"/> specific serializer
    /// </summary>
    public class ReviewItemDiscrepancySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="ReviewItemDiscrepancy"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            switch(propertyName.ToLower())
            {
                case "actor":
                    var allowedVersionsForActor = new List<string>
                    {
                        "1.3.0",
                    };

                    if(!allowedVersionsForActor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("actor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "approvedby":
                    var allowedVersionsForApprovedBy = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForApprovedBy.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("approvedBy"u8);

                    if(value is IEnumerable<object> objectListApprovedBy)
                    {
                        foreach(var approvedByItem in objectListApprovedBy.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(approvedByItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "author":
                    var allowedVersionsForAuthor = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAuthor.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForCategory = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForCategory.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("category"u8);

                    if(value is IEnumerable<object> objectListCategory)
                    {
                        foreach(var categoryItem in objectListCategory.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(categoryItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "classification":
                    var allowedVersionsForClassification = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForClassification.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForClassKind = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForClassKind.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForContent = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForContent.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForCreatedOn = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForCreatedOn.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForDiscussion = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForDiscussion.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("discussion"u8);

                    if(value is IEnumerable<object> objectListDiscussion)
                    {
                        foreach(var discussionItem in objectListDiscussion.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(discussionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "excludeddomain":
                    var allowedVersionsForExcludedDomain = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExcludedDomain.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedDomain"u8);

                    if(value is IEnumerable<object> objectListExcludedDomain)
                    {
                        foreach(var excludedDomainItem in objectListExcludedDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedDomainItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "excludedperson":
                    var allowedVersionsForExcludedPerson = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExcludedPerson.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedPerson"u8);

                    if(value is IEnumerable<object> objectListExcludedPerson)
                    {
                        foreach(var excludedPersonItem in objectListExcludedPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedPersonItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "iid":
                    var allowedVersionsForIid = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIid.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForLanguageCode = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForLanguageCode.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForModifiedOn = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForModifiedOn.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForOwner = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForOwner.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForPrimaryAnnotatedThing = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForPrimaryAnnotatedThing.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForRelatedThing = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRelatedThing.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    if(value is IEnumerable<object> objectListRelatedThing)
                    {
                        foreach(var relatedThingItem in objectListRelatedThing.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(relatedThingItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "revisionnumber":
                    var allowedVersionsForRevisionNumber = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRevisionNumber.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForShortName = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForShortName.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "solution":
                    var allowedVersionsForSolution = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForSolution.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("solution"u8);

                    if(value is IEnumerable<object> objectListSolution)
                    {
                        foreach(var solutionItem in objectListSolution.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(solutionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "sourceannotation":
                    var allowedVersionsForSourceAnnotation = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForSourceAnnotation.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("sourceAnnotation"u8);

                    if(value is IEnumerable<object> objectListSourceAnnotation)
                    {
                        foreach(var sourceAnnotationItem in objectListSourceAnnotation.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(sourceAnnotationItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "status":
                    var allowedVersionsForStatus = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStatus.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForThingPreference = new List<string>
                    {
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForThingPreference.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForTitle = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForTitle.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ReviewItemDiscrepancy");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ReviewItemDiscrepancy" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ReviewItemDiscrepancy reviewItemDiscrepancy)
            {
                throw new ArgumentException("The thing shall be a ReviewItemDiscrepancy", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.1.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ReviewItemDiscrepancy since Version is below 1.1.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing ReviewItemDiscrepancy for Version 1.1.0");
                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in reviewItemDiscrepancy.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in reviewItemDiscrepancy.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in reviewItemDiscrepancy.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in reviewItemDiscrepancy.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in reviewItemDiscrepancy.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(reviewItemDiscrepancy.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(reviewItemDiscrepancy.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in reviewItemDiscrepancy.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(reviewItemDiscrepancy.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ShortName);
                    writer.WriteStartArray("solution"u8);

                    foreach(var solutionItem in reviewItemDiscrepancy.Solution.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(solutionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in reviewItemDiscrepancy.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Status.ToString());
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Title);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing ReviewItemDiscrepancy for Version 1.2.0");
                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in reviewItemDiscrepancy.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in reviewItemDiscrepancy.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in reviewItemDiscrepancy.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in reviewItemDiscrepancy.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in reviewItemDiscrepancy.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(reviewItemDiscrepancy.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(reviewItemDiscrepancy.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in reviewItemDiscrepancy.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(reviewItemDiscrepancy.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ShortName);
                    writer.WriteStartArray("solution"u8);

                    foreach(var solutionItem in reviewItemDiscrepancy.Solution.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(solutionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in reviewItemDiscrepancy.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Status.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ThingPreference);
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Title);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing ReviewItemDiscrepancy for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(reviewItemDiscrepancy.Actor.HasValue)
                    {
                        writer.WriteStringValue(reviewItemDiscrepancy.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("approvedBy"u8);

                    foreach(var approvedByItem in reviewItemDiscrepancy.ApprovedBy.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(approvedByItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Author);
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in reviewItemDiscrepancy.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classification"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Classification.ToString());
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in reviewItemDiscrepancy.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in reviewItemDiscrepancy.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in reviewItemDiscrepancy.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Owner);
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(reviewItemDiscrepancy.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(reviewItemDiscrepancy.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in reviewItemDiscrepancy.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(reviewItemDiscrepancy.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ShortName);
                    writer.WriteStartArray("solution"u8);

                    foreach(var solutionItem in reviewItemDiscrepancy.Solution.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(solutionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("sourceAnnotation"u8);

                    foreach(var sourceAnnotationItem in reviewItemDiscrepancy.SourceAnnotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sourceAnnotationItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("status"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Status.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.ThingPreference);
                    writer.WritePropertyName("title"u8);
                    writer.WriteStringValue(reviewItemDiscrepancy.Title);
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
