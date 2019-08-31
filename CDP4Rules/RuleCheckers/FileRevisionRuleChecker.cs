// <copyright file="FileRevisionRuleChecker.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileRevisionRuleChecker"/> is to execute the rules for instances of type <see cref="FileRevision"/>
    /// </summary>
    [RuleChecker(typeof(FileRevision))]
    public class FileRevisionRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Publication"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Publication"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var fileRevision = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            foreach (FileType fileType in fileRevision.FileType)
            {
                if (fileType.IsDeprecated)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"The referenced FileType {fileType.Iid}:{fileType.ShortName} in FileRevision.FileType is deprecated",
                        SeverityKind.Warning);
                    results.Add(result);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks whether the referenced <see cref="FileType"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="FileRevision"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="FileRevision"/>
        /// </exception>
        [Rule("MA-0210")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedFileTypeIsInChainOfRlds(Thing thing)
        {
            var fileRevision = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var engineeringModel = thing.TopContainer as EngineeringModel;

            var modelReferenceDataLibrary = engineeringModel.EngineeringModelSetup.RequiredRdl.Single();

            foreach (FileType fileType in fileRevision.FileType)
            {
                if (!modelReferenceDataLibrary.IsFileTypeInChainOfRdls(fileType))
                {
                    var result = new RuleCheckResult(thing, rule.Id, "The referenced FileType of the FileRevision is not in the chain of Reference Data Libraries", SeverityKind.Error);
                    results.Add(result);
                }
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
        /// an instance of <see cref="FileRevision"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="FileRevision"/>
        /// </exception>
        private FileRevision VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null");
            }

            var fileRevision = thing as FileRevision;
            if (fileRevision == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not a FileRevision");
            }

            return fileRevision;
        }
    }
}