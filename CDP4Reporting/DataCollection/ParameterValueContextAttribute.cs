// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueContextAttribute.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.DataCollection
{
    using System;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Attribute decorating implementations of <see cref="DataCollectorParameter{TRow,TValue}"/> regarding what values to use in a report datasource
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterValueContextAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the ParameterValueContext of the associated <see cref="DataCollectorParameter{TRow,TValue}"/>.
        /// </summary>
        public ParameterValueContext ParameterValueContext { get; private set; }

        /// <summary>
        /// Gets or sets the ParameterSubscriptionValueContext of the associated <see cref="DataCollectorParameter{TRow,TValue}"/>.
        /// </summary>
        public ParameterValueContext ParameterSubscriptionValueContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueContextAttribute"/> class.
        /// </summary>
        /// <param name="parameterValueContext">
        /// The <see cref="DataCollection.ParameterValueContext"/> to be used on both <see cref="ParameterBase"/> and
        /// <see cref="ParameterSubscription"/> type <see cref="DataCollectorParameter{TRow,TValue}"/>s.
        /// </param>
        public ParameterValueContextAttribute(ParameterValueContext parameterValueContext)
        {
            this.Initialize(parameterValueContext, parameterValueContext);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedThingShortNameAttribute"/> class.
        /// </summary>
        /// <param name="parameterValueContext">
        /// The <see cref="DataCollection.ParameterValueContext"/> to be used on <see cref="ParameterBase"/> type <see cref="DataCollectorParameter{TRow,TValue}"/>s.
        /// </param>
        /// <param name="parameterSubscriptionValueContext">
        /// The <see cref="DataCollection.ParameterValueContext"/> to be used on <see cref="ParameterSubscription"/> type <see cref="DataCollectorParameter{TRow,TValue}"/>s.
        /// </param>
        public ParameterValueContextAttribute(ParameterValueContext parameterValueContext, ParameterValueContext parameterSubscriptionValueContext)
        {
            this.Initialize(parameterValueContext, parameterSubscriptionValueContext);
        }

        /// <summary>
        /// Initializes the <see cref="ParameterValueContextAttribute"/> class.
        /// </summary>
        /// <param name="parameterValueContext">
        /// The <see cref="DataCollection.ParameterValueContext"/> to be used on <see cref="ParameterBase"/> type <see cref="DataCollectorParameter{TRow,TValue}"/>s.
        /// </param>
        /// <param name="parameterSubscriptionValueContext">
        /// The <see cref="DataCollection.ParameterValueContext"/> to be used on <see cref="ParameterSubscription"/> type <see cref="DataCollectorParameter{TRow,TValue}"/>s.
        /// </param>
        private void Initialize(ParameterValueContext parameterValueContext, ParameterValueContext parameterSubscriptionValueContext)
        {
            this.ParameterValueContext = parameterValueContext;
            this.ParameterSubscriptionValueContext = parameterSubscriptionValueContext;
        }
    }
}
