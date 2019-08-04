// <copyright file="AnnotationRuleChecker.cs" company="RHEA System S.A.">
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
    using System.Globalization;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    
    /// <summary>
    /// The purpose of the <see cref="AnnotationRuleChecker"/> is to execute the rules for instances of type <see cref="IAnnotation"/>
    /// </summary>
    [RuleChecker(typeof(IAnnotation))]
    public class AnnotationRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether the specified LanguageCode exists in the SiteDirectory
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/>
        /// </returns>
        [Rule("MA-001", "Checks whether the specified LanguageCode exists in the SiteDirectory", SeverityKind.Warning)]
        public RuleCheckResult CheckWheterTheLanguageCodeExistsInTheSiteDirectory(Thing thing)
        {
            var annotation = thing as IAnnotation;
            if (annotation == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an IAnnotation");
            }

            var topContainer = thing.TopContainer;

            SiteDirectory siteDirectory;

            var engineeringModel = topContainer as EngineeringModel;
            if (engineeringModel != null)
            {
                siteDirectory = engineeringModel.EngineeringModelSetup.TopContainer as SiteDirectory;
            }
            else
            {
                siteDirectory = topContainer as SiteDirectory;
            }

            if (siteDirectory != null)
            {
                var languageCodeExists = siteDirectory.NaturalLanguage.Any(x => x.LanguageCode == annotation.LanguageCode);
                if (!languageCodeExists)
                {
                    return new RuleCheckResult(thing, "MA-001", $"The Annotation.LanguageCode: {annotation.LanguageCode} for Idd: {thing.Iid} does not exist in the SiteDirectory { siteDirectory.Iid}", SeverityKind.Warning);
                }
                else
                {
                    return null;
                }
            }

            throw new Exception("MA-001 could not be checked");
        }

        /// <summary>
        /// Checks whether the specified LanguageCode is a valid LanguageCode as specified in ISO 639-1 part 1 or part 2
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/>
        /// </returns>
        [Rule("MA-002", "Checks whether the specified LanguageCode is a valid LanguageCode as specified in ISO 639-1 part 1 or part 2", SeverityKind.Warning)]
        public RuleCheckResult CheckWeatherTheLanguageCodeIsValid(Thing thing)
        {
            var annotation = thing as IAnnotation;
            if (annotation == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an IAnnotation");
            }
            
            if (CultureInfo.GetCultures(CultureTypes.AllCultures).All(x => x.Name != annotation.LanguageCode))
            {
                return new RuleCheckResult(thing, "MA-003", $"The Annotation.LanguageCode: {annotation.LanguageCode} for Idd: {thing.Iid} is not a valid LanguageCode", SeverityKind.Warning);
            }
            else
            {
                return null;
            }

            throw new Exception("MA-002 could not be checked");
        }
    }
}