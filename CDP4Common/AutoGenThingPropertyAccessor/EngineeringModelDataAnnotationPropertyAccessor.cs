// ------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataAnnotationPropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.PropertyAccesor;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class EngineeringModelDataAnnotation
    {
        /// <summary>
        /// Queries the value(s) of the specified property
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <returns>
        /// an object that represents the value.
        /// </returns>
        /// <remarks>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof
        /// </remarks>
        public override object QueryValue(string path)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    return base.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return base.QueryThingValues(pd.Input);
                case "classkind":
                    return base.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return base.QueryThingValues(pd.Input);
                case "excludedperson":
                    return base.QueryThingValues(pd.Input);
                case "modifiedon":
                    return base.QueryThingValues(pd.Input);
                case "thingpreference":
                    return base.QueryThingValues(pd.Input);
                case "actor":
                    return base.QueryThingValues(pd.Input);
                case "author":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Author;
                    }

                    if (this.Author != null)
                    {
                        return this.Author.QueryValue(pd.Next.Input);
                    }

                    var sentinelauthor = new Participant(Guid.Empty, null, null);
                    return sentinelauthor.QuerySentinelValue(pd.Next.Input, false);
                case "content":
                    return base.QueryValue(pd.Input);
                case "createdon":
                    return base.QueryValue(pd.Input);
                case "discussion":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var discussionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && discussionUpperBound == int.MaxValue && !this.Discussion.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<EngineeringModelDataDiscussionItem>();
                        }

                        var sentinelEngineeringModelDataDiscussionItem = new EngineeringModelDataDiscussionItem(Guid.Empty, null, null);

                        return sentinelEngineeringModelDataDiscussionItem.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        discussionUpperBound = this.Discussion.Count - 1;
                    }

                    if (this.Discussion.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Discussion property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Discussion.Count - 1 < discussionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Discussion property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Discussion[pd.Lower.Value];
                        }

                        return this.Discussion[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var discussionObjects = new List<EngineeringModelDataDiscussionItem>();

                        for (var i = pd.Lower.Value; i < discussionUpperBound + 1; i++)
                        {
                            discussionObjects.Add(this.Discussion[i]);
                        }

                        return discussionObjects;
                    }

                    var discussionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < discussionUpperBound + 1; i++)
                    {
                        var queryResult = this.Discussion[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    discussionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                discussionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return discussionNextObjects;
                case "languagecode":
                    return base.QueryValue(pd.Input);
                case "primaryannotatedthing":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.PrimaryAnnotatedThing;
                    }

                    if (this.PrimaryAnnotatedThing != null)
                    {
                        return this.PrimaryAnnotatedThing.QueryValue(pd.Next.Input);
                    }

                    var sentinelprimaryannotatedthing = new ModellingThingReference(Guid.Empty, null, null);
                    return sentinelprimaryannotatedthing.QuerySentinelValue(pd.Next.Input, false);
                case "relatedthing":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var relatedThingUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && relatedThingUpperBound == int.MaxValue && !this.RelatedThing.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ModellingThingReference>();
                        }

                        var sentinelModellingThingReference = new ModellingThingReference(Guid.Empty, null, null);

                        return sentinelModellingThingReference.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        relatedThingUpperBound = this.RelatedThing.Count - 1;
                    }

                    if (this.RelatedThing.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for RelatedThing property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.RelatedThing.Count - 1 < relatedThingUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the RelatedThing property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.RelatedThing[pd.Lower.Value];
                        }

                        return this.RelatedThing[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var relatedThingObjects = new List<ModellingThingReference>();

                        for (var i = pd.Lower.Value; i < relatedThingUpperBound + 1; i++)
                        {
                            relatedThingObjects.Add(this.RelatedThing[i]);
                        }

                        return relatedThingObjects;
                    }

                    var relatedThingNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < relatedThingUpperBound + 1; i++)
                    {
                        var queryResult = this.RelatedThing[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    relatedThingNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                relatedThingNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return relatedThingNextObjects;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
