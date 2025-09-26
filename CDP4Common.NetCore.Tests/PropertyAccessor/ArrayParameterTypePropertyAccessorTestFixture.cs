// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterTypePropertyAccessorTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.PropertyAccessor
{
    using System.Collections.Generic;

    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class ArrayParameterTypePropertyAccessorTestFixture
    {
        // Case for collection of int
        [Test]
        public void VerifyArrayParameterTypePropertyAccessorSetValueForDimension()
        {
            var arrayParameterType = new ArrayParameterType();
            const string dimensionName = nameof(ArrayParameterType.Dimension);

            Assert.That(arrayParameterType.Dimension, Is.Empty);

            arrayParameterType.SetValue(dimensionName, 1);

            Assert.Multiple(() =>
            {
                Assert.That(arrayParameterType.Dimension, Has.Count.EqualTo(1));
                Assert.That(arrayParameterType.Dimension[0], Is.EqualTo(1));
            });

            arrayParameterType.SetValue(dimensionName, "2");

            Assert.Multiple(() =>
            {
                Assert.That(arrayParameterType.Dimension, Has.Count.EqualTo(1));
                Assert.That(arrayParameterType.Dimension[0], Is.EqualTo(2));
            });

            arrayParameterType.SetValue(dimensionName, new List<int>{3,4});

            Assert.Multiple(() =>
            {
                Assert.That(arrayParameterType.Dimension, Has.Count.EqualTo(2));
                Assert.That(arrayParameterType.Dimension, Is.EquivalentTo(new List<int>{3,4}));
            });

            arrayParameterType.SetValue(dimensionName, new List<string>{"5","6"});

            Assert.Multiple(() =>
            {
                Assert.That(arrayParameterType.Dimension, Has.Count.EqualTo(2));
                Assert.That(arrayParameterType.Dimension, Is.EquivalentTo(new List<int>{5,6}));
            });

            arrayParameterType.SetValue(dimensionName, null);

            Assert.Multiple(() =>
            {
                Assert.That(arrayParameterType.Dimension, Is.Empty);
                Assert.That(() => arrayParameterType.SetValue(dimensionName, "1a"), Throws.ArgumentException);
                Assert.That(() => arrayParameterType.SetValue(dimensionName, new List<string>{ "45", "2c"}), Throws.ArgumentException);
                Assert.That(() => arrayParameterType.SetValue(dimensionName, false), Throws.ArgumentException);
            });
        }
    }
}
