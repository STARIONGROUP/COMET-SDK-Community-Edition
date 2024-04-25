// <copyright file="QuantityKindRuleChecker.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2021 Starion Group S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.RuleCheckers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="QuantityKindRuleChecker"/> is to execute the rules for instances of type <see cref="QuantityKind"/>
    /// </summary>
    [RuleChecker(typeof(QuantityKind))]
    public class QuantityKindRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="QuantityKind"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="QuantityKind"/>
        /// </exception>
        [Rule("MA-0750")]
        public IEnumerable<RuleCheckResult> ChecksWhetherReferencedDefaultScaleIsInTheCollectionOfPossibleScales(Thing thing)
        {
            var quantityKind = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (quantityKind.PossibleScale.All(s => s.Iid != quantityKind.DefaultScale.Iid))
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The QuantityKind.DefaultScale {quantityKind.DefaultScale.Iid}:{quantityKind.DefaultScale.ShortName} is not in the list of QuantityKind.PossibleScale",
                    SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="QuantityKind"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="QuantityKind"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var quantityKind = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (quantityKind.IsDeprecated)
            {
                return results;
            }

            foreach (var measurementScale in quantityKind.PossibleScale)
            {
                if (measurementScale.IsDeprecated)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"The referenced MeasurementScale {measurementScale.Iid}:{measurementScale.ShortName} in QuantityKind.PossibleScale is deprecated",
                        SeverityKind.Warning);
                    results.Add(result);
                }
            }

            if (quantityKind.DefaultScale.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced MeasurementScale {quantityKind.DefaultScale.Iid}:{quantityKind.DefaultScale.ShortName} of QuantityKind.DefaultScale is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="MeasurementScale"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="QuantityKind"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="QuantityKind"/>
        /// </exception>
        [Rule("MA-0230")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedMeasurementScaleInChainOfRdls(Thing thing)
        {
            var quantityKind = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)thing.GetContainerOfType(typeof(ReferenceDataLibrary));

            foreach (var measurementScale in quantityKind.PossibleScale)
            {
                if (!referenceDataLibrary.IsMeasurementScaleInChainOfRdls(measurementScale))
                {
                    var result = new RuleCheckResult(thing, rule.Id, $"The referenced MeasurementScale {measurementScale.Iid}:{measurementScale.ShortName} in QuantityKind.PossibleScale is not in the chain of Reference Data Libraries", SeverityKind.Error);
                    results.Add(result);
                }
            }

            if (!referenceDataLibrary.IsMeasurementScaleInChainOfRdls(quantityKind.DefaultScale))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The referenced MeasurementScale {quantityKind.DefaultScale.Iid}:{quantityKind.DefaultScale.ShortName} in QuantityKind.DefaultScale is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Verifies that the <see cref="Thing"/> is of the correct type
        /// </summary>
        /// <param name="thing">
        /// the subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="QuantityKind"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="QuantityKind"/>
        /// </exception>
        private QuantityKind VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var quantityKind = thing as QuantityKind;
            if (quantityKind == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an QuantityKind", nameof(thing));
            }

            return quantityKind;
        }
    }
}