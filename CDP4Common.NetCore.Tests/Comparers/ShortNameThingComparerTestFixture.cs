#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortNameThingComparerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
#endregion

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ShortNameThingComparer"/> class
    /// </summary>
    [TestFixture]
    public class ShortNameThingComparerTestFixture
    {
        private DomainOfExpertise domainOfExpertise_1;
        private DomainOfExpertise domainOfExpertise_2;
        private ShortNameThingComparer comparer;

        [SetUp]
        public void SetUp()
        {
            this.comparer = new ShortNameThingComparer();

            this.domainOfExpertise_1 = new DomainOfExpertise();
            this.domainOfExpertise_2 = new DomainOfExpertise();
        }

        [Test]
        public void VerifyThatCompareIsCaseInsensitive()
        {
            this.domainOfExpertise_1.ShortName = "a";
            this.domainOfExpertise_2.ShortName = "A";
            
            Assert.AreEqual(0, this.comparer.Compare(this.domainOfExpertise_1, this.domainOfExpertise_2));            
        }
    }
}
