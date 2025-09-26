// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ReferenceDataLibrary"/>
    /// </summary>
    public abstract partial class ReferenceDataLibrary
    {
        /// <summary>
        /// Gets the chain of required Rdl for this <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>An iterator of the chain of required Rdl</returns>
        public IEnumerable<ReferenceDataLibrary> GetRequiredRdls()
        {
            var requiredRdl = this.RequiredRdl;
            while (requiredRdl != null)
            {
                yield return requiredRdl;
                requiredRdl = requiredRdl.RequiredRdl;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                return this.GetRequiredRdls();
            }
        }

        /// <summary>
        /// Gets the aggragation of all required <see cref="ReferenceDataLibrary"/> including the current one
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> AggregatedReferenceDataLibrary
        {
            get
            {
                yield return this;
                foreach (var rdl in this.GetRequiredRdls())
                {
                    yield return rdl;
                }
            }
        }
        
        /// <summary>
        /// Queries the <see cref="Category"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Category}"/>
        /// </returns>
        public IEnumerable<Category> QueryCategoriesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var category in rdl.DefinedCategory)
                {
                    yield return category;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="Category"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="category">
        /// The subject <see cref="Category"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Category"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// The current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// Equality is determined based on unique identifier (iid) equality.
        /// </remarks>
        public bool IsCategoryInChainOfRdls(Category category)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.DefinedCategory.Any(c => c.Iid == category.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="Category"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Category}"/>
        /// </returns>
        public IEnumerable<ParameterType> QueryParameterTypesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var parameterType in rdl.ParameterType)
                {
                    yield return parameterType;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="ParameterType"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="parameterType">
        /// The subject <see cref="ParameterType"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="ParameterType"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// The current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// Equality is determined based on unique identifier (iid) equality.
        /// </remarks>
        public bool IsParameterTypeInChainOfRdls(ParameterType parameterType)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.ParameterType.Any(f => f.Iid == parameterType.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="MeasurementScale"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{MeasurementScale}"/>
        /// </returns>
        public IEnumerable<MeasurementScale> QueryMeasurementScalesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var measurementScale in rdl.Scale)
                {
                    yield return measurementScale;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="MeasurementScale"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="measurementScale">
        /// The subject <see cref="MeasurementScale"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="MeasurementScale"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// The current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>.
        /// Equality is determined based on unique identifier (iid) equality.
        /// </remarks>
        public bool IsMeasurementScaleInChainOfRdls(MeasurementScale measurementScale)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.Scale.Any(f => f.Iid == measurementScale.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="UnitPrefix"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{UnitPrefix}"/>
        /// </returns>
        public IEnumerable<UnitPrefix> QueryUnitPrefixesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var unitPrefix in rdl.UnitPrefix)
                {
                    yield return unitPrefix;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="UnitPrefix"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="unitPrefix">
        /// The subject <see cref="UnitPrefix"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="UnitPrefix"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// The current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// Equality is determined based on unique identifier (iid) equality.
        /// </remarks>
        public bool IsUnitPrefixInChainOfRdls(UnitPrefix unitPrefix)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.UnitPrefix.Any(u => u.Iid == unitPrefix.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="MeasurementUnit"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{MeasurementUnit}"/>
        /// </returns>
        public IEnumerable<MeasurementUnit> QueryMeasurementUnitsFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var measurementUnit in rdl.Unit)
                {
                    yield return measurementUnit;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="MeasurementUnit"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="measurementUnit">
        /// The subject <see cref="MeasurementUnit"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="MeasurementUnit"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// The current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>.
        /// Equality is determined based on unique identifier (iid) equality.
        /// </remarks>
        public bool IsMeasurementUnitInChainOfRdls(MeasurementUnit measurementUnit)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.Unit.Any(f => f.Iid == measurementUnit.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="FileType"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{FileType}"/>
        /// </returns>
        public IEnumerable<FileType> QueryFileTypesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var fileType in rdl.FileType)
                {
                    yield return fileType;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="FileType"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="fileType">
        /// The subject <see cref="FileType"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="FileType"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// the current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// </remarks>
        public bool IsFileTypeInChainOfRdls(FileType fileType)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.FileType.Any(f => f.Iid == fileType.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="Glossary"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Glossary}"/>
        /// </returns>
        public IEnumerable<Glossary> QueryGlossariesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var glossary in rdl.Glossary)
                {
                    yield return glossary;
                }
            }
        }

        /// <summary>
        /// Queries the <see cref="ReferenceSource"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{ReferenceSource}"/>
        /// </returns>
        public IEnumerable<ReferenceSource> QueryReferenceSourcesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var referenceSource in rdl.ReferenceSource)
                {
                    yield return referenceSource;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="ReferenceSource"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="referenceSource">
        /// The subject <see cref="ReferenceSource"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="ReferenceSource"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// the current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// </remarks>
        public bool IsReferenceSourceInChainOfRdls(ReferenceSource referenceSource)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.ReferenceSource.Any(r => r.Iid == referenceSource.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="Rule"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Rule}"/>
        /// </returns>
        public IEnumerable<Rule> QueryRulesFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var rule in rdl.Rule)
                {
                    yield return rule;
                }
            }
        }

        /// <summary>
        /// Asserts whether a <see cref="Rule"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="rule">
        /// The subject <see cref="Rule"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Rule"/> is on the chain of <see cref="ReferenceDataLibrary"/>, false if not
        /// </returns>
        /// <remarks>
        /// the current <see cref="ReferenceDataLibrary"/> is in included in the chain of <see cref="ReferenceDataLibrary"/>
        /// </remarks>
        public bool IsRuleInChainOfRdls(Rule rule)
        {
            foreach (var referenceDataLibrary in this.AggregatedReferenceDataLibrary)
            {
                if (referenceDataLibrary.Rule.Any(f => f.Iid == rule.Iid))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="Constant"/> from the chain of <see cref="ReferenceDataLibrary"/> including the
        /// current <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Constant}"/>
        /// </returns>
        public IEnumerable<Constant> QueryConstantsFromChainOfRdls()
        {
            var chainOfRdls = this.AggregatedReferenceDataLibrary;

            foreach (var rdl in chainOfRdls)
            {
                foreach (var constant in rdl.Constant)
                {
                    yield return constant;
                }
            }
        }
    }
}