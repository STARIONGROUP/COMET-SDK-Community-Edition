// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionVerificationChangedEvent.cs" company="RHEA System S.A.">
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

namespace CDP4Requirements
{
    /// <summary>
    /// The purpose of the <see cref="BooleanExpressionVerificationChangedEvent"/> is to notify an observer
    /// that the referenced <see cref="IBooleanExpressionVerifier"/> has changed in some way and what that change is.
    /// </summary>
    public class BooleanExpressionVerificationChangedEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanExpressionVerificationChangedEvent"/> class.
        /// </summary>
        /// <param name="booleanExpressionVerifier">
        /// The payload <see cref="IBooleanExpressionVerifier"/>.
        /// </param>
        public BooleanExpressionVerificationChangedEvent(IBooleanExpressionVerifier booleanExpressionVerifier)
        {
            this.Verifier = booleanExpressionVerifier;
        }

        /// <summary>
        /// Gets or sets the changed <see cref="IBooleanExpressionVerifier"/>
        /// </summary>
        public IBooleanExpressionVerifier Verifier { get; }
    }
}
