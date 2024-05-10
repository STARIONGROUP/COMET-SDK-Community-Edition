// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTestFixture.cs" company="Starion Group S.A.">
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
            Assert.That(siteDirectory.Route, Is.EqualTo("/SiteDirectory/*"));

            var siteDirectoryiid = Guid.NewGuid();
            siteDirectory.Iid = siteDirectoryiid;
            Assert.That(siteDirectory.Route, Is.EqualTo("/SiteDirectory/" + siteDirectoryiid));
        }

        [Test]
        public void VerifyRouteOfEngineeringModel()
        {
            var engineeringModel = new EngineeringModel();
            Assert.That(engineeringModel.Route, Is.EqualTo("/EngineeringModel/" + Guid.Empty));

            var engineeringModelIid = Guid.NewGuid();
            engineeringModel.Iid = engineeringModelIid;

            Assert.That(engineeringModel.Route, Is.EqualTo("/EngineeringModel/" + engineeringModelIid));
        }

        [Test]
        public void VerifyRouteOnNonTopContainerClass()
        {
            var persionIid = new Guid("5F09276B-25A1-4B48-BE0E-B681070D8C64");

            var siteDirectory = new SiteDirectory();

            var person = new Person { Iid = persionIid, Container = siteDirectory };

            Assert.That(person.Route, Is.EqualTo("/SiteDirectory/*/person/" + persionIid));

            var emailIid = Guid.NewGuid();
            var email = new EmailAddress();
            email.Iid = emailIid;
            email.Container = person;
            person.EmailAddress.Add(email);

            Assert.That(email.Route, Is.EqualTo("/SiteDirectory/*/person/" + persionIid + "/emailAddress/" + emailIid));
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

            Assert.That(email.TopContainer, Is.EqualTo(siteDirectory));
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenClassIsTopContainer()
        {
            var siteDirectory = new SiteDirectory();
            var topcontainer = siteDirectory.TopContainer;

            Assert.That(topcontainer, Is.EqualTo(siteDirectory));
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
            var cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            var siteDirectory = new SiteDirectory(iid: iid, iDalUri:uri, cache:cache) { RevisionNumber = revisionNumber };

            Assert.That(siteDirectory.Iid, Is.EqualTo(iid));
            Assert.That(siteDirectory.RevisionNumber, Is.EqualTo(revisionNumber));
            Assert.That(siteDirectory.IDalUri, Is.EqualTo(uri));
            Assert.That(siteDirectory.Cache, Is.EqualTo(cache));
            Assert.That(siteDirectory.ClassKind, Is.EqualTo(ClassKind.SiteDirectory));
        }

        [Test]
        public void VerifyThatDisposeSetsCacheToNull()
        {
            var iid = Guid.NewGuid();
            var uri = new Uri("http://someuri");
            var cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            var siteDirectory = new SiteDirectory(iid: iid, iDalUri: uri, cache: cache);
            Assert.That(siteDirectory.Cache, Is.Not.Null);
            siteDirectory.Dispose();

            Assert.That(siteDirectory.Cache, Is.Null);
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

            Assert.That(testThing.TelephoneNumber, Is.Not.SameAs(clone.TelephoneNumber));
            Assert.That(clone.TelephoneNumber.Count, Is.EqualTo(testThing.TelephoneNumber.Count));
        }

        [Test]
        public void VerifyThatCloneListIsDifferent2()
        {
            var testThing = new RequirementsSpecification(Guid.NewGuid(), null, null);
            var req = new Requirement(Guid.NewGuid(), null, null);

            testThing.Requirement.Add(req);

            var clone = testThing.Clone(false);
            Assert.That(testThing.Group, Is.Not.SameAs(clone.Group));
            Assert.That(clone.Group.Count, Is.EqualTo(testThing.Group.Count));
        }

        [Test]
        public void VerifyThatCloneOrderedItemListIsDifferent()
        {
            var iteration = new Iteration(Guid.NewGuid(), null, null);
            var option = new Option(Guid.NewGuid(), null, null);
            iteration.Option.Add(option);

            var clone = iteration.Clone(false);
            Assert.That(iteration.Option, Is.Not.SameAs(clone.Option));
            Assert.That(clone.Option.Count, Is.EqualTo(iteration.Option.Count));
        }

        [Test]
        public void VerifyThatClonedThingHasReferenceToOriginal()
        {
            var iteration = new Iteration(Guid.NewGuid(), null, null);
            Assert.That(iteration.Original, Is.Null);

            var clone = iteration.Clone(false);
            
            Assert.That(iteration, Is.Not.SameAs(clone));
            Assert.That(iteration, Is.SameAs(clone.Original));            
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

            Assert.That(factor.IsContainedBy(x => x.Iid == sitedir.Iid), Is.True);
            Assert.That(factor.IsContainedBy(x => x.Iid == rdl.Iid), Is.True);
            Assert.That(factor.IsContainedBy(x => x.Iid == unit.Iid), Is.True);
            Assert.That(factor.IsContainedBy(x => x.Iid == model.Iid), Is.False);

            Assert.That(sitedir.IsContainedBy(x => x.Iid == sitedir.Iid), Is.False);

            Assert.That(() => factor.IsContainedBy(matchPredicate: null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatExceptionIsThrownWhenNoContainerIsProvidedToIsContainedBy()
        {
            SiteDirectory sitedir = null;
            var rdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            Assert.That(() => rdl.IsContainedBy(sitedir), Throws.TypeOf<ArgumentNullException>());
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

            Assert.That(factor.IsContainedBy(sitedir.Iid), Is.True);
            Assert.That(factor.IsContainedBy(rdl.Iid), Is.True);
            Assert.That(factor.IsContainedBy(unit.Iid), Is.True);
            Assert.That(factor.IsContainedBy(model.Iid), Is.False);

            Assert.That(sitedir.IsContainedBy(sitedir.Iid), Is.False);

            Assert.That(() => factor.IsContainedBy(iid: Guid.Empty), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyContainedItemReferencesOriginal()
        {
            var person = new Person(Guid.NewGuid(), null, null);
            var phone = new TelephoneNumber(Guid.NewGuid(), null, null);
            person.TelephoneNumber.Add(phone);

            var clone = person.Clone(false);

            Assert.That(phone.Container, Is.SameAs(person));
            Assert.That(phone.Container, Is.Not.SameAs(clone));

            Assert.That(person.TelephoneNumber.Contains(phone), Is.True);
            Assert.That(clone.TelephoneNumber.Contains(phone), Is.True);
        }

        [Test]
        public void VerifyThatGetContainerOfTypeWorks()
        {
            var sitedir = new SiteDirectory(Guid.NewGuid(), null, null);
            var siterdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var unit = new DerivedUnit(Guid.NewGuid(), null, null);

            sitedir.SiteReferenceDataLibrary.Add(siterdl);
            siterdl.Unit.Add(unit);

            Assert.That(siterdl, Is.SameAs(unit.GetContainerOfType(typeof(ReferenceDataLibrary))));
            Assert.That(siterdl, Is.SameAs(unit.GetContainerOfType(typeof(SiteReferenceDataLibrary))));
            Assert.That(siterdl, Is.SameAs(unit.GetContainerOfType(typeof(ModelReferenceDataLibrary))));
            Assert.That(sitedir, Is.SameAs(unit.GetContainerOfType(typeof(SiteDirectory))));
            Assert.That(unit.GetContainerOfType(typeof(Iteration)), Is.Null);

            Assert.That(siterdl, Is.SameAs(unit.GetContainerOfType<SiteReferenceDataLibrary>()));
            Assert.That(sitedir, Is.SameAs(unit.GetContainerOfType<SiteDirectory>()));
            Assert.That(unit.GetContainerOfType<ModelReferenceDataLibrary>(), Is.Null);
            Assert.That(siterdl, Is.SameAs(unit.GetContainerOfType<ReferenceDataLibrary>()));

            var requirementsgroup1 = new RequirementsGroup(Guid.NewGuid(), null, null);
            var requirementsgroup2 = new RequirementsGroup(Guid.NewGuid(), null, null);
            requirementsgroup1.Group.Add(requirementsgroup2);

            Assert.That(requirementsgroup1, Is.SameAs(requirementsgroup2.GetContainerOfType<RequirementsGroup>()));
            Assert.That(requirementsgroup1, Is.SameAs(requirementsgroup2.GetContainerOfType(typeof(RequirementsGroup))));
        }

        [Test]
        public void VerifyThatRouteOfNothingReturnsExpectedString()
        {
            var nothing = new NotThing("nothing");
            Assert.That(nothing.Route, Is.EqualTo("no thing, no route")); 
        }

        [Test]
        public void VerifyThatTopContainerOfNotThingIsNull()
        {
            var nothing = new NotThing("nothing");
            Assert.That(nothing.TopContainer, Is.Null);
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

            Assert.That(things.Count(), Is.EqualTo(11));

            Assert.That(things, Does.Contain( iteration));
            Assert.That(things, Does.Contain(elementDefinition1));
            Assert.That(things, Does.Contain(elementDefinition2));
            Assert.That(things, Does.Contain(alias1));
            Assert.That(things, Does.Contain(alias2));

            Assert.That(things, Does.Contain(possibleFiniteStateList1));
            Assert.That(things, Does.Contain(possibleFiniteStateList2));
            Assert.That(things, Does.Contain(possibleFiniteState1_1));
            Assert.That(things, Does.Contain(possibleFiniteState1_2));
            Assert.That(things, Does.Contain(possibleFiniteState2_1));
            Assert.That(things, Does.Contain(possibleFiniteState2_2));
        }
    }
}