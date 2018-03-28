#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Test fixture for the <see cref="CDP4Common.CommonData.Thing"/> class
    /// </summary>
    [TestFixture]
    public class ThingTestFixture
    {
        [Test]
        public void VerifyRoutePropertyOfSiteDirectory()
        {
            var siteDirectory = new SiteDirectory();
            Assert.AreEqual("/SiteDirectory/*", siteDirectory.Route);

            var siteDirectoryiid = Guid.NewGuid();
            siteDirectory.Iid = siteDirectoryiid;
            Assert.AreEqual("/SiteDirectory/" + siteDirectoryiid, siteDirectory.Route);
        }

        [Test]
        public void VerifyRouteOfEngineeringModel()
        {
            var engineeringModel = new EngineeringModel();
            Assert.AreEqual("/EngineeringModel/" + Guid.Empty, engineeringModel.Route);

            var engineeringModelIid = Guid.NewGuid();
            engineeringModel.Iid = engineeringModelIid;

            Assert.AreEqual("/EngineeringModel/" + engineeringModelIid, engineeringModel.Route);
        }

        [Test]
        public void VerifyRouteOnNonTopContainerClass()
        {
            var persionIid = new Guid("5F09276B-25A1-4B48-BE0E-B681070D8C64");

            var siteDirectory = new SiteDirectory();

            var person = new Person { Iid = persionIid, Container = siteDirectory };

            Assert.AreEqual("/SiteDirectory/*/person/" + persionIid, person.Route);

            var emailIid = Guid.NewGuid();
            var email = new EmailAddress();
            email.Iid = emailIid;
            email.Container = person;
            person.EmailAddress.Add(email);

            Assert.AreEqual("/SiteDirectory/*/person/" + persionIid + "/emailAddress/" + emailIid, email.Route);
        }

        [Test]        
        public void VerifyThatExceptionIsThrowWhenContainmentNotSet()
        {
            var person = new Person();

            Assert.Throws<ContainmentException>(() =>
            {
                Console.WriteLine(person.Route);    
            });
        }

        [Test]
        public void VerifyTopContainerOfEmailOfPerson()
        {
            var siteDirectory = new SiteDirectory();

            var person = new Person();
            siteDirectory.Person.Add(person);
            person.Container = siteDirectory;

            var email = new EmailAddress();
            person.EmailAddress.Add(email);
            email.Container = person;

            Assert.AreEqual(siteDirectory, email.TopContainer);
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenClassIsTopContainer()
        {
            var siteDirectory = new SiteDirectory();
            var topcontainer = siteDirectory.TopContainer;

            Assert.AreEqual(siteDirectory, topcontainer);
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenContainmentTreeIsBroken()
        {
            var siteDirectory = new SiteDirectory();

            var person = new Person();
            siteDirectory.Person.Add(person);
            siteDirectory.Person[0].Container = null;

            var email = new EmailAddress();
            person.EmailAddress.Add(email);

            Assert.Throws<ContainmentException>(() =>
            {
                var t = email.TopContainer;
            });
        }

        [Test]
        public void VerifyThatConstructorSetsProperties()
        {
            var iid = Guid.NewGuid();
            var revisionNumber = 1;
            var uri = new Uri("http://someuri");
            var cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            var siteDirectory = new SiteDirectory(iid: iid, iDalUri:uri, cache:cache) { RevisionNumber = revisionNumber };

            Assert.AreEqual(iid, siteDirectory.Iid);
            Assert.AreEqual(revisionNumber, siteDirectory.RevisionNumber);
            Assert.AreEqual(uri, siteDirectory.IDalUri);
            Assert.AreEqual(cache, siteDirectory.Cache);
            Assert.AreEqual(ClassKind.SiteDirectory, siteDirectory.ClassKind);
        }

        [Test]
        public void VerifyThatDisposeSetsCacheToNull()
        {
            var iid = Guid.NewGuid();
            var revisionNumber = 1;
            var uri = new Uri("http://someuri");
            var cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            var siteDirectory = new SiteDirectory(iid: iid, iDalUri: uri, cache: cache);
            Assert.IsNotNull(siteDirectory.Cache);
            siteDirectory.Dispose();

            Assert.IsNull(siteDirectory.Cache);
        }

        [Test]
        public void VerifyThatCloneListIsDifferent()
        {
            var testThing = new Person(Guid.NewGuid(), null, null);
            var tel = new TelephoneNumber(Guid.NewGuid(), null, null);
            var email = new EmailAddress(Guid.NewGuid(), null, null);

            testThing.TelephoneNumber.Add(tel);
            testThing.EmailAddress.Add(email);

            var clone = testThing.Clone(false);

            Assert.AreNotSame(testThing.TelephoneNumber, clone.TelephoneNumber);
            Assert.AreEqual(testThing.TelephoneNumber.Count, clone.TelephoneNumber.Count);
        }

        [Test]
        public void VerifyThatCloneListIsDifferent2()
        {
            var testThing = new RequirementsSpecification(Guid.NewGuid(), null, null);
            var req = new Requirement(Guid.NewGuid(), null, null);

            testThing.Requirement.Add(req);

            var clone = testThing.Clone(false);
            Assert.AreNotSame(testThing.Group, clone.Group);
            Assert.AreEqual(testThing.Group.Count, clone.Group.Count);
        }

        [Test]
        public void VerifyThatCloneOrderedItemListIsDifferent()
        {
            var iteration = new Iteration(Guid.NewGuid(), null, null);
            var option = new Option(Guid.NewGuid(), null, null);
            iteration.Option.Add(option);

            var clone = iteration.Clone(false);
            Assert.AreNotSame(iteration.Option, clone.Option);
            Assert.AreEqual(iteration.Option.Count, clone.Option.Count);
        }

        [Test]
        public void VerifyThatClonedThingHasReferenceToOriginal()
        {
            var iteration = new Iteration(Guid.NewGuid(), null, null);
            Assert.IsNull(iteration.Original);

            var clone = iteration.Clone(false);
            
            Assert.AreNotSame(iteration, clone);
            Assert.AreSame(iteration, clone.Original);            
        }

        [Test]
        public void VerifyIsContainedByWorks()
        {
            var model = new EngineeringModel(Guid.NewGuid(), null, null);
            var sitedir = new SiteDirectory(Guid.NewGuid(), null, null);
            var rdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var unit = new DerivedUnit(Guid.NewGuid(), null, null);
            var factor = new UnitFactor(Guid.NewGuid(), null, null);

            sitedir.SiteReferenceDataLibrary.Add(rdl);
            rdl.Unit.Add(unit);
            unit.UnitFactor.Add(factor);

            Assert.IsTrue(factor.IsContainedBy(x => x.Iid == sitedir.Iid));
            Assert.IsTrue(factor.IsContainedBy(x => x.Iid == rdl.Iid));
            Assert.IsTrue(factor.IsContainedBy(x => x.Iid == unit.Iid));
            Assert.IsFalse(factor.IsContainedBy(x => x.Iid == model.Iid));

            Assert.IsFalse(sitedir.IsContainedBy(x => x.Iid == sitedir.Iid));

            Assert.Throws<ArgumentNullException>(() => factor.IsContainedBy(matchPredicate: null));
        }

        [Test]
        public void VerifyThatExceptionIsThrownWhenNoContainerIsProvidedToIsContainedBy()
        {
            SiteDirectory sitedir = null;
            var rdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            Assert.Throws<ArgumentNullException>(() => rdl.IsContainedBy(sitedir));
        }

        [Test]
        public void VerifyIsContainedByIidWorks()
        {
            var model = new EngineeringModel(Guid.NewGuid(), null, null);
            var sitedir = new SiteDirectory(Guid.NewGuid(), null, null);
            var rdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var unit = new DerivedUnit(Guid.NewGuid(), null, null);
            var factor = new UnitFactor(Guid.NewGuid(), null, null);

            sitedir.SiteReferenceDataLibrary.Add(rdl);
            rdl.Unit.Add(unit);
            unit.UnitFactor.Add(factor);

            Assert.IsTrue(factor.IsContainedBy(sitedir.Iid));
            Assert.IsTrue(factor.IsContainedBy(rdl.Iid));
            Assert.IsTrue(factor.IsContainedBy(unit.Iid));
            Assert.IsFalse(factor.IsContainedBy(model.Iid));

            Assert.IsFalse(sitedir.IsContainedBy(sitedir.Iid));

            Assert.Throws<ArgumentNullException>(() => factor.IsContainedBy(iid: Guid.Empty));
        }

        [Test]
        public void VerifyContainedItemReferencesOriginal()
        {
            var person = new Person(Guid.NewGuid(), null, null);
            var phone = new TelephoneNumber(Guid.NewGuid(), null, null);
            person.TelephoneNumber.Add(phone);

            var clone = person.Clone(false);

            Assert.AreSame(phone.Container, person);
            Assert.AreNotSame(phone.Container, clone);

            Assert.IsTrue(person.TelephoneNumber.Contains(phone));
            Assert.IsTrue(clone.TelephoneNumber.Contains(phone));
        }

        [Test]
        public void VerifyThatGetContainerOfTypeWorks()
        {
            var sitedir = new SiteDirectory(Guid.NewGuid(), null, null);
            var siterdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var unit = new DerivedUnit(Guid.NewGuid(), null, null);

            sitedir.SiteReferenceDataLibrary.Add(siterdl);
            siterdl.Unit.Add(unit);

            Assert.AreSame(siterdl, unit.GetContainerOfType(typeof(ReferenceDataLibrary)));
            Assert.AreSame(siterdl, unit.GetContainerOfType(typeof(SiteReferenceDataLibrary)));
            Assert.AreSame(siterdl, unit.GetContainerOfType(typeof(ModelReferenceDataLibrary)));
            Assert.AreSame(sitedir, unit.GetContainerOfType(typeof(SiteDirectory)));
            Assert.IsNull(unit.GetContainerOfType(typeof(Iteration)));

            Assert.AreSame(siterdl, unit.GetContainerOfType<SiteReferenceDataLibrary>());
            Assert.AreSame(sitedir, unit.GetContainerOfType<SiteDirectory>());
            Assert.IsNull(unit.GetContainerOfType<ModelReferenceDataLibrary>());
            Assert.AreSame(siterdl, unit.GetContainerOfType<ReferenceDataLibrary>());

            var requirementsgroup1 = new RequirementsGroup(Guid.NewGuid(), null, null);
            var requirementsgroup2 = new RequirementsGroup(Guid.NewGuid(), null, null);
            requirementsgroup1.Group.Add(requirementsgroup2);

            Assert.AreSame(requirementsgroup1, requirementsgroup2.GetContainerOfType<RequirementsGroup>());
            Assert.AreSame(requirementsgroup1, requirementsgroup2.GetContainerOfType(typeof(RequirementsGroup)));
        }

        [Test]
        public void VerifyThatRouteOfNothingReturnsExpectedString()
        {
            var nothing = new NotThing("nothing");
            Assert.AreEqual("no thing, no route", nothing.Route); 
        }

        [Test]
        public void VerifyThatTopContainerOfNotThingIsNull()
        {
            var nothing = new NotThing("nothing");
            Assert.IsNull(nothing.TopContainer);
        }

        [Test]
        public void VerifyThatContainedThingsDeepReturnsExceptedResult()
        {
            var iteration = new Iteration();
            var elementDefinition1 = new ElementDefinition();
            var elementDefinition2 = new ElementDefinition();
            var alias1 = new Alias();
            var alias2 = new Alias();
            var possibleFiniteStateList1 = new PossibleFiniteStateList();
            var possibleFiniteStateList2 = new PossibleFiniteStateList();
            var possibleFiniteState1_1 = new PossibleFiniteState();
            var possibleFiniteState1_2 = new PossibleFiniteState();
            var possibleFiniteState2_1 = new PossibleFiniteState();
            var possibleFiniteState2_2 = new PossibleFiniteState();
            
            iteration.Element.Add(elementDefinition1);
            iteration.Element.Add(elementDefinition2);

            elementDefinition1.Alias.Add(alias1);
            elementDefinition1.Alias.Add(alias2);

            iteration.PossibleFiniteStateList.Add(possibleFiniteStateList1);
            iteration.PossibleFiniteStateList.Add(possibleFiniteStateList2);

            possibleFiniteStateList1.PossibleState.Add(possibleFiniteState1_1);
            possibleFiniteStateList1.PossibleState.Add(possibleFiniteState1_2);

            possibleFiniteStateList2.PossibleState.Add(possibleFiniteState2_1);
            possibleFiniteStateList2.PossibleState.Add(possibleFiniteState2_2);

            var things = iteration.QueryContainedThingsDeep();

            Assert.AreEqual(11, things.Count());

            CollectionAssert.Contains(things, iteration);
            CollectionAssert.Contains(things, elementDefinition1);
            CollectionAssert.Contains(things, elementDefinition2);
            CollectionAssert.Contains(things, alias1);
            CollectionAssert.Contains(things, alias2);

            CollectionAssert.Contains(things, possibleFiniteStateList1);
            CollectionAssert.Contains(things, possibleFiniteStateList2);
            CollectionAssert.Contains(things, possibleFiniteState1_1);
            CollectionAssert.Contains(things, possibleFiniteState1_2);
            CollectionAssert.Contains(things, possibleFiniteState2_1);
            CollectionAssert.Contains(things, possibleFiniteState2_2);
        }
    }
}
