// ------------------------------------------------------------------------------------------------
// <copyright file="ModellingAnnotationItemPropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
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
    public partial class ModellingAnnotationItem
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
                case "approvedby":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var approvedByUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && approvedByUpperBound == int.MaxValue && !this.ApprovedBy.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Approval>();
                        }

                        var sentinelApproval = new Approval(Guid.Empty, null, null);

                        return sentinelApproval.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        approvedByUpperBound = this.ApprovedBy.Count - 1;
                    }

                    if (this.ApprovedBy.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ApprovedBy property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ApprovedBy.Count - 1 < approvedByUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ApprovedBy property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ApprovedBy[pd.Lower.Value];
                        }

                        return this.ApprovedBy[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var approvedByObjects = new List<Approval>();

                        for (var i = pd.Lower.Value; i < approvedByUpperBound + 1; i++)
                        {
                            approvedByObjects.Add(this.ApprovedBy[i]);
                        }

                        return approvedByObjects;
                    }

                    var approvedByNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < approvedByUpperBound + 1; i++)
                    {
                        var queryResult = this.ApprovedBy[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    approvedByNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                approvedByNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return approvedByNextObjects;
                case "author":
                    return base.QueryValue(pd.Input);
                case "category":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var categoryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && categoryUpperBound == int.MaxValue && !this.Category.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Category>();
                        }

                        var sentinelCategory = new Category(Guid.Empty, null, null);

                        return sentinelCategory.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        categoryUpperBound = this.Category.Count - 1;
                    }

                    if (this.Category.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Category property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Category.Count - 1 < categoryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Category property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Category[pd.Lower.Value];
                        }

                        return this.Category[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var categoryObjects = new List<Category>();

                        for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                        {
                            categoryObjects.Add(this.Category[i]);
                        }

                        return categoryObjects;
                    }

                    var categoryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                    {
                        var queryResult = this.Category[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    categoryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                categoryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return categoryNextObjects;
                case "classification":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Classification;
                case "content":
                    return base.QueryValue(pd.Input);
                case "createdon":
                    return base.QueryValue(pd.Input);
                case "discussion":
                    return base.QueryValue(pd.Input);
                case "languagecode":
                    return base.QueryValue(pd.Input);
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Owner;
                    }

                    if (this.Owner != null)
                    {
                        return this.Owner.QueryValue(pd.Next.Input);
                    }

                    var sentinelowner = new DomainOfExpertise(Guid.Empty, null, null);
                    return sentinelowner.QuerySentinelValue(pd.Next.Input, false);
                case "primaryannotatedthing":
                    return base.QueryValue(pd.Input);
                case "relatedthing":
                    return base.QueryValue(pd.Input);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ShortName;
                case "sourceannotation":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var sourceAnnotationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && sourceAnnotationUpperBound == int.MaxValue && !this.SourceAnnotation.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ModellingAnnotationItem>();
                        }

                        var sentinelModellingAnnotationItem = new ActionItem(Guid.Empty, null, null);

                        return sentinelModellingAnnotationItem.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        sourceAnnotationUpperBound = this.SourceAnnotation.Count - 1;
                    }

                    if (this.SourceAnnotation.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for SourceAnnotation property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.SourceAnnotation.Count - 1 < sourceAnnotationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the SourceAnnotation property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.SourceAnnotation[pd.Lower.Value];
                        }

                        return this.SourceAnnotation[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var sourceAnnotationObjects = new List<ModellingAnnotationItem>();

                        for (var i = pd.Lower.Value; i < sourceAnnotationUpperBound + 1; i++)
                        {
                            sourceAnnotationObjects.Add(this.SourceAnnotation[i]);
                        }

                        return sourceAnnotationObjects;
                    }

                    var sourceAnnotationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < sourceAnnotationUpperBound + 1; i++)
                    {
                        var queryResult = this.SourceAnnotation[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    sourceAnnotationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                sourceAnnotationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return sourceAnnotationNextObjects;
                case "status":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Status;
                case "title":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.Title;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
