// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpStatusCodeExtensionsTestFixtures.cs" company="Starion Group S.A.">
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

namespace CDP4Web.Tests.Extensions
{
    using System.Collections.Generic;
    using System.Net;

    using CDP4Web.Extensions;

    using NUnit.Framework;

    [TestFixture]
    public class HttpStatusCodeExtensionsTestFixtures
    {
        [Test]
        public void VerifyHttpStatusCodeKind()
        {
            Assert.Multiple(() =>
            {
                Assert.That(HttpStatusCode.Accepted.IsSuccess(), Is.True);
                Assert.That(HttpStatusCode.Accepted.IsClientError(), Is.False);
                Assert.That(HttpStatusCode.Accepted.IsServerError(), Is.False);
                Assert.That(HttpStatusCode.Unauthorized.IsSuccess(), Is.False);
                Assert.That(HttpStatusCode.Unauthorized.IsClientError(), Is.True);
                Assert.That(HttpStatusCode.Unauthorized.IsServerError(), Is.False);
                Assert.That(HttpStatusCode.NotImplemented.IsSuccess(), Is.False);
                Assert.That(HttpStatusCode.NotImplemented.IsClientError(), Is.False);
                Assert.That(HttpStatusCode.NotImplemented.IsServerError(), Is.True);
            });
        }

        [Test]
        public void VerifyHttpStatusCodeOrdering()
        {
            var httpStatusCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.Unauthorized,
                HttpStatusCode.Accepted,
                HttpStatusCode.AlreadyReported,
                HttpStatusCode.InsufficientStorage
            };

            Assert.That(httpStatusCodes.OrderByStatusCodeCategory(), Is.EquivalentTo(new List<HttpStatusCode>()
            {
                HttpStatusCode.InsufficientStorage,
                HttpStatusCode.Unauthorized,
                HttpStatusCode.Accepted,
                HttpStatusCode.AlreadyReported
            }));
        }
    }
}
