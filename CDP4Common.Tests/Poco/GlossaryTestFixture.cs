#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlossaryTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="Glossary"/> class.
    /// </summary>
    [TestFixture]
    public class GlossaryTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();
        }

        [Test]
        public void VerifyThatGetRequiredRdlsReturnsExpectedResults()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl1_1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);

            var glossary = new Glossary(Guid.NewGuid(), this.cache, this.uri);

            srdl1_1.RequiredRdl = srdl1;
            mrdl.RequiredRdl = srdl1_1;
            srdl2.RequiredRdl = srdl1;

            mrdl.Glossary.Add(glossary);

            var requiredRdls = glossary.RequiredRdls.ToList();

            Assert.IsTrue(requiredRdls.Contains(mrdl));
            Assert.IsTrue(requiredRdls.Contains(srdl1_1));
            Assert.IsTrue(requiredRdls.Contains(srdl1));

            Assert.IsFalse(requiredRdls.Contains(srdl2));
        }
    }
}
