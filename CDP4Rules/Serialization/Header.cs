// <copyright file="Header.cs" company="Starion Group S.A.">
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

    /// <summary>
    /// The <see cref="Header"/> class holds metadata relevant to a <see cref="RuleDefinition"/> Document.
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "HEADER")]
    public class Header
    {
        /// <summary>
        /// Gets or sets the title of the <see cref="RuleDefinition"/> Document.
        /// </summary>
        [XmlElement("TITLE")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets an optional comment associated with the <see cref="RuleDefinition"/> Document as a whole
        /// </summary>
        [XmlElement("COMMENT")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the time of creation of the <see cref="RuleDefinition"/> XML document.
        /// </summary>
        /// <remarks>
        /// the format of the XML Schema data type “dateTime” which specifies the time format as <code>CCYY-MM-DDThh:mm:ss</code> with optional time zone indicator as a suffix <code>±hh:mm</code>.
        /// </remarks>
        /// <example>
        /// Example: 2005-03-04T10:24:18+01:00 (MET time zone).
        /// </example>
        [XmlElement("CREATION-TIME")]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the importing/exporting <see cref="RuleDefinition"/> tool.
        /// </summary>
        [XmlElement("E-TM-10-25-TOOL")]
        public string Tool { get; set; }
    }
}