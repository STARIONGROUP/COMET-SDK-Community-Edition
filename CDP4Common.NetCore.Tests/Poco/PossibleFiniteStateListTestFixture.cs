// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteStateListTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.NetCore.Tests.Poco
{
    using System;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    class PossibleFiniteStateListTestFixture
    {
        [Test]
        public void OrderedItemListIsClonedCorrectlyTest()
        {
            var pfs1 = new PossibleFiniteState(Guid.NewGuid(), null, null);
            pfs1.Name = "state1";
            pfs1.ShortName = "s1";

            var pfs2 = new PossibleFiniteState(Guid.NewGuid(), null, null);
            pfs2.Name = "state1";
            pfs2.ShortName = "s1";

            var pfsList = new PossibleFiniteStateList(Guid.NewGuid(), null, null);
            pfsList.Name = "PossibleFiniteStateList1";
            pfsList.ShortName = "PFSL1";

            pfsList.PossibleState.Add(pfs1);
            pfsList.PossibleState.Add(pfs2);

            var dtoOrderedItemListOriginal = pfsList.PossibleState.ToDtoOrderedItemList().ToList();

            var pfsListClone = pfsList.Clone(true);
            var dtoOrderedItemListClone = pfsListClone.PossibleState.ToDtoOrderedItemList().ToList();

            Assert.That(dtoOrderedItemListClone[0].K, Is.EqualTo(dtoOrderedItemListOriginal[0].K));
            Assert.That(dtoOrderedItemListClone[0].V, Is.EqualTo(dtoOrderedItemListOriginal[0].V));
            Assert.That(dtoOrderedItemListClone[1].K, Is.EqualTo(dtoOrderedItemListOriginal[1].K));
            Assert.That(dtoOrderedItemListClone[1].V, Is.EqualTo(dtoOrderedItemListOriginal[1].V));
        }
    }
}
