// <copyright file="ParameterTypeComponentRuleChecker.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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
    /// The purpose of the <see cref="ParameterTypeComponentRuleChecker"/> is to execute the rules for instances of type <see cref="ParameterTypeComponent"/>
    /// </summary>
    [RuleChecker(typeof(ParameterTypeComponent))]
    public class ParameterTypeComponentRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether the referenced <see cref="MeasurementScale"/> is valid
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterTypeComponent"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterTypeComponent"/>
        /// </exception>
        [Rule("MA-0740")]
        public IEnumerable<RuleCheckResult> ChecksWhetherTheParameterTypeComponentHasAValidScale(Thing thing)
        {
            var parameterTypeComponent = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            QuantityKind quantityKind = null;

            if (parameterTypeComponent.Scale != null)
            {
                quantityKind = parameterTypeComponent.ParameterType as QuantityKind;
                if (quantityKind == null)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"When the referenced ParameterType is a not QuantityKind, the ParameterTypeComponent.Scale must be null",
                        SeverityKind.Error);
                    results.Add(result);
                }
            }

            quantityKind = parameterTypeComponent.ParameterType as QuantityKind;
            if (quantityKind != null)
            {
                if (parameterTypeComponent.Scale == null)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"When the referenced ParameterType is a QuantityKind, the ParameterTypeComponent.Scale may not be null",
                        SeverityKind.Error);
                    results.Add(result);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterTypeComponent"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterTypeComponent"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var parameterTypeComponent = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var compoundParameterType = (CompoundParameterType)parameterTypeComponent.Container;

            if (compoundParameterType.IsDeprecated)
            {
                return results;
            }

            if (parameterTypeComponent.Scale != null && parameterTypeComponent.Scale.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced MeasurementScale {parameterTypeComponent.Scale.Iid}:{parameterTypeComponent.Scale.ShortName} of ParameterTypeComponent.Scale is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            if (parameterTypeComponent.ParameterType.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced ParameterType {parameterTypeComponent.ParameterType.Iid}:{parameterTypeComponent.ParameterType.ShortName} of ParameterTypeComponent.ParameterType is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="ParameterType"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterTypeComponent"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterTypeComponent"/>
        /// </exception>
        [Rule("MA-0220")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedParameterTypeIsInChainOfRdls(Thing thing)
        {
            var parameterTypeComponent = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)thing.GetContainerOfType(typeof(ReferenceDataLibrary));

            if (!referenceDataLibrary.IsParameterTypeInChainOfRdls(parameterTypeComponent.ParameterType))
            {
                var result = new RuleCheckResult(thing, rule.Id, "The referenced ParameterType is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="MeasurementScale"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterTypeComponent"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterTypeComponent"/>
        /// </exception>
        [Rule("MA-0230")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedMeasurementScaleInChainOfRdls(Thing thing)
        {
            var parameterTypeComponent = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)thing.GetContainerOfType(typeof(ReferenceDataLibrary));

            if (!referenceDataLibrary.IsMeasurementScaleInChainOfRdls(parameterTypeComponent.Scale))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The referenced MeasurementScale {parameterTypeComponent.Scale.Iid}:{parameterTypeComponent.Scale.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
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
        /// an instance of <see cref="ParameterTypeComponent"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterTypeComponent"/>
        /// </exception>
        private ParameterTypeComponent VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var parameterTypeComponent = thing as ParameterTypeComponent;
            if (parameterTypeComponent == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ParameterTypeComponent", nameof(thing));
            }

            return parameterTypeComponent;
        }
    }
}