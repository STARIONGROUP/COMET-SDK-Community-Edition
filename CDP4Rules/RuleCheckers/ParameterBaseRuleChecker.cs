// <copyright file="ParameterBaseRuleChecker.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="ParameterBaseRuleChecker"/> is to execute the rules for instances of type <see cref="ParameterBase"/>
    /// </summary>
    [RuleChecker(typeof(ParameterBase))]
    public class ParameterBaseRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="CompoundParameterType"/> is not finalized
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterBase"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterBase"/>
        /// </exception>
        [Rule("MA-0520")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedCompoundParameterTypeIsFinalizedOrNot(Thing thing)
        {
            var parameter = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var compoundParameterType = parameter.ParameterType as CompoundParameterType;
            if (compoundParameterType != null && !compoundParameterType.IsFinalized)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced CompoundParameterType {parameter.ParameterType.Iid}:{parameter.ParameterType.ShortName} of Parameter.ParameterType is not finalized",
                    SeverityKind.Warning);
                results.Add(result);
            }

            return results;
        }
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Constant"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Constant"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var parameterBase = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (parameterBase.Scale != null && parameterBase.Scale.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced MeasurementScale {parameterBase.Scale.Iid}:{parameterBase.Scale.ShortName} of ParameterBase.Scale is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            if (parameterBase.ParameterType.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced ParameterType {parameterBase.ParameterType.Iid}:{parameterBase.ParameterType.ShortName} of ParameterBase.ParameterType is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="ParameterType"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterBase"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterBase"/>
        /// </exception>
        [Rule("MA-0220")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedParameterTypeIsInChainOfRdls(Thing thing)
        {
            var parameterBase = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var engineeringModel = thing.TopContainer as EngineeringModel;

            var modelReferenceDataLibrary = engineeringModel.EngineeringModelSetup.RequiredRdl.Single();

            if (!modelReferenceDataLibrary.IsParameterTypeInChainOfRdls(parameterBase.ParameterType))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The referenced ParameterType {parameterBase.ParameterType.Iid}:{parameterBase.ParameterType.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="MeasurementScale"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterBase"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterBase"/>
        /// </exception>
        [Rule("MA-0230")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedMeasurementScaleInChainOfRdls(Thing thing)
        {
            var parameterBase = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var engineeringModel = thing.TopContainer as EngineeringModel;

            var modelReferenceDataLibrary = engineeringModel.EngineeringModelSetup.RequiredRdl.Single();

            if (!modelReferenceDataLibrary.IsMeasurementScaleInChainOfRdls(parameterBase.Scale))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The referenced MeasurementScale {parameterBase.Scale.Iid}:{parameterBase.Scale.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
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
        /// an instance of <see cref="ParameterBase"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterBase"/>
        /// </exception>
        private ParameterBase VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null");
            }

            var parameterBase = thing as ParameterBase;
            if (parameterBase == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ParameterBase");
            }

            return parameterBase;
        }
    }
}