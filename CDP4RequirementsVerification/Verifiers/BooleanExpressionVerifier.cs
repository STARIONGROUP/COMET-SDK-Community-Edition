// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionVerifier.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4RequirementsVerification.Verifiers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4RequirementsVerification.Events;

    /// <summary>
    /// Base class for the verification if a <see cref="BooleanExpression"/> is compliant to data in an <see cref="Iteration"/>  
    /// </summary>
    /// <typeparam name="T">The type of <see cref="BooleanExpression"/> that is used for this verifier.</typeparam>
    public abstract class BooleanExpressionVerifier<T> : IBooleanExpressionVerifier where T : BooleanExpression
    {
        /// <summary>
        /// Backing field for <see cref="RequirementStateOfCompliance"/>
        /// </summary>
        private RequirementStateOfCompliance requirementStateOfCompliance;

        /// <summary>
        /// The <see cref="BooleanExpression"/> that is used for the verification process
        /// </summary>
        public T Expression { get; protected set; }

        /// <summary>
        /// Indication that the CDPMessageBus can be used.
        /// </summary>
        protected bool IsMessageBusActive { get; set; } = true;

        /// <summary>
        /// The current <see cref="CDP4RequirementsVerification.RequirementStateOfCompliance"/>>
        /// </summary>
        public RequirementStateOfCompliance RequirementStateOfCompliance
        {
            get => this.requirementStateOfCompliance;
            protected set
            {
                if (this.requirementStateOfCompliance != value)
                {
                    this.requirementStateOfCompliance = value;

                    if (this.IsMessageBusActive)
                    {
                        CDPMessageBus.Current.SendMessage(new RequirementStateOfComplianceChangedEvent(value), this.Expression);
                    }
                }
            }
        }

        /// <summary>
        /// Verify a <see cref="BooleanExpression"/> with respect to a <see cref="Requirement"/> using data from a given <see cref="Iteration"/> 
        /// </summary>
        /// <param name="booleanExpressionVerifiers">A dictionary that contains all <see cref="BooleanExpression"/>s and their <see cref="BooleanExpressionVerifier{T}"/>s</param>
        /// <param name="iteration">The <see cref="Iteration"/> that contains the data (<see cref="ElementDefinition"/> and <see cref="ElementUsage"/>) used for verification</param>
        /// <returns><see cref="Task"/> that returns the calculated <see cref="RequirementStateOfCompliance"/> for this class' <see cref="BooleanExpressionVerifier{T}.Expression"/> property</returns>
        public abstract Task<RequirementStateOfCompliance> VerifyRequirementStateOfCompliance(IDictionary<BooleanExpression, IBooleanExpressionVerifier> booleanExpressionVerifiers, Iteration iteration);
    }
}
