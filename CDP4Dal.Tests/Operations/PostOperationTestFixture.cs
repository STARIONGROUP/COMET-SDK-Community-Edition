// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Dal.Tests
{
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.Dto;
    using CDP4Common.DTO;

    using CDP4DalCommon.Protocol.Operations;

    using NUnit.Framework;

    [TestFixture]
    public class PostOperationTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsLists()
        {
            var testPostOperation = new TestPostOperation();
            Assert.That(testPostOperation.Delete, Is.Not.Null);
            Assert.That(testPostOperation.Create, Is.Not.Null);
            Assert.That(testPostOperation.Update, Is.Not.Null);
            Assert.That(testPostOperation.Copy, Is.Not.Null);           
        }
    }

    internal class TestPostOperation : PostOperation
    {
    }
}
