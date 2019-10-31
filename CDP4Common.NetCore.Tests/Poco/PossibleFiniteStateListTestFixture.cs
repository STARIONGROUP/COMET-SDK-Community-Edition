// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteStateListTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.NetCore.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

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

            Assert.AreEqual(dtoOrderedItemListOriginal[0].K, dtoOrderedItemListClone[0].K);
            Assert.AreEqual(dtoOrderedItemListOriginal[0].V, dtoOrderedItemListClone[0].V);
            Assert.AreEqual(dtoOrderedItemListOriginal[1].K, dtoOrderedItemListClone[1].K);
            Assert.AreEqual(dtoOrderedItemListOriginal[1].V, dtoOrderedItemListClone[1].V);
        }
    }
}
