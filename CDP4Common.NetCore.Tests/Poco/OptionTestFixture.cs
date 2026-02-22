// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Tests.Helpers;

    using NUnit.Framework;

    [TestFixture]
    internal class OptionTestFixture
    {
        [Test]
        public void VerifyThatIsDefaultWorks()
        {
            var iteration = new Iteration();
            var option1 = new Option();
            var option2 = new Option();

            iteration.Option.Add(option1);
            iteration.Option.Add(option2);
            iteration.DefaultOption = option1;

            Assert.That(option1.IsDefault, Is.True);
            Assert.That(option2.IsDefault, Is.False);
        }
    }
}
