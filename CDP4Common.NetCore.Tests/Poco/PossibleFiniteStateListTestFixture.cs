using CDP4Common.EngineeringModelData;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CDP4Common.NetCore.Tests.Poco
{
    class PossibleFiniteStateListTestFixture
    {
        [Test]
        public void OrderedItemListIsNotClonedCorrectlyTest()
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

            Assert.AreNotEqual(dtoOrderedItemListOriginal[0].K, dtoOrderedItemListClone[0].K);
            Assert.AreEqual(dtoOrderedItemListOriginal[0].V, dtoOrderedItemListClone[0].V);
            Assert.AreNotEqual(dtoOrderedItemListOriginal[1].K, dtoOrderedItemListClone[1].K);
            Assert.AreEqual(dtoOrderedItemListOriginal[1].V, dtoOrderedItemListClone[1].V);
        }
    }
}
