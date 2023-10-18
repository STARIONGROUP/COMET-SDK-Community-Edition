// ------------------------------------------------------------------------------------------------
// <copyright file="IterationPropertyAccessor.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    public partial class Iteration
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
                case "actualfinitestatelist":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var actualFiniteStateListUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && actualFiniteStateListUpperBound == int.MaxValue && !this.ActualFiniteStateList.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ActualFiniteStateList>();
                        }

                        var sentinelActualFiniteStateList = new ActualFiniteStateList(Guid.Empty, null, null);

                        return sentinelActualFiniteStateList.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        actualFiniteStateListUpperBound = this.ActualFiniteStateList.Count - 1;
                    }

                    if (this.ActualFiniteStateList.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ActualFiniteStateList property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ActualFiniteStateList.Count - 1 < actualFiniteStateListUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ActualFiniteStateList property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ActualFiniteStateList[pd.Lower.Value];
                        }

                        return this.ActualFiniteStateList[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var actualFiniteStateListObjects = new List<ActualFiniteStateList>();

                        for (var i = pd.Lower.Value; i < actualFiniteStateListUpperBound + 1; i++)
                        {
                            actualFiniteStateListObjects.Add(this.ActualFiniteStateList[i]);
                        }

                        return actualFiniteStateListObjects;
                    }

                    var actualFiniteStateListNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < actualFiniteStateListUpperBound + 1; i++)
                    {
                        var queryResult = this.ActualFiniteStateList[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    actualFiniteStateListNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                actualFiniteStateListNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return actualFiniteStateListNextObjects;
                case "defaultoption":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.DefaultOption;
                    }

                    if (this.DefaultOption != null)
                    {
                        return this.DefaultOption.QueryValue(pd.Next.Input);
                    }

                    var sentineldefaultoption = new Option(Guid.Empty, null, null);
                    return sentineldefaultoption.QuerySentinelValue(pd.Next.Input, false);
                case "diagramcanvas":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var diagramCanvasUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && diagramCanvasUpperBound == int.MaxValue && !this.DiagramCanvas.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DiagramCanvas>();
                        }

                        var sentinelDiagramCanvas = new DiagramCanvas(Guid.Empty, null, null);

                        return sentinelDiagramCanvas.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        diagramCanvasUpperBound = this.DiagramCanvas.Count - 1;
                    }

                    if (this.DiagramCanvas.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DiagramCanvas property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DiagramCanvas.Count - 1 < diagramCanvasUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DiagramCanvas property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DiagramCanvas[pd.Lower.Value];
                        }

                        return this.DiagramCanvas[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var diagramCanvasObjects = new List<DiagramCanvas>();

                        for (var i = pd.Lower.Value; i < diagramCanvasUpperBound + 1; i++)
                        {
                            diagramCanvasObjects.Add(this.DiagramCanvas[i]);
                        }

                        return diagramCanvasObjects;
                    }

                    var diagramCanvasNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < diagramCanvasUpperBound + 1; i++)
                    {
                        var queryResult = this.DiagramCanvas[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    diagramCanvasNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                diagramCanvasNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return diagramCanvasNextObjects;
                case "domainfilestore":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var domainFileStoreUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && domainFileStoreUpperBound == int.MaxValue && !this.DomainFileStore.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DomainFileStore>();
                        }

                        var sentinelDomainFileStore = new DomainFileStore(Guid.Empty, null, null);

                        return sentinelDomainFileStore.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        domainFileStoreUpperBound = this.DomainFileStore.Count - 1;
                    }

                    if (this.DomainFileStore.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DomainFileStore property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DomainFileStore.Count - 1 < domainFileStoreUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DomainFileStore property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DomainFileStore[pd.Lower.Value];
                        }

                        return this.DomainFileStore[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var domainFileStoreObjects = new List<DomainFileStore>();

                        for (var i = pd.Lower.Value; i < domainFileStoreUpperBound + 1; i++)
                        {
                            domainFileStoreObjects.Add(this.DomainFileStore[i]);
                        }

                        return domainFileStoreObjects;
                    }

                    var domainFileStoreNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < domainFileStoreUpperBound + 1; i++)
                    {
                        var queryResult = this.DomainFileStore[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    domainFileStoreNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                domainFileStoreNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return domainFileStoreNextObjects;
                case "element":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var elementUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && elementUpperBound == int.MaxValue && !this.Element.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ElementDefinition>();
                        }

                        var sentinelElementDefinition = new ElementDefinition(Guid.Empty, null, null);

                        return sentinelElementDefinition.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        elementUpperBound = this.Element.Count - 1;
                    }

                    if (this.Element.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Element property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Element.Count - 1 < elementUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Element property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Element[pd.Lower.Value];
                        }

                        return this.Element[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var elementObjects = new List<ElementDefinition>();

                        for (var i = pd.Lower.Value; i < elementUpperBound + 1; i++)
                        {
                            elementObjects.Add(this.Element[i]);
                        }

                        return elementObjects;
                    }

                    var elementNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < elementUpperBound + 1; i++)
                    {
                        var queryResult = this.Element[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    elementNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                elementNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return elementNextObjects;
                case "externalidentifiermap":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var externalIdentifierMapUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && externalIdentifierMapUpperBound == int.MaxValue && !this.ExternalIdentifierMap.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ExternalIdentifierMap>();
                        }

                        var sentinelExternalIdentifierMap = new ExternalIdentifierMap(Guid.Empty, null, null);

                        return sentinelExternalIdentifierMap.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        externalIdentifierMapUpperBound = this.ExternalIdentifierMap.Count - 1;
                    }

                    if (this.ExternalIdentifierMap.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ExternalIdentifierMap property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ExternalIdentifierMap.Count - 1 < externalIdentifierMapUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ExternalIdentifierMap property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ExternalIdentifierMap[pd.Lower.Value];
                        }

                        return this.ExternalIdentifierMap[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var externalIdentifierMapObjects = new List<ExternalIdentifierMap>();

                        for (var i = pd.Lower.Value; i < externalIdentifierMapUpperBound + 1; i++)
                        {
                            externalIdentifierMapObjects.Add(this.ExternalIdentifierMap[i]);
                        }

                        return externalIdentifierMapObjects;
                    }

                    var externalIdentifierMapNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < externalIdentifierMapUpperBound + 1; i++)
                    {
                        var queryResult = this.ExternalIdentifierMap[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    externalIdentifierMapNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                externalIdentifierMapNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return externalIdentifierMapNextObjects;
                case "goal":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var goalUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && goalUpperBound == int.MaxValue && !this.Goal.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Goal>();
                        }

                        var sentinelGoal = new Goal(Guid.Empty, null, null);

                        return sentinelGoal.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        goalUpperBound = this.Goal.Count - 1;
                    }

                    if (this.Goal.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Goal property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Goal.Count - 1 < goalUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Goal property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Goal[pd.Lower.Value];
                        }

                        return this.Goal[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var goalObjects = new List<Goal>();

                        for (var i = pd.Lower.Value; i < goalUpperBound + 1; i++)
                        {
                            goalObjects.Add(this.Goal[i]);
                        }

                        return goalObjects;
                    }

                    var goalNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < goalUpperBound + 1; i++)
                    {
                        var queryResult = this.Goal[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    goalNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                goalNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return goalNextObjects;
                case "iterationsetup":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.IterationSetup;
                    }

                    if (this.IterationSetup != null)
                    {
                        return this.IterationSetup.QueryValue(pd.Next.Input);
                    }

                    var sentineliterationsetup = new IterationSetup(Guid.Empty, null, null);
                    return sentineliterationsetup.QuerySentinelValue(pd.Next.Input, false);
                case "option":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var optionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && optionUpperBound == int.MaxValue && !this.Option.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Option>();
                        }

                        var sentinelOption = new Option(Guid.Empty, null, null);

                        return sentinelOption.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        optionUpperBound = this.Option.Count - 1;
                    }

                    if (this.Option.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Option property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Option.Count - 1 < optionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Option property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Option[pd.Lower.Value];
                        }

                        return this.Option[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var optionObjects = new List<Option>();

                        for (var i = pd.Lower.Value; i < optionUpperBound + 1; i++)
                        {
                            optionObjects.Add(this.Option[i]);
                        }

                        return optionObjects;
                    }

                    var optionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < optionUpperBound + 1; i++)
                    {
                        var queryResult = this.Option[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    optionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                optionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return optionNextObjects;
                case "possiblefinitestatelist":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var possibleFiniteStateListUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && possibleFiniteStateListUpperBound == int.MaxValue && !this.PossibleFiniteStateList.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<PossibleFiniteStateList>();
                        }

                        var sentinelPossibleFiniteStateList = new PossibleFiniteStateList(Guid.Empty, null, null);

                        return sentinelPossibleFiniteStateList.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        possibleFiniteStateListUpperBound = this.PossibleFiniteStateList.Count - 1;
                    }

                    if (this.PossibleFiniteStateList.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for PossibleFiniteStateList property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.PossibleFiniteStateList.Count - 1 < possibleFiniteStateListUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the PossibleFiniteStateList property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.PossibleFiniteStateList[pd.Lower.Value];
                        }

                        return this.PossibleFiniteStateList[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var possibleFiniteStateListObjects = new List<PossibleFiniteStateList>();

                        for (var i = pd.Lower.Value; i < possibleFiniteStateListUpperBound + 1; i++)
                        {
                            possibleFiniteStateListObjects.Add(this.PossibleFiniteStateList[i]);
                        }

                        return possibleFiniteStateListObjects;
                    }

                    var possibleFiniteStateListNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < possibleFiniteStateListUpperBound + 1; i++)
                    {
                        var queryResult = this.PossibleFiniteStateList[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    possibleFiniteStateListNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                possibleFiniteStateListNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return possibleFiniteStateListNextObjects;
                case "publication":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var publicationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && publicationUpperBound == int.MaxValue && !this.Publication.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Publication>();
                        }

                        var sentinelPublication = new Publication(Guid.Empty, null, null);

                        return sentinelPublication.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        publicationUpperBound = this.Publication.Count - 1;
                    }

                    if (this.Publication.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Publication property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Publication.Count - 1 < publicationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Publication property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Publication[pd.Lower.Value];
                        }

                        return this.Publication[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var publicationObjects = new List<Publication>();

                        for (var i = pd.Lower.Value; i < publicationUpperBound + 1; i++)
                        {
                            publicationObjects.Add(this.Publication[i]);
                        }

                        return publicationObjects;
                    }

                    var publicationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < publicationUpperBound + 1; i++)
                    {
                        var queryResult = this.Publication[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    publicationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                publicationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return publicationNextObjects;
                case "relationship":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var relationshipUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && relationshipUpperBound == int.MaxValue && !this.Relationship.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Relationship>();
                        }

                        var sentinelRelationship = new BinaryRelationship(Guid.Empty, null, null);

                        return sentinelRelationship.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        relationshipUpperBound = this.Relationship.Count - 1;
                    }

                    if (this.Relationship.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Relationship property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Relationship.Count - 1 < relationshipUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Relationship property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Relationship[pd.Lower.Value];
                        }

                        return this.Relationship[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var relationshipObjects = new List<Relationship>();

                        for (var i = pd.Lower.Value; i < relationshipUpperBound + 1; i++)
                        {
                            relationshipObjects.Add(this.Relationship[i]);
                        }

                        return relationshipObjects;
                    }

                    var relationshipNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < relationshipUpperBound + 1; i++)
                    {
                        var queryResult = this.Relationship[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    relationshipNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                relationshipNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return relationshipNextObjects;
                case "requirementsspecification":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var requirementsSpecificationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && requirementsSpecificationUpperBound == int.MaxValue && !this.RequirementsSpecification.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<RequirementsSpecification>();
                        }

                        var sentinelRequirementsSpecification = new RequirementsSpecification(Guid.Empty, null, null);

                        return sentinelRequirementsSpecification.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        requirementsSpecificationUpperBound = this.RequirementsSpecification.Count - 1;
                    }

                    if (this.RequirementsSpecification.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for RequirementsSpecification property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.RequirementsSpecification.Count - 1 < requirementsSpecificationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the RequirementsSpecification property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.RequirementsSpecification[pd.Lower.Value];
                        }

                        return this.RequirementsSpecification[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var requirementsSpecificationObjects = new List<RequirementsSpecification>();

                        for (var i = pd.Lower.Value; i < requirementsSpecificationUpperBound + 1; i++)
                        {
                            requirementsSpecificationObjects.Add(this.RequirementsSpecification[i]);
                        }

                        return requirementsSpecificationObjects;
                    }

                    var requirementsSpecificationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < requirementsSpecificationUpperBound + 1; i++)
                    {
                        var queryResult = this.RequirementsSpecification[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    requirementsSpecificationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                requirementsSpecificationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return requirementsSpecificationNextObjects;
                case "ruleverificationlist":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var ruleVerificationListUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && ruleVerificationListUpperBound == int.MaxValue && !this.RuleVerificationList.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<RuleVerificationList>();
                        }

                        var sentinelRuleVerificationList = new RuleVerificationList(Guid.Empty, null, null);

                        return sentinelRuleVerificationList.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        ruleVerificationListUpperBound = this.RuleVerificationList.Count - 1;
                    }

                    if (this.RuleVerificationList.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for RuleVerificationList property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.RuleVerificationList.Count - 1 < ruleVerificationListUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the RuleVerificationList property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.RuleVerificationList[pd.Lower.Value];
                        }

                        return this.RuleVerificationList[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var ruleVerificationListObjects = new List<RuleVerificationList>();

                        for (var i = pd.Lower.Value; i < ruleVerificationListUpperBound + 1; i++)
                        {
                            ruleVerificationListObjects.Add(this.RuleVerificationList[i]);
                        }

                        return ruleVerificationListObjects;
                    }

                    var ruleVerificationListNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < ruleVerificationListUpperBound + 1; i++)
                    {
                        var queryResult = this.RuleVerificationList[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    ruleVerificationListNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                ruleVerificationListNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return ruleVerificationListNextObjects;
                case "shareddiagramstyle":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var sharedDiagramStyleUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && sharedDiagramStyleUpperBound == int.MaxValue && !this.SharedDiagramStyle.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<SharedStyle>();
                        }

                        var sentinelSharedStyle = new SharedStyle(Guid.Empty, null, null);

                        return sentinelSharedStyle.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        sharedDiagramStyleUpperBound = this.SharedDiagramStyle.Count - 1;
                    }

                    if (this.SharedDiagramStyle.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for SharedDiagramStyle property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.SharedDiagramStyle.Count - 1 < sharedDiagramStyleUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the SharedDiagramStyle property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.SharedDiagramStyle[pd.Lower.Value];
                        }

                        return this.SharedDiagramStyle[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var sharedDiagramStyleObjects = new List<SharedStyle>();

                        for (var i = pd.Lower.Value; i < sharedDiagramStyleUpperBound + 1; i++)
                        {
                            sharedDiagramStyleObjects.Add(this.SharedDiagramStyle[i]);
                        }

                        return sharedDiagramStyleObjects;
                    }

                    var sharedDiagramStyleNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < sharedDiagramStyleUpperBound + 1; i++)
                    {
                        var queryResult = this.SharedDiagramStyle[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    sharedDiagramStyleNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                sharedDiagramStyleNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return sharedDiagramStyleNextObjects;
                case "sourceiterationiid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.SourceIterationIid;
                case "stakeholder":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var stakeholderUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && stakeholderUpperBound == int.MaxValue && !this.Stakeholder.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Stakeholder>();
                        }

                        var sentinelStakeholder = new Stakeholder(Guid.Empty, null, null);

                        return sentinelStakeholder.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        stakeholderUpperBound = this.Stakeholder.Count - 1;
                    }

                    if (this.Stakeholder.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Stakeholder property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Stakeholder.Count - 1 < stakeholderUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Stakeholder property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Stakeholder[pd.Lower.Value];
                        }

                        return this.Stakeholder[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var stakeholderObjects = new List<Stakeholder>();

                        for (var i = pd.Lower.Value; i < stakeholderUpperBound + 1; i++)
                        {
                            stakeholderObjects.Add(this.Stakeholder[i]);
                        }

                        return stakeholderObjects;
                    }

                    var stakeholderNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < stakeholderUpperBound + 1; i++)
                    {
                        var queryResult = this.Stakeholder[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    stakeholderNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                stakeholderNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return stakeholderNextObjects;
                case "stakeholdervalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var stakeholderValueUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && stakeholderValueUpperBound == int.MaxValue && !this.StakeholderValue.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<StakeholderValue>();
                        }

                        var sentinelStakeholderValue = new StakeholderValue(Guid.Empty, null, null);

                        return sentinelStakeholderValue.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        stakeholderValueUpperBound = this.StakeholderValue.Count - 1;
                    }

                    if (this.StakeholderValue.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for StakeholderValue property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.StakeholderValue.Count - 1 < stakeholderValueUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the StakeholderValue property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.StakeholderValue[pd.Lower.Value];
                        }

                        return this.StakeholderValue[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var stakeholderValueObjects = new List<StakeholderValue>();

                        for (var i = pd.Lower.Value; i < stakeholderValueUpperBound + 1; i++)
                        {
                            stakeholderValueObjects.Add(this.StakeholderValue[i]);
                        }

                        return stakeholderValueObjects;
                    }

                    var stakeholderValueNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < stakeholderValueUpperBound + 1; i++)
                    {
                        var queryResult = this.StakeholderValue[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    stakeholderValueNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                stakeholderValueNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return stakeholderValueNextObjects;
                case "stakeholdervaluemap":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var stakeholderValueMapUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && stakeholderValueMapUpperBound == int.MaxValue && !this.StakeholderValueMap.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<StakeHolderValueMap>();
                        }

                        var sentinelStakeHolderValueMap = new StakeHolderValueMap(Guid.Empty, null, null);

                        return sentinelStakeHolderValueMap.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        stakeholderValueMapUpperBound = this.StakeholderValueMap.Count - 1;
                    }

                    if (this.StakeholderValueMap.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for StakeholderValueMap property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.StakeholderValueMap.Count - 1 < stakeholderValueMapUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the StakeholderValueMap property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.StakeholderValueMap[pd.Lower.Value];
                        }

                        return this.StakeholderValueMap[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var stakeholderValueMapObjects = new List<StakeHolderValueMap>();

                        for (var i = pd.Lower.Value; i < stakeholderValueMapUpperBound + 1; i++)
                        {
                            stakeholderValueMapObjects.Add(this.StakeholderValueMap[i]);
                        }

                        return stakeholderValueMapObjects;
                    }

                    var stakeholderValueMapNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < stakeholderValueMapUpperBound + 1; i++)
                    {
                        var queryResult = this.StakeholderValueMap[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    stakeholderValueMapNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                stakeholderValueMapNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return stakeholderValueMapNextObjects;
                case "topelement":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.TopElement;
                    }

                    if (this.TopElement != null)
                    {
                        return this.TopElement.QueryValue(pd.Next.Input);
                    }

                    var sentineltopelement = new ElementDefinition(Guid.Empty, null, null);
                    return sentineltopelement.QuerySentinelValue(pd.Next.Input, false);
                case "valuegroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var valueGroupUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && valueGroupUpperBound == int.MaxValue && !this.ValueGroup.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ValueGroup>();
                        }

                        var sentinelValueGroup = new ValueGroup(Guid.Empty, null, null);

                        return sentinelValueGroup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        valueGroupUpperBound = this.ValueGroup.Count - 1;
                    }

                    if (this.ValueGroup.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ValueGroup property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ValueGroup.Count - 1 < valueGroupUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ValueGroup property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ValueGroup[pd.Lower.Value];
                        }

                        return this.ValueGroup[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var valueGroupObjects = new List<ValueGroup>();

                        for (var i = pd.Lower.Value; i < valueGroupUpperBound + 1; i++)
                        {
                            valueGroupObjects.Add(this.ValueGroup[i]);
                        }

                        return valueGroupObjects;
                    }

                    var valueGroupNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < valueGroupUpperBound + 1; i++)
                    {
                        var queryResult = this.ValueGroup[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    valueGroupNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                valueGroupNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return valueGroupNextObjects;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }

        /// <summary>
        /// Queries the value of a Sentinel object
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <param name="isCallerEmunerable">
        /// A value indicating whether the result is a single value or an enumeration
        /// </param>
        /// <returns>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof 
        /// </returns>
        internal object QuerySentinelValue(string path, bool isCallerEmunerable)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "revisionnumber":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "classkind":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<ClassKind>() : null;
                case "excludeddomain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "excludedperson":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "modifiedon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "thingpreference":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "actor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Person>() : default(Person);
                case "actualfinitestatelist":
                    return pd.Next == null ? (object) new List<ActualFiniteStateList>() : new ActualFiniteStateList(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "defaultoption":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Option(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Option>() : default(Option);
                case "diagramcanvas":
                    return pd.Next == null ? (object) new List<DiagramCanvas>() : new DiagramCanvas(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "domainfilestore":
                    return pd.Next == null ? (object) new List<DomainFileStore>() : new DomainFileStore(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "element":
                    return pd.Next == null ? (object) new List<ElementDefinition>() : new ElementDefinition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "externalidentifiermap":
                    return pd.Next == null ? (object) new List<ExternalIdentifierMap>() : new ExternalIdentifierMap(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "goal":
                    return pd.Next == null ? (object) new List<Goal>() : new Goal(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "iterationsetup":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new IterationSetup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<IterationSetup>() : default(IterationSetup);
                case "option":
                    return pd.Next == null ? (object) new List<Option>() : new Option(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "possiblefinitestatelist":
                    return pd.Next == null ? (object) new List<PossibleFiniteStateList>() : new PossibleFiniteStateList(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "publication":
                    return pd.Next == null ? (object) new List<Publication>() : new Publication(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "relationship":
                    return pd.Next == null ? (object) new List<BinaryRelationship>() : new BinaryRelationship(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "requirementsspecification":
                    return pd.Next == null ? (object) new List<RequirementsSpecification>() : new RequirementsSpecification(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "ruleverificationlist":
                    return pd.Next == null ? (object) new List<RuleVerificationList>() : new RuleVerificationList(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shareddiagramstyle":
                    return pd.Next == null ? (object) new List<SharedStyle>() : new SharedStyle(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "sourceiterationiid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "stakeholder":
                    return pd.Next == null ? (object) new List<Stakeholder>() : new Stakeholder(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "stakeholdervalue":
                    return pd.Next == null ? (object) new List<StakeholderValue>() : new StakeholderValue(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "stakeholdervaluemap":
                    return pd.Next == null ? (object) new List<StakeHolderValueMap>() : new StakeHolderValueMap(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "topelement":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new ElementDefinition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<ElementDefinition>() : default(ElementDefinition);
                case "valuegroup":
                    return pd.Next == null ? (object) new List<ValueGroup>() : new ValueGroup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
