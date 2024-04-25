#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriQueryAttributeTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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

namespace CDP4WspDal.Tests
{
    using CDP4Dal.DAL.ECSS1025AnnexC;

    using NUnit.Framework;

    [TestFixture]
    public class UriQueryAttributeTestFixture
    {
        private QueryAttributes attributes;

        [SetUp]
        public void Setup()
        {
            this.attributes = new QueryAttributes();;
        }

        [Test]
        public void TestToString()
        {
            this.attributes.Extent = ExtentQueryAttribute.deep;
            this.attributes.IncludeAllContainers = true;
            this.attributes.IncludeFileData = true;
            this.attributes.IncludeReferenceData = true;
            this.attributes.RevisionNumber = 2;

            var test = this.attributes.ToString();
            Assert.IsTrue(test.Contains("extent"));
            Assert.IsTrue(test.Contains("includeReferenceData"));
            Assert.IsTrue(test.Contains("includeAllContainers"));
            Assert.IsTrue(test.Contains("includeFileData"));
            Assert.IsTrue(test.Contains("revisionNumber"));
        }

        [Test]
        public void TestEmptyAttributeToString()
        {
            var str = this.attributes.ToString();
            Assert.AreEqual(string.Empty, str);
        }
    }
}
