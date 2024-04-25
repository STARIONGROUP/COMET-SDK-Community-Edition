// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidComparer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Common.Tests.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Comparers;
    using NUnit.Framework;

    [TestFixture]
    public class GuidComparerTestFixture
    {
        [Test]
        public void Verify_that_List_of_Guid_is_ordered()
        {
            var id_1 = Guid.Parse("622d8e0f-ed5e-4dde-92b8-97ff06e69110");
            var id_2 = Guid.Parse("90e43d0c-edf8-4630-963b-90e6530ac9db");
            var id_3 = Guid.Parse("47b3abc1-ce06-40ef-8ea6-466e7eaccccd");

            Assert.That(-1, Is.EqualTo(id_1.CompareTo(id_2)));

            var ids = new List<Guid> { id_1, id_2, id_3 };
            var ordered = new List<Guid> { id_3, id_1, id_2 };

            var result = ids.OrderBy(x => x, new GuidComparer());

            CollectionAssert.AreEqual(ordered, result);
        }
    }
}