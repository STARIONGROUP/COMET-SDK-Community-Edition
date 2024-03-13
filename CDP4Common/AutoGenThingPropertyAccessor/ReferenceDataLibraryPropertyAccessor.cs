// ------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibraryPropertyAccessor.cs" company="RHEA System S.A.">
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

namespace CDP4Common.SiteDirectoryData
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
    using CDP4Common.Types;

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class ReferenceDataLibrary
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
                    return this.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return this.QueryThingValues(pd.Input);
                case "classkind":
                    return this.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return this.QueryThingValues(pd.Input);
                case "excludedperson":
                    return this.QueryThingValues(pd.Input);
                case "modifiedon":
                    return this.QueryThingValues(pd.Input);
                case "thingpreference":
                    return this.QueryThingValues(pd.Input);
                case "actor":
                    return this.QueryThingValues(pd.Input);
                case "container":
                    return this.QueryThingValues(pd.Input);
                case "alias":
                    return base.QueryValue(pd.Input);
                case "basequantitykind":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var baseQuantityKindUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && baseQuantityKindUpperBound == int.MaxValue && !this.BaseQuantityKind.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<QuantityKind>();
                        }

                        var sentinelQuantityKind = new DerivedQuantityKind(Guid.Empty, null, null);

                        return sentinelQuantityKind.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        baseQuantityKindUpperBound = this.BaseQuantityKind.Count - 1;
                    }

                    if (this.BaseQuantityKind.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for BaseQuantityKind property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.BaseQuantityKind.Count - 1 < baseQuantityKindUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the BaseQuantityKind property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.BaseQuantityKind[pd.Lower.Value];
                        }

                        return this.BaseQuantityKind[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var baseQuantityKindObjects = new List<QuantityKind>();

                        for (var i = pd.Lower.Value; i < baseQuantityKindUpperBound + 1; i++)
                        {
                            baseQuantityKindObjects.Add(this.BaseQuantityKind[i]);
                        }

                        return baseQuantityKindObjects;
                    }

                    var baseQuantityKindNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < baseQuantityKindUpperBound + 1; i++)
                    {
                        var queryResult = this.BaseQuantityKind[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    baseQuantityKindNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                baseQuantityKindNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return baseQuantityKindNextObjects;
                case "baseunit":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var baseUnitUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && baseUnitUpperBound == int.MaxValue && !this.BaseUnit.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<MeasurementUnit>();
                        }

                        var sentinelMeasurementUnit = new DerivedUnit(Guid.Empty, null, null);

                        return sentinelMeasurementUnit.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        baseUnitUpperBound = this.BaseUnit.Count - 1;
                    }

                    if (this.BaseUnit.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for BaseUnit property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.BaseUnit.Count - 1 < baseUnitUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the BaseUnit property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.BaseUnit[pd.Lower.Value];
                        }

                        return this.BaseUnit[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var baseUnitObjects = new List<MeasurementUnit>();

                        for (var i = pd.Lower.Value; i < baseUnitUpperBound + 1; i++)
                        {
                            baseUnitObjects.Add(this.BaseUnit[i]);
                        }

                        return baseUnitObjects;
                    }

                    var baseUnitNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < baseUnitUpperBound + 1; i++)
                    {
                        var queryResult = this.BaseUnit[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    baseUnitNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                baseUnitNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return baseUnitNextObjects;
                case "constant":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var constantUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && constantUpperBound == int.MaxValue && !this.Constant.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Constant>();
                        }

                        var sentinelConstant = new Constant(Guid.Empty, null, null);

                        return sentinelConstant.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        constantUpperBound = this.Constant.Count - 1;
                    }

                    if (this.Constant.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Constant property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Constant.Count - 1 < constantUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Constant property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Constant[pd.Lower.Value];
                        }

                        return this.Constant[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var constantObjects = new List<Constant>();

                        for (var i = pd.Lower.Value; i < constantUpperBound + 1; i++)
                        {
                            constantObjects.Add(this.Constant[i]);
                        }

                        return constantObjects;
                    }

                    var constantNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < constantUpperBound + 1; i++)
                    {
                        var queryResult = this.Constant[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    constantNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                constantNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return constantNextObjects;
                case "definedcategory":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var definedCategoryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && definedCategoryUpperBound == int.MaxValue && !this.DefinedCategory.Any())
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
                        definedCategoryUpperBound = this.DefinedCategory.Count - 1;
                    }

                    if (this.DefinedCategory.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DefinedCategory property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DefinedCategory.Count - 1 < definedCategoryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DefinedCategory property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DefinedCategory[pd.Lower.Value];
                        }

                        return this.DefinedCategory[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var definedCategoryObjects = new List<Category>();

                        for (var i = pd.Lower.Value; i < definedCategoryUpperBound + 1; i++)
                        {
                            definedCategoryObjects.Add(this.DefinedCategory[i]);
                        }

                        return definedCategoryObjects;
                    }

                    var definedCategoryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < definedCategoryUpperBound + 1; i++)
                    {
                        var queryResult = this.DefinedCategory[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    definedCategoryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                definedCategoryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return definedCategoryNextObjects;
                case "definition":
                    return base.QueryValue(pd.Input);
                case "filetype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var fileTypeUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && fileTypeUpperBound == int.MaxValue && !this.FileType.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<FileType>();
                        }

                        var sentinelFileType = new FileType(Guid.Empty, null, null);

                        return sentinelFileType.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        fileTypeUpperBound = this.FileType.Count - 1;
                    }

                    if (this.FileType.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for FileType property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.FileType.Count - 1 < fileTypeUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the FileType property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.FileType[pd.Lower.Value];
                        }

                        return this.FileType[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var fileTypeObjects = new List<FileType>();

                        for (var i = pd.Lower.Value; i < fileTypeUpperBound + 1; i++)
                        {
                            fileTypeObjects.Add(this.FileType[i]);
                        }

                        return fileTypeObjects;
                    }

                    var fileTypeNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < fileTypeUpperBound + 1; i++)
                    {
                        var queryResult = this.FileType[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    fileTypeNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                fileTypeNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return fileTypeNextObjects;
                case "glossary":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var glossaryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && glossaryUpperBound == int.MaxValue && !this.Glossary.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Glossary>();
                        }

                        var sentinelGlossary = new Glossary(Guid.Empty, null, null);

                        return sentinelGlossary.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        glossaryUpperBound = this.Glossary.Count - 1;
                    }

                    if (this.Glossary.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Glossary property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Glossary.Count - 1 < glossaryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Glossary property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Glossary[pd.Lower.Value];
                        }

                        return this.Glossary[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var glossaryObjects = new List<Glossary>();

                        for (var i = pd.Lower.Value; i < glossaryUpperBound + 1; i++)
                        {
                            glossaryObjects.Add(this.Glossary[i]);
                        }

                        return glossaryObjects;
                    }

                    var glossaryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < glossaryUpperBound + 1; i++)
                    {
                        var queryResult = this.Glossary[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    glossaryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                glossaryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return glossaryNextObjects;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "parametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var parameterTypeUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && parameterTypeUpperBound == int.MaxValue && !this.ParameterType.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ParameterType>();
                        }

                        var sentinelParameterType = new CompoundParameterType(Guid.Empty, null, null);

                        return sentinelParameterType.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        parameterTypeUpperBound = this.ParameterType.Count - 1;
                    }

                    if (this.ParameterType.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ParameterType property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ParameterType.Count - 1 < parameterTypeUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ParameterType property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ParameterType[pd.Lower.Value];
                        }

                        return this.ParameterType[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var parameterTypeObjects = new List<ParameterType>();

                        for (var i = pd.Lower.Value; i < parameterTypeUpperBound + 1; i++)
                        {
                            parameterTypeObjects.Add(this.ParameterType[i]);
                        }

                        return parameterTypeObjects;
                    }

                    var parameterTypeNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < parameterTypeUpperBound + 1; i++)
                    {
                        var queryResult = this.ParameterType[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    parameterTypeNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                parameterTypeNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return parameterTypeNextObjects;
                case "referencesource":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var referenceSourceUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && referenceSourceUpperBound == int.MaxValue && !this.ReferenceSource.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ReferenceSource>();
                        }

                        var sentinelReferenceSource = new ReferenceSource(Guid.Empty, null, null);

                        return sentinelReferenceSource.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        referenceSourceUpperBound = this.ReferenceSource.Count - 1;
                    }

                    if (this.ReferenceSource.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ReferenceSource property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ReferenceSource.Count - 1 < referenceSourceUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ReferenceSource property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ReferenceSource[pd.Lower.Value];
                        }

                        return this.ReferenceSource[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var referenceSourceObjects = new List<ReferenceSource>();

                        for (var i = pd.Lower.Value; i < referenceSourceUpperBound + 1; i++)
                        {
                            referenceSourceObjects.Add(this.ReferenceSource[i]);
                        }

                        return referenceSourceObjects;
                    }

                    var referenceSourceNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < referenceSourceUpperBound + 1; i++)
                    {
                        var queryResult = this.ReferenceSource[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    referenceSourceNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                referenceSourceNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return referenceSourceNextObjects;
                case "requiredrdl":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.RequiredRdl;
                    }

                    if (this.RequiredRdl != null)
                    {
                        return this.RequiredRdl.QueryValue(pd.Next.Input);
                    }

                    var sentinelrequiredrdl = new SiteReferenceDataLibrary(Guid.Empty, null, null);
                    return sentinelrequiredrdl.QuerySentinelValue(pd.Next.Input, false);
                case "rule":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var ruleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && ruleUpperBound == int.MaxValue && !this.Rule.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Rule>();
                        }

                        var sentinelRule = new BinaryRelationshipRule(Guid.Empty, null, null);

                        return sentinelRule.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        ruleUpperBound = this.Rule.Count - 1;
                    }

                    if (this.Rule.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Rule property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Rule.Count - 1 < ruleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Rule property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Rule[pd.Lower.Value];
                        }

                        return this.Rule[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var ruleObjects = new List<Rule>();

                        for (var i = pd.Lower.Value; i < ruleUpperBound + 1; i++)
                        {
                            ruleObjects.Add(this.Rule[i]);
                        }

                        return ruleObjects;
                    }

                    var ruleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < ruleUpperBound + 1; i++)
                    {
                        var queryResult = this.Rule[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    ruleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                ruleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return ruleNextObjects;
                case "scale":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var scaleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && scaleUpperBound == int.MaxValue && !this.Scale.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<MeasurementScale>();
                        }

                        var sentinelMeasurementScale = new IntervalScale(Guid.Empty, null, null);

                        return sentinelMeasurementScale.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        scaleUpperBound = this.Scale.Count - 1;
                    }

                    if (this.Scale.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Scale property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Scale.Count - 1 < scaleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Scale property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Scale[pd.Lower.Value];
                        }

                        return this.Scale[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var scaleObjects = new List<MeasurementScale>();

                        for (var i = pd.Lower.Value; i < scaleUpperBound + 1; i++)
                        {
                            scaleObjects.Add(this.Scale[i]);
                        }

                        return scaleObjects;
                    }

                    var scaleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < scaleUpperBound + 1; i++)
                    {
                        var queryResult = this.Scale[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    scaleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                scaleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return scaleNextObjects;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "unit":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var unitUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && unitUpperBound == int.MaxValue && !this.Unit.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<MeasurementUnit>();
                        }

                        var sentinelMeasurementUnit = new DerivedUnit(Guid.Empty, null, null);

                        return sentinelMeasurementUnit.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        unitUpperBound = this.Unit.Count - 1;
                    }

                    if (this.Unit.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Unit property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Unit.Count - 1 < unitUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Unit property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Unit[pd.Lower.Value];
                        }

                        return this.Unit[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var unitObjects = new List<MeasurementUnit>();

                        for (var i = pd.Lower.Value; i < unitUpperBound + 1; i++)
                        {
                            unitObjects.Add(this.Unit[i]);
                        }

                        return unitObjects;
                    }

                    var unitNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < unitUpperBound + 1; i++)
                    {
                        var queryResult = this.Unit[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    unitNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                unitNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return unitNextObjects;
                case "unitprefix":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var unitPrefixUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && unitPrefixUpperBound == int.MaxValue && !this.UnitPrefix.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<UnitPrefix>();
                        }

                        var sentinelUnitPrefix = new UnitPrefix(Guid.Empty, null, null);

                        return sentinelUnitPrefix.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        unitPrefixUpperBound = this.UnitPrefix.Count - 1;
                    }

                    if (this.UnitPrefix.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for UnitPrefix property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.UnitPrefix.Count - 1 < unitPrefixUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the UnitPrefix property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.UnitPrefix[pd.Lower.Value];
                        }

                        return this.UnitPrefix[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var unitPrefixObjects = new List<UnitPrefix>();

                        for (var i = pd.Lower.Value; i < unitPrefixUpperBound + 1; i++)
                        {
                            unitPrefixObjects.Add(this.UnitPrefix[i]);
                        }

                        return unitPrefixObjects;
                    }

                    var unitPrefixNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < unitPrefixUpperBound + 1; i++)
                    {
                        var queryResult = this.UnitPrefix[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    unitPrefixNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                unitPrefixNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return unitPrefixNextObjects;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }

        /// <summary>
        /// Sets the value of the specified property
        /// </summary>
        /// <param name="path">The path of the property for which the value is to be set</param>
        /// <param name="value">Any value to set</param>
        /// <exception cref="ArgumentException">If the type of the <paramref name="value"/> do not match the type of the property to set</exception>
        /// <remarks>This action override the currently set value, if any</remarks>
        public override void SetValue(string path, object value)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);
            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "revisionnumber":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "classkind":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludeddomain":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludedperson":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "modifiedon":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "thingpreference":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "actor":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "alias":
                    base.SetValue(pd.Input, value);
                    return;
                case "basequantitykind":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.BaseQuantityKind.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case QuantityKind baseQuantityKindValue:
                            this.BaseQuantityKind.Clear();
                            this.BaseQuantityKind.Add(baseQuantityKindValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.BaseQuantityKind.Clear();
                            this.BaseQuantityKind.AddRange(thingValues.OfType<QuantityKind>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a QuantityKind or a collection of QuantityKind" , nameof(value));
                    }
                case "baseunit":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.BaseUnit.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case MeasurementUnit baseUnitValue:
                            this.BaseUnit.Clear();
                            this.BaseUnit.Add(baseUnitValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.BaseUnit.Clear();
                            this.BaseUnit.AddRange(thingValues.OfType<MeasurementUnit>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MeasurementUnit or a collection of MeasurementUnit" , nameof(value));
                    }
                case "constant":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Constant.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Constant constantValue:
                            this.Constant.Clear();
                            this.Constant.Add(constantValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Constant.Clear();
                            this.Constant.AddRange(thingValues.OfType<Constant>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Constant or a collection of Constant" , nameof(value));
                    }
                case "definedcategory":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.DefinedCategory.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Category definedCategoryValue:
                            this.DefinedCategory.Clear();
                            this.DefinedCategory.Add(definedCategoryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.DefinedCategory.Clear();
                            this.DefinedCategory.AddRange(thingValues.OfType<Category>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Category or a collection of Category" , nameof(value));
                    }
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "filetype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.FileType.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case FileType fileTypeValue:
                            this.FileType.Clear();
                            this.FileType.Add(fileTypeValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.FileType.Clear();
                            this.FileType.AddRange(thingValues.OfType<FileType>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a FileType or a collection of FileType" , nameof(value));
                    }
                case "glossary":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Glossary.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Glossary glossaryValue:
                            this.Glossary.Clear();
                            this.Glossary.Add(glossaryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Glossary.Clear();
                            this.Glossary.AddRange(thingValues.OfType<Glossary>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Glossary or a collection of Glossary" , nameof(value));
                    }
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "parametertype":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ParameterType.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ParameterType parameterTypeValue:
                            this.ParameterType.Clear();
                            this.ParameterType.Add(parameterTypeValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ParameterType.Clear();
                            this.ParameterType.AddRange(thingValues.OfType<ParameterType>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterType or a collection of ParameterType" , nameof(value));
                    }
                case "referencesource":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ReferenceSource.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ReferenceSource referenceSourceValue:
                            this.ReferenceSource.Clear();
                            this.ReferenceSource.Add(referenceSourceValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ReferenceSource.Clear();
                            this.ReferenceSource.AddRange(thingValues.OfType<ReferenceSource>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ReferenceSource or a collection of ReferenceSource" , nameof(value));
                    }
                case "requiredrdl":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is SiteReferenceDataLibrary requiredRdlValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a SiteReferenceDataLibrary" , nameof(value));
                    }

                    this.RequiredRdl = requiredRdlValue;
                    return;
                case "rule":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Rule.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Rule ruleValue:
                            this.Rule.Clear();
                            this.Rule.Add(ruleValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Rule.Clear();
                            this.Rule.AddRange(thingValues.OfType<Rule>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Rule or a collection of Rule" , nameof(value));
                    }
                case "scale":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Scale.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case MeasurementScale scaleValue:
                            this.Scale.Clear();
                            this.Scale.Add(scaleValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Scale.Clear();
                            this.Scale.AddRange(thingValues.OfType<MeasurementScale>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MeasurementScale or a collection of MeasurementScale" , nameof(value));
                    }
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "unit":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Unit.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case MeasurementUnit unitValue:
                            this.Unit.Clear();
                            this.Unit.Add(unitValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Unit.Clear();
                            this.Unit.AddRange(thingValues.OfType<MeasurementUnit>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a MeasurementUnit or a collection of MeasurementUnit" , nameof(value));
                    }
                case "unitprefix":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.UnitPrefix.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case UnitPrefix unitPrefixValue:
                            this.UnitPrefix.Clear();
                            this.UnitPrefix.Add(unitPrefixValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.UnitPrefix.Clear();
                            this.UnitPrefix.AddRange(thingValues.OfType<UnitPrefix>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a UnitPrefix or a collection of UnitPrefix" , nameof(value));
                    }
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
