// <copyright file="Rule.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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
    using System;
    using System.Xml.Serialization;
    using CDP4Rules.Common;

    /// <summary>
    /// Represents a model analysis rule that can be (de)serialized to and from XML
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "Rule")]
    public class Rule : IRule
    {
        /// <summary>
        /// Gets or sets the unique human readable identifier
        /// </summary>
        [XmlElement("ID")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the human readable description of the intent of the <see cref="Rule"/>
        /// </summary>
        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SeverityKind"/>
        /// </summary>
        [XmlElement("SEVERITY")]
        public SeverityKind Severity { get; set; }

        /// <summary>
        /// Gets or sets the human readable notes that provide extra information regarding the <see cref="Rule"/>
        /// </summary>
        [XmlElement("NOTES")]
        public string Notes { get; set; }
    }
}