﻿// <copyright file="RuleXmlReader.cs" company="RHEA System S.A.">
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

namespace CDP4Rules.Serialization
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="RuleXmlReader"/> is to read the
    /// defined rules from the embedded rules xml file 
    /// </summary>
    internal class RuleXmlReader
    {
        /// <summary>
        /// Deserialize the <see cref="IRule"/>s from the rules resource
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<IRule> Deserialize()
        {
            using (var stream = this.GetType().Assembly.GetManifestResourceStream("CDP4Rules.Resources.rules.xml"))
            {
                var serializer = new XmlSerializer(typeof(RuleDefinition));

                var modelAnalysis = (RuleDefinition) serializer.Deserialize(stream);

                return modelAnalysis.Rules;
            }
        }
    }
}