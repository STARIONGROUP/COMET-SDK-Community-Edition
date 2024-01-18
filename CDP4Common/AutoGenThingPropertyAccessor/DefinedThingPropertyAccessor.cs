// ------------------------------------------------------------------------------------------------
// <copyright file="DefinedThingPropertyAccessor.cs" company="RHEA System S.A.">
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

namespace CDP4Common.CommonData
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
    public partial class DefinedThing
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
                case "alias":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var aliasUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && aliasUpperBound == int.MaxValue && !this.Alias.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Alias>();
                        }

                        var sentinelAlias = new Alias(Guid.Empty, null, null);

                        return sentinelAlias.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        aliasUpperBound = this.Alias.Count - 1;
                    }

                    if (this.Alias.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Alias property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Alias.Count - 1 < aliasUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Alias property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Alias[pd.Lower.Value];
                        }

                        return this.Alias[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var aliasObjects = new List<Alias>();

                        for (var i = pd.Lower.Value; i < aliasUpperBound + 1; i++)
                        {
                            aliasObjects.Add(this.Alias[i]);
                        }

                        return aliasObjects;
                    }

                    var aliasNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < aliasUpperBound + 1; i++)
                    {
                        var queryResult = this.Alias[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    aliasNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                aliasNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return aliasNextObjects;
                case "attachment":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var attachmentUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && attachmentUpperBound == int.MaxValue && !this.Attachment.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Attachment>();
                        }

                        var sentinelAttachment = new Attachment(Guid.Empty, null, null);

                        return sentinelAttachment.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        attachmentUpperBound = this.Attachment.Count - 1;
                    }

                    if (this.Attachment.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Attachment property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Attachment.Count - 1 < attachmentUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Attachment property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Attachment[pd.Lower.Value];
                        }

                        return this.Attachment[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var attachmentObjects = new List<Attachment>();

                        for (var i = pd.Lower.Value; i < attachmentUpperBound + 1; i++)
                        {
                            attachmentObjects.Add(this.Attachment[i]);
                        }

                        return attachmentObjects;
                    }

                    var attachmentNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < attachmentUpperBound + 1; i++)
                    {
                        var queryResult = this.Attachment[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    attachmentNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                attachmentNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return attachmentNextObjects;
                case "definition":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var definitionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && definitionUpperBound == int.MaxValue && !this.Definition.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Definition>();
                        }

                        var sentinelDefinition = new Definition(Guid.Empty, null, null);

                        return sentinelDefinition.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        definitionUpperBound = this.Definition.Count - 1;
                    }

                    if (this.Definition.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Definition property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Definition.Count - 1 < definitionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Definition property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Definition[pd.Lower.Value];
                        }

                        return this.Definition[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var definitionObjects = new List<Definition>();

                        for (var i = pd.Lower.Value; i < definitionUpperBound + 1; i++)
                        {
                            definitionObjects.Add(this.Definition[i]);
                        }

                        return definitionObjects;
                    }

                    var definitionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < definitionUpperBound + 1; i++)
                    {
                        var queryResult = this.Definition[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    definitionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                definitionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return definitionNextObjects;
                case "hyperlink":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var hyperLinkUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && hyperLinkUpperBound == int.MaxValue && !this.HyperLink.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<HyperLink>();
                        }

                        var sentinelHyperLink = new HyperLink(Guid.Empty, null, null);

                        return sentinelHyperLink.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        hyperLinkUpperBound = this.HyperLink.Count - 1;
                    }

                    if (this.HyperLink.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for HyperLink property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.HyperLink.Count - 1 < hyperLinkUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the HyperLink property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.HyperLink[pd.Lower.Value];
                        }

                        return this.HyperLink[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var hyperLinkObjects = new List<HyperLink>();

                        for (var i = pd.Lower.Value; i < hyperLinkUpperBound + 1; i++)
                        {
                            hyperLinkObjects.Add(this.HyperLink[i]);
                        }

                        return hyperLinkObjects;
                    }

                    var hyperLinkNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < hyperLinkUpperBound + 1; i++)
                    {
                        var queryResult = this.HyperLink[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    hyperLinkNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                hyperLinkNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return hyperLinkNextObjects;
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Name;
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ShortName;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
