// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BeforeWriteEventArgsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
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

namespace CDP4Dal.NetCore.Tests
{
    using CDP4Dal.Events;
    using CDP4Dal.Operations;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BeforeWriteEventArgs"/> class
    /// </summary>
    [TestFixture]
    public class BeforeWriteEventArgsTestFixture
    {
        private OperationContainer operationContainer1;

        private OperationContainer operationContainer2;

        private string[] files;

        private string context;

        [SetUp]
        public void SetUp()
        {
            this.context = "/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d";
            this.operationContainer1 = new OperationContainer(this.context, 0);
            this.operationContainer2 = new OperationContainer(this.context, 0);
            this.files = new[] { "File.txt", "File2.txt" };
        }

        [Test]
        public void VerifythatPropertiesAreSet()
        {
            var eventArgs1 = new BeforeWriteEventArgs(this.operationContainer1, null);

            Assert.That(this.operationContainer1, Is.EqualTo(eventArgs1.OperationContainer));
            Assert.That(eventArgs1.Files, Is.Null);

            var eventArgs2 = new BeforeWriteEventArgs(this.operationContainer2, this.files);
            Assert.That(this.operationContainer2, Is.EqualTo(eventArgs2.OperationContainer));
            Assert.That(this.files, Is.EqualTo(eventArgs2.Files));
        }
    }
}
