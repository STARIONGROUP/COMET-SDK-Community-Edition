// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTransactionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2022 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Linq;
    using System.Text;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;    
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    
    using CDP4Dal.Operations;

    using NUnit.Framework;

    /// <summary>
    /// Test suite of the <see cref="ThingTransaction"/> class
    /// </summary>
    [TestFixture]
    public class ThingTransactionTestFixture
    {
        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private Iteration iteration;

        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;
        private Uri uri = new Uri("http://www.stariongroup.eu");
        
        [SetUp]
        public void Setup()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();
            this.siteDirectory = new SiteDirectory(Guid.NewGuid(), this.cache, this.uri);
            this.engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var iterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, this.uri) { RevisionNumber = 1 };
            this.iteration.IterationSetup = iterationSetup;
            iterationSetup.IterationIid = this.iteration.Iid;

            this.engineeringModel.Iteration.Add(this.iteration);
            
            this.cache.TryAdd(new CacheKey(this.siteDirectory.Iid, null), new Lazy<Thing>(() => this.siteDirectory));
            this.cache.TryAdd(new CacheKey(this.engineeringModel.Iid, null), new Lazy<Thing>(() => this.engineeringModel));
            this.cache.TryAdd(new CacheKey(this.iteration.Iid, null), new Lazy<Thing>(() => this.iteration));
        }

        [Test]
        public void VerifyThatFilePathsAreReturned()
        {
            var filePath = "myPath\\file.txt";
            var byteArray = Encoding.ASCII.GetBytes("FileContents");
            var stream = new MemoryStream(byteArray);
            var contentHash = StreamToHashComputer.CalculateSha1HashFromStream(stream);
            var fileRevision1 = new FileRevision(Guid.NewGuid(), this.cache, this.uri) { ContentHash = contentHash, LocalPath = filePath };
            var fileRevision2 = new FileRevision(Guid.NewGuid(), this.cache, this.uri) { ContentHash = contentHash, LocalPath = filePath };

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, fileRevision1);
            transaction.CreateOrUpdate(fileRevision2);

            CollectionAssert.AreEqual(transaction.GetFiles(), new [] { filePath });
        }

        [Test]
        public void VerifyThatCanOnlyUseThingTransactionOnOneTopContainer()
        {
            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);

            var person = new Person(Guid.NewGuid(), this.cache, this.uri) { Container = this.siteDirectory };
            var transaction = new ThingTransaction(transactionContext, person);
            
            var duplicateSiteDirectory = new SiteDirectory(this.siteDirectory.Iid, this.cache, this.uri);
            var anotherPerson = new Person(Guid.NewGuid(), this.cache, this.uri) { Container = duplicateSiteDirectory };
            transaction.CreateOrUpdate(anotherPerson);

            var operationContainer = transaction.FinalizeTransaction();

            var count = operationContainer.Operations.Count();
            Assert.AreEqual(2, count);
        }

        [Test]
        public void VerifyThatCreateThingWorks()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri) {Container = this.siteDirectory};
            this.cache.TryAdd(new CacheKey(person.Iid, null), new Lazy<Thing>(() => person));

            var clonePerson = person.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, clonePerson);

            var phone = new TelephoneNumber();
            transaction.Create(phone, clonePerson);

            Assert.AreEqual(1, transaction.AddedThing.Count());
            Assert.AreEqual(1, transaction.UpdatedThing.Count);
        }

        [Test]
        public void VerifyThatCreateThingWorksWithAbstractContainer()
        {
            var siteRdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri)
            {
                Container = this.siteDirectory
            };
            this.cache.TryAdd(new CacheKey(siteRdl.Iid, null), new Lazy<Thing>(() => siteRdl));

            var cloneRdl = siteRdl.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, cloneRdl);

            var binaryRelationshipRule = new BinaryRelationshipRule(Guid.NewGuid(), null, null);

            transaction.Create(binaryRelationshipRule, cloneRdl);

            Assert.AreEqual(1, transaction.AddedThing.Count());
            Assert.AreEqual(1, transaction.UpdatedThing.Count);
        }

        [Test]
        public void VerifyThatCreateModelDoesNotWorks()
        {
            var newModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            
            Assert.Throws<InvalidOperationException>(() => new ThingTransaction(transactionContext, newModel));
        }

        [Test]
        public void VerifyThatCreateSiteDirDoesNotWorks()
        {
            var newSiteDirectory = new SiteDirectory(Guid.NewGuid(), this.cache, this.uri);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            
            Assert.Throws<InvalidOperationException>(() => new ThingTransaction(transactionContext, newSiteDirectory));
        }

        [Test]
        public void VerifyThatCreateIterationDoesNotWorks()
        {
            var newIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);

            Assert.Throws<InvalidOperationException>(() => new ThingTransaction(transactionContext, newIteration));
        }

        [Test]
        public void VerifyThatCreateThingTwiceDoesntThrowException()
        {
            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, this.siteDirectory.Clone(false));
            var phone = new TelephoneNumber(Guid.NewGuid(), this.cache, this.uri);

            Assert.That(() =>
            {
                transaction.Create(phone);
                transaction.Create(phone);
            }, Throws.Nothing);
        }

        [Test]
        public void VerifyThatUpdateThingWorks()
        {
            var phone = new TelephoneNumber(Guid.NewGuid(), this.cache, this.uri);
            this.cache.TryAdd(new CacheKey(phone.Iid, null), new Lazy<Thing>(() => phone));
            
            var clone = phone.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, clone);

            transaction.CreateOrUpdate(clone);
            Assert.AreEqual(1, transaction.UpdatedThing.Count);
        }

        [Test]
        public void VerifyThatUpdateThingThrowsExceptionUponUpdatingExistingCloneWithAnotherClone()
        {
            var phone = new TelephoneNumber(Guid.NewGuid(), this.cache, this.uri);            
            this.cache.TryAdd(new CacheKey(phone.Iid, null), new Lazy<Thing>(() => phone));
            
            var clone1 = phone.Clone(false);
            var clone2 = phone.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, clone1);

            transaction.CreateOrUpdate(clone1);
            transaction.CreateOrUpdate(clone2);

            Assert.IsTrue(transaction.UpdatedThing.Select(x => x.Value).Contains(clone1));
            Assert.IsFalse(transaction.UpdatedThing.Select(x => x.Value).Contains(clone2));
        }

        [Test]
        public void VerifyThatDeleteThingAlreadyDeletedWorks()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri);
            var email = new EmailAddress(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.Person.Add(person);
            person.EmailAddress.Add(email);

            this.cache.TryAdd(new CacheKey(person.Iid, null), new Lazy<Thing>(() => person));
            this.cache.TryAdd(new CacheKey(email.Iid, null), new Lazy<Thing>(() => email));

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, person.Clone(false));
            transaction.Delete(email.Clone(false));
            transaction.Delete(email.Clone(false));

            Assert.AreEqual(1, transaction.DeletedThing.Count());
        }

        [Test]
        public void VerifyThatUpdateContainerWorks()
        {

            var iterationClone = this.iteration.Clone(false);
            var option1 = new Option(Guid.NewGuid(), this.cache, this.uri);
            
            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration);
            var transaction = new ThingTransaction(transactionContext, iterationClone);
            transaction.CreateOrUpdate(iterationClone);

            // Add new option
            var optionTransaction = new ThingTransaction(option1, transaction, iterationClone);
            optionTransaction.Create(option1);
            optionTransaction.FinalizeSubTransaction(option1, iterationClone);

            var clone = (Iteration)transaction.GetClone(this.iteration);
            Assert.AreEqual(1, clone.Option.Count);
            Assert.AreEqual(0, iteration.Option.Count);

            // insert an option
            var option2 = new Option(Guid.NewGuid(), this.cache, this.uri);

            optionTransaction = new ThingTransaction(option2, transaction, iterationClone);
            optionTransaction.Create(option2);
            optionTransaction.FinalizeSubTransaction(option2, iterationClone, option1);
            Assert.AreEqual(0, this.iteration.Option.Count);
            Assert.AreEqual(2, clone.Option.Count);
        }
        
        /// <summary>
        /// Create a containment tree under site directory and update 
        /// </summary>
        [Test]
        public void FunctionalTestCase1()
        {
            var person1 = new Person();
            var phone = new TelephoneNumber();
            var cloneSiteDir = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var rootTransaction = new ThingTransaction(transactionContext, cloneSiteDir);
            rootTransaction.CreateOrUpdate(cloneSiteDir);

            var personTransaction = new ThingTransaction(person1, rootTransaction, cloneSiteDir);
            personTransaction.Create(person1);

            Assert.AreEqual(1, personTransaction.AddedThing.Count());
            Assert.AreEqual(1, personTransaction.UpdatedThing.Count);

            // phone dialog
            var phoneTransaction = new ThingTransaction(phone, personTransaction, person1);
            phoneTransaction.Create(phone);
            Assert.AreEqual(2, phoneTransaction.AddedThing.Count());
            Assert.AreEqual(0, phoneTransaction.UpdatedThing.Count);

            // ok phone, verify that phone is added to the person and to the transaction
            phoneTransaction.FinalizeSubTransaction(phone, person1);

            Assert.AreEqual(2, personTransaction.AddedThing.Count());
            Assert.IsTrue(personTransaction.AddedThing.Any(x => x == person1));
            Assert.IsTrue(personTransaction.AddedThing.Any(x => x == phone));

            // ok person1, verify that SiteDir contains the person
            personTransaction.FinalizeSubTransaction(person1, cloneSiteDir);

            Assert.IsTrue(cloneSiteDir.Person.Contains(person1));

            Assert.AreEqual(2, rootTransaction.AddedThing.Count());
            Assert.AreEqual(1, rootTransaction.UpdatedThing.Count);

            // update person1
            var person1_1 = person1.Clone(false);
            var person1_1Tr = new ThingTransaction(person1_1, rootTransaction, cloneSiteDir);
            person1_1Tr.CreateOrUpdate(person1_1);

            Assert.AreEqual(1, person1_1Tr.AddedThing.Count());
            Assert.AreEqual(1, person1_1Tr.UpdatedThing.Count);

            // add email
            var email = new EmailAddress();
            var emailTrans = new ThingTransaction(email, person1_1Tr, person1_1);
            emailTrans.Create(email);

            emailTrans.FinalizeSubTransaction(email, person1_1);
            // end add email, verify that email is added to person1_1, (the clone of person1)

            Assert.AreEqual(2, person1_1Tr.AddedThing.Count());
            Assert.AreEqual(1, person1_1Tr.UpdatedThing.Count);
            Assert.IsTrue(person1_1.EmailAddress.Contains(email));

            // update phone
            var phone_1 = phone.Clone(false);
            var phone_1Trans = new ThingTransaction(phone_1, person1_1Tr, person1_1);
            phone_1Trans.CreateOrUpdate(phone_1);
            phone_1Trans.FinalizeSubTransaction(phone_1, person1_1);
            // end update phone

            // verify that the new reference is used
            Assert.IsFalse(person1_1.TelephoneNumber.Contains(phone));
            Assert.IsTrue(person1_1.TelephoneNumber.Contains(phone_1));

            person1_1Tr.FinalizeSubTransaction(person1_1, cloneSiteDir);

            Assert.AreEqual(3, rootTransaction.AddedThing.Count());
            Assert.AreEqual(1, rootTransaction.UpdatedThing.Count);
            Assert.IsTrue(rootTransaction.AddedThing.Any(x => x == person1_1));
            Assert.IsTrue(cloneSiteDir.Person.Contains(person1_1));
            Assert.IsTrue(rootTransaction.AddedThing.Contains(phone_1));
            Assert.AreEqual(1, cloneSiteDir.Person.Count);
            
            // Create new person
            var person2 = new Person();
            var person2Trans = new ThingTransaction(person2, rootTransaction, cloneSiteDir);
            person2Trans.Create(person2);
            person2Trans.FinalizeSubTransaction(person2, cloneSiteDir);

            Assert.AreEqual(4, rootTransaction.AddedThing.Count());
            Assert.AreEqual(2, cloneSiteDir.Person.Count);

            // update person1
            var person1_2 = person1_1.Clone(false);
            var person1_2Trans = new ThingTransaction(person1_2, rootTransaction, cloneSiteDir);
            person1_2Trans.CreateOrUpdate(person1_2);

            // create email2
            var email2 = new EmailAddress();
            var email2Trans = new ThingTransaction(email2, person1_2Trans, person1_2);
            email2Trans.Create(email2);

            // verify that current Person is in the transaction
            var persons = email2Trans.AddedThing.OfType<Person>().ToList();
            Assert.AreEqual(1, persons.Count);
            Assert.IsTrue(persons.Contains(person1_2));
            Assert.IsFalse(persons.Any(x => x.Iid == person2.Iid));

            email2Trans.FinalizeSubTransaction(email2, person1_2);

            // update phone
            var phone_2 = phone_1.Clone(false);
            var phone_2Trans = new ThingTransaction(phone_2, person1_2Trans, person1_2);
            phone_2Trans.CreateOrUpdate(phone_2);

            Assert.IsNull(phone_2Trans.GetClone(person2));

            var person2clone = person2.Clone(false);
            phone_2Trans.FinalizeSubTransaction(phone_2, person2clone);
            Assert.IsTrue(phone_2Trans.AddedThing.Contains(person2clone));
            Assert.AreEqual(0, phone_2Trans.UpdatedThing.Count);
            Assert.IsTrue(person2clone.TelephoneNumber.Contains(phone_2));
            Assert.IsFalse(person1_2.TelephoneNumber.Contains(phone_2));

            person1_2Trans.FinalizeSubTransaction(person1_2, cloneSiteDir);

            Assert.IsTrue(cloneSiteDir.Person.Contains(person2clone));
            Assert.IsTrue(cloneSiteDir.Person.Contains(person1_2));
            Assert.AreEqual(2, cloneSiteDir.Person.Count);
            Assert.AreEqual(2, person1_2.EmailAddress.Count);

            Assert.AreEqual(5, rootTransaction.AddedThing.Count());
            Assert.AreEqual(1, rootTransaction.UpdatedThing.Count);
            var per1 = (Person)rootTransaction.AddedThing.Single(x => x.Iid == person1.Iid);
            var per2 = (Person)rootTransaction.AddedThing.Single(x => x.Iid == person2.Iid);
            var emailad1 = rootTransaction.AddedThing.Single(x => x.Iid == email.Iid);
            var emailad2 = rootTransaction.AddedThing.Single(x => x.Iid == email2.Iid);
            var tel = rootTransaction.AddedThing.Single(x => x.Iid == phone.Iid);

            Assert.IsTrue(per1.EmailAddress.Contains(emailad1));
            Assert.IsTrue(per1.EmailAddress.Contains(emailad2));
            Assert.IsFalse(per1.TelephoneNumber.Contains(tel));

            Assert.IsTrue(per2.TelephoneNumber.Contains(tel));

            var sitedir = (SiteDirectory)rootTransaction.UpdatedThing.Single().Value;
            Assert.AreSame(sitedir, cloneSiteDir);
            Assert.IsTrue(sitedir.Person.Contains(per1));
            Assert.IsTrue(sitedir.Person.Contains(per2));
        }

        /// <summary>
        /// Updating existing things
        /// </summary>
        [Test]
        public void FunctionalTestCase2()
        {
            var siterdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.SiteReferenceDataLibrary.Add(siterdl);

            var unit1 = new DerivedUnit(Guid.NewGuid(), this.cache, this.uri);
            siterdl.Unit.Add(unit1);

            var unitFactor1 = new UnitFactor(Guid.NewGuid(), this.cache, this.uri);
            unit1.UnitFactor.Add(unitFactor1);

            this.cache.TryAdd(new CacheKey(siterdl.Iid, null), new Lazy<Thing>(() => siterdl));
            this.cache.TryAdd(new CacheKey(unit1.Iid, null), new Lazy<Thing>(() => unit1));
            this.cache.TryAdd(new CacheKey(unitFactor1.Iid, null), new Lazy<Thing>(() => unitFactor1));

            // *******************************************************************
            var siteDirClone = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var rootTransaction = new ThingTransaction(transactionContext, siteDirClone);
            rootTransaction.CreateOrUpdate(siteDirClone);

            var siterdlC1 = siterdl.Clone(false);
            var siterdlC1Trans = new ThingTransaction(siterdlC1, rootTransaction, siteDirClone);
            siterdlC1Trans.CreateOrUpdate(siterdlC1);

            var unit1C1 = unit1.Clone(false);
            var unit1C1Trans = new ThingTransaction(unit1C1, siterdlC1Trans, siterdlC1);
            unit1C1Trans.CreateOrUpdate(unit1C1);

            var unitFactor1C1 = unitFactor1.Clone(false);
            var unitFactor1C1Trans = new ThingTransaction(unitFactor1C1, unit1C1Trans, unit1C1);
            unitFactor1C1Trans.CreateOrUpdate(unitFactor1C1);

            unitFactor1C1Trans.FinalizeSubTransaction(unitFactor1C1, unit1C1);

            // Add unitfactor
            var unitFactor2 = new UnitFactor();
            var unitFactor2Trans = new ThingTransaction(unitFactor2, unit1C1Trans, unit1C1);
            unitFactor2Trans.Create(unitFactor2);
            unitFactor2Trans.FinalizeSubTransaction(unitFactor2, unit1C1);

            unit1C1Trans.FinalizeSubTransaction(unit1C1, siterdlC1);

            siterdlC1Trans.FinalizeSubTransaction(siterdlC1, siteDirClone);

            Assert.IsTrue(rootTransaction.AddedThing.Contains(unitFactor2));
            Assert.AreEqual(4, rootTransaction.UpdatedThing.Count);

            Assert.AreEqual(2, unit1C1.UnitFactor.Count);
            Assert.IsTrue(unit1C1.UnitFactor.Contains(unitFactor2));
            Assert.IsTrue(unit1C1.UnitFactor.Contains(unitFactor1C1));

            // Add srdl2
            var srdl2 = new SiteReferenceDataLibrary();
            var srdl2Trans = new ThingTransaction(srdl2, rootTransaction, siteDirClone);
            srdl2Trans.Create(srdl2);

            // add unit
            var unit2 = new DerivedUnit();
            var unit2Trans = new ThingTransaction(unit2, srdl2Trans, srdl2);
            unit2Trans.Create(unit2);
            unit2Trans.FinalizeSubTransaction(unit2, srdl2);

            srdl2Trans.FinalizeSubTransaction(srdl2, siteDirClone);

            Assert.IsTrue(siteDirClone.SiteReferenceDataLibrary.Contains(srdl2));
            Assert.IsTrue(srdl2.Unit.Contains(unit2));


            // update site rdl1
            var srdlC2 = siterdlC1.Clone(false);
            var srdlC2TRans = new ThingTransaction(srdlC2, rootTransaction, siteDirClone);
            srdlC2TRans.CreateOrUpdate(srdlC2);

            // update unit1
            var unit1C2 = unit1C1.Clone(false);
            var unit1C2Trans = new ThingTransaction(unit1C2, srdlC2TRans, srdlC2);
            unit1C2Trans.CreateOrUpdate(unit1C2);

            // update container of unitfactor1
            var unitfactor1C2 = unitFactor1C1.Clone(false);
            var factor1C2Trans = new ThingTransaction(unitfactor1C2, unit1C2Trans, unit1C2);
            factor1C2Trans.CreateOrUpdate(unitfactor1C2);

            var unit2clone = unit2.Clone(false);
            factor1C2Trans.FinalizeSubTransaction(unitfactor1C2, unit2clone);

            Assert.AreEqual(2, unit1C2Trans.AddedThing.Count());
            Assert.AreEqual(3, unit1C2Trans.UpdatedThing.Count);
            Assert.IsTrue(unit2clone.UnitFactor.Contains(unitfactor1C2));
            Assert.IsFalse(unit1C2.UnitFactor.Contains(unitfactor1C2));

            // update container of unitfactor2
            var unitfactor2C1 = unitFactor2.Clone(false);
            var factor2C2Trans = new ThingTransaction(unitfactor2C1, unit1C2Trans, unit1C2);
            factor2C2Trans.CreateOrUpdate(unitfactor2C1);

            var unit2clone2 = unit2clone.Clone(false);
            factor2C2Trans.FinalizeSubTransaction(unitfactor2C1, unit2clone2);

            Assert.AreEqual(3, unit1C2Trans.AddedThing.Count());
            Assert.IsTrue(unit1C2Trans.AddedThing.Contains(unit2clone2));
            Assert.IsFalse(unit1C2Trans.AddedThing.Contains(unit2clone));

            Assert.AreEqual(3, unit1C2Trans.UpdatedThing.Count);
            Assert.IsTrue(unit2clone.UnitFactor.Contains(unitfactor1C2));
            Assert.IsFalse(unit1C2.UnitFactor.Contains(unitfactor1C2));

            unit1C2Trans.FinalizeSubTransaction(unit1C2, srdlC2);
            srdlC2TRans.FinalizeSubTransaction(srdlC2, siteDirClone);

            // final transaction
            Assert.AreEqual(3, rootTransaction.AddedThing.Count());
            Assert.AreEqual(4, rootTransaction.UpdatedThing.Count);
            Assert.IsTrue(rootTransaction.AddedThing.Contains(unitfactor2C1));
            Assert.IsTrue(rootTransaction.AddedThing.Contains(unit2clone2));

            var srdl2lastclone = (SiteReferenceDataLibrary)rootTransaction.GetClone(srdl2);
            Assert.IsTrue(siteDirClone.SiteReferenceDataLibrary.Contains(srdl2lastclone));
            Assert.IsTrue(srdl2lastclone.Unit.Contains(unit2clone2));

            var updatedThingValues = rootTransaction.UpdatedThing.ToList().Select(x => x.Value).ToList();
            Assert.IsTrue(updatedThingValues.Contains(siteDirClone));
            Assert.IsTrue(updatedThingValues.Contains(srdlC2));
            Assert.IsTrue(updatedThingValues.Contains(unit1C2));
            Assert.IsTrue(updatedThingValues.Contains(unitfactor1C2));
        }

        [Test]
        public void VerifyThatNewThingWithCacheDoesNotCrash()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, person);
            Assert.AreEqual(1, transaction.AddedThing.Count());
        }

        [Test]
        public void VerifyThatCreateDeepWorks()
        {
            var enumPt = new EnumerationParameterType();
            var enumPtDef = new Definition();

            enumPt.Definition.Add(enumPtDef);

            var enumValue = new EnumerationValueDefinition();
            var enumValueDef = new Definition();
            enumValue.Definition.Add(enumValueDef);

            enumPt.ValueDefinition.Add(enumValue);
            
            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext);
            transaction.CreateDeep(enumPt);
            Assert.AreEqual(4, transaction.AddedThing.Count());
        }

        [Test]
        public void VerifyThatCopyDeepWorks()
        {
            var enumPt = new EnumerationParameterType();
            var enumPtDef = new Definition();

            enumPt.Definition.Add(enumPtDef);

            var enumValue = new EnumerationValueDefinition(Guid.NewGuid(), null, null);
            var enumValueDef = new Definition();
            enumValue.Definition.Add(enumValueDef);

            enumPt.ValueDefinition.Add(enumValue);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext);
            transaction.CopyDeep(enumPt.Clone(true));
            Assert.AreEqual(4, transaction.AddedThing.Count());

            var valueDefInTransaction =
                (EnumerationValueDefinition)transaction.AddedThing.Single(x => x.ClassKind == ClassKind.EnumerationValueDefinition);

            Assert.AreNotEqual(enumValue.Iid, valueDefInTransaction.Iid);
        }

        /// <summary>
        /// Create email in person and directly delete it
        /// </summary>
        [Test]
        public void VerifyThatDeleteAddedThingWorksWithinSameSubTransaction()
        {
            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person = new Person();
            var personTransaction = new ThingTransaction(person, transaction, sitedir1);
            personTransaction.Create(person);

            var email = new EmailAddress();
            var emailTransaction = new ThingTransaction(email, personTransaction, person);
            emailTransaction.Create(email);
            emailTransaction.FinalizeSubTransaction(email, person);

            var deletedEmail = email.Clone(false);
            personTransaction.Delete(deletedEmail, person);
            Assert.IsEmpty(person.EmailAddress);

            Assert.IsTrue(personTransaction.DeletedThing.Contains(deletedEmail));

            personTransaction.FinalizeSubTransaction(person, sitedir1);
            var operationContainer = transaction.FinalizeTransaction();

            // sitedir and person
            Assert.AreEqual(2, operationContainer.Operations.Count());
        }

        /// <summary>
        /// create email in person, validate person, edit it again to delete email
        /// </summary>
        [Test]
        public void VerifyThatDeleteAddedThingWorksWithinDifferentSubTransaction()
        {
            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person = new Person();
            var personTransaction = new ThingTransaction(person, transaction, sitedir1);
            personTransaction.Create(person);

            var email = new EmailAddress();
            var emailTransaction = new ThingTransaction(email, personTransaction, person);
            emailTransaction.Create(email);
            emailTransaction.FinalizeSubTransaction(email, person);
            personTransaction.FinalizeSubTransaction(person, sitedir1);

            // edit person
            var person1 = person.Clone(false);
            var person1Transaction = new ThingTransaction(person1, transaction, sitedir1);
            person1Transaction.CreateOrUpdate(person1);

            var deletedEmail = email.Clone(false);
            person1Transaction.Delete(deletedEmail, person1);

            Assert.IsEmpty(person1.EmailAddress);
            Assert.IsTrue(person1Transaction.DeletedThing.Contains(deletedEmail));

            person1Transaction.FinalizeSubTransaction(person1, sitedir1);
            var operationContainer = transaction.FinalizeTransaction();

            // sitedir and person
            Assert.AreEqual(2, operationContainer.Operations.Count());
        }

        /// <summary>
        /// delete email in sub-transaction context
        /// </summary>
        [Test]
        public void VerifyThatDeleteExistingThingWorks()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri);
            var email = new EmailAddress(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.Person.Add(person);
            person.EmailAddress.Add(email);

            this.cache.TryAdd(new CacheKey(person.Iid, null), new Lazy<Thing>(() => person));
            this.cache.TryAdd(new CacheKey(email.Iid, null), new Lazy<Thing>(() => email));

            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person1 = person.Clone(false);
            var person1Transaction = new ThingTransaction(person1, transaction, sitedir1);
            person1Transaction.CreateOrUpdate(person1);

            var deletedEmail = email.Clone(false);
            person1Transaction.Delete(deletedEmail, person1);
            Assert.IsTrue(person1.EmailAddress.Contains(deletedEmail));
            Assert.IsTrue(person1Transaction.DeletedThing.Contains(deletedEmail));

            person1Transaction.FinalizeSubTransaction(person1, sitedir1);
            var operationContainer = transaction.FinalizeTransaction();

            // sitedir and person
            Assert.AreEqual(3, operationContainer.Operations.Count());
        }

        /// <summary>
        /// update email, then delete
        /// </summary>
        [Test]
        public void VerifyThatDeleteUpdatedThingWorksWithinSameSubTransaction()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri);
            var email = new EmailAddress(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.Person.Add(person);
            person.EmailAddress.Add(email);

            this.cache.TryAdd(new CacheKey(person.Iid, null), new Lazy<Thing>(() => person));
            this.cache.TryAdd(new CacheKey(email.Iid, null), new Lazy<Thing>(() => email));

            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person1 = person.Clone(false);
            var person1Transaction = new ThingTransaction(person1, transaction, sitedir1);
            person1Transaction.CreateOrUpdate(person1);

            var email1 = email.Clone(false);
            var email1Transaction = new ThingTransaction(email1, person1Transaction, person1);
            email1Transaction.CreateOrUpdate(email1);
            email1Transaction.FinalizeSubTransaction(email1, person1);

            var email2 = email1.Clone(false);
            person1Transaction.Delete(email2, person1);

            Assert.IsTrue(person1.EmailAddress.Contains(email2));
            Assert.IsTrue(person1Transaction.DeletedThing.Contains(email2));

            person1Transaction.FinalizeSubTransaction(person1, sitedir1);
            var operationContainer = transaction.FinalizeTransaction();

            // sitedir and person
            Assert.AreEqual(3, operationContainer.Operations.Count());
        }

        /// <summary>
        /// update email and person, update person then delete email
        /// </summary>
        [Test]
        public void VerifyThatDeleteUpdatedThingWorksInDifferentTransaction()
        {
            var person = new Person(Guid.NewGuid(), this.cache, this.uri);
            var email = new EmailAddress(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.Person.Add(person);
            person.EmailAddress.Add(email);

            this.cache.TryAdd(new CacheKey(person.Iid, null), new Lazy<Thing>(() => person));
            this.cache.TryAdd(new CacheKey(email.Iid, null), new Lazy<Thing>(() => email));

            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person1 = person.Clone(false);
            var person1Transaction = new ThingTransaction(person1, transaction, sitedir1);
            person1Transaction.CreateOrUpdate(person1);

            var email1 = email.Clone(false);
            var email1Transaction = new ThingTransaction(email1, person1Transaction, person1);
            email1Transaction.CreateOrUpdate(email1);
            email1Transaction.FinalizeSubTransaction(email1, person1);
            person1Transaction.FinalizeSubTransaction(person1, sitedir1);

            var person2 = person1.Clone(false);
            var person2Transaction = new ThingTransaction(person2, transaction, sitedir1);
            person2Transaction.CreateOrUpdate(person2);

            var email2 = email1.Clone(false);
            person2Transaction.Delete(email2, person2);

            Assert.IsTrue(person2.EmailAddress.Contains(email2));
            Assert.IsTrue(person2Transaction.DeletedThing.Contains(email2));

            person2Transaction.FinalizeSubTransaction(person2, sitedir1);
            var operationContainer = transaction.FinalizeTransaction();

            // sitedir and person
            Assert.AreEqual(3, operationContainer.Operations.Count());
        }

        /// <summary>
        /// Verify that deleting an added thing remove all its contained things from the lists of operations
        /// </summary>
        [Test]
        public void VerifyThatCascadeDeleteWorksOnAddedThing()
        {
            var sitedir1 = this.siteDirectory.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            var transaction = new ThingTransaction(transactionContext, sitedir1);

            var person = new Person();
            var personTransaction = new ThingTransaction(person, transaction, sitedir1);
            personTransaction.Create(person);

            var email = new EmailAddress();
            var emailTransaction = new ThingTransaction(email, personTransaction, person);
            emailTransaction.Create(email);
            emailTransaction.FinalizeSubTransaction(email, person);
            personTransaction.FinalizeSubTransaction(person, sitedir1);

            transaction.Delete(person.Clone(false));

            var operationContainer = transaction.FinalizeTransaction();
            // Update sitedir
            Assert.AreEqual(1, operationContainer.Operations.Count());
        }

        [Test]
        public void VerifyThatDryCopyWorks()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var elementDefinitionClone = elementDefinition.Clone(false);
            var targetIterationClone = targetIteration.Clone(false);
            
            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);            
            var transaction = new ThingTransaction(transactionContext);
            transaction.Copy(elementDefinitionClone, targetIterationClone, OperationKind.CopyDefaultValuesChangeOwner);

            var copypair = transaction.CopiedThing.Single();
            Assert.AreNotEqual(copypair.Key.Item1.Iid, copypair.Key.Item2.Iid);

            var operationContainer = transaction.FinalizeTransaction();
            Assert.AreEqual(1, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.CopyDefaultValuesChangeOwner));
            Assert.AreEqual(0, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.Update));
        }

        [Test]
        public void VerifyThatCtrlCopyWorks()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var elementDefinitionClone = elementDefinition.Clone(false);
            var targetIterationClone = targetIteration.Clone(false);
            
            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);
            var transaction = new ThingTransaction(transactionContext);
            transaction.Copy(elementDefinitionClone, targetIterationClone, OperationKind.CopyKeepValuesChangeOwner);

            var copypair = transaction.CopiedThing.Single();
            Assert.AreNotEqual(copypair.Key.Item1.Iid, copypair.Key.Item2.Iid);

            var operationContainer = transaction.FinalizeTransaction();
            Assert.AreEqual(1, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.CopyKeepValuesChangeOwner));
            Assert.AreEqual(0, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.Update));
        }

        [Test]
        public void VerifyThatShiftCopyWorks()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var sourceElementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(sourceElementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(sourceElementDefinition.CacheKey, new Lazy<Thing>(() => sourceElementDefinition));

            var elementDefinitionClone = sourceElementDefinition.Clone(false);
            var targetIterationClone = targetIteration.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);
            var transaction = new ThingTransaction(transactionContext);
            transaction.Copy(elementDefinitionClone, targetIterationClone, OperationKind.Copy);

            var copypair = transaction.CopiedThing.Single();
            Assert.AreNotEqual(copypair.Key.Item1.Iid, copypair.Key.Item2.Iid);

            var operationContainer = transaction.FinalizeTransaction();
            Assert.AreEqual(1, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.Copy));
            Assert.AreEqual(0, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.Update));
        }

        [Test]
        public void VerifyThatCtrlShiftCopyWorks()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var elementDefinitionClone = elementDefinition.Clone(false);
            var targetIterationClone = targetIteration.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);
            var transaction = new ThingTransaction(transactionContext);
            transaction.Copy(elementDefinitionClone, targetIterationClone, OperationKind.CopyKeepValues);

            var copypair = transaction.CopiedThing.Single();
            Assert.AreNotEqual(copypair.Key.Item1.Iid, copypair.Key.Item2.Iid);

            var operationContainer = transaction.FinalizeTransaction();
            Assert.AreEqual(1, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.CopyKeepValues));
            Assert.AreEqual(0, operationContainer.Operations.Count(x => x.OperationKind == OperationKind.Update));
        }

        [Test]
        public void VerifyThatWhenCopyOperationIsInvokedWithNonCopyOperationExceptionIsThrown()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var elementDefinitionClone = elementDefinition.Clone(false);
            var targetIterationClone = targetIteration.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);
            var transaction = new ThingTransaction(transactionContext);
            Assert.Throws<ArgumentException>(() => transaction.Copy(elementDefinitionClone, targetIterationClone, OperationKind.Create));
        }

        [Test]        
        public void VerifyThatCopyThrowsExcpetionCloneThatIsToBeCopiedIsNull()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var transactionContext = TransactionContextResolver.ResolveContext(targetIteration);
            var transaction = new ThingTransaction(transactionContext);

            Assert.Throws<ArgumentNullException>(() => transaction.Copy(null, OperationKind.Copy));
        }

        [Test]        
        public void VerifyThatCopyThrowsExceptionWhenDestinationIsNull()
        {
            var sourceModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var sourceIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var targetModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var targetIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            sourceModel.Iteration.Add(sourceIteration);
            targetModel.Iteration.Add(targetIteration);
            sourceIteration.Element.Add(elementDefinition);

            this.cache.TryAdd(sourceModel.CacheKey, new Lazy<Thing>(() => sourceModel));
            this.cache.TryAdd(sourceIteration.CacheKey, new Lazy<Thing>(() => sourceIteration));
            this.cache.TryAdd(targetModel.CacheKey, new Lazy<Thing>(() => targetModel));
            this.cache.TryAdd(targetIteration.CacheKey, new Lazy<Thing>(() => targetIteration));
            this.cache.TryAdd(elementDefinition.CacheKey, new Lazy<Thing>(() => elementDefinition));

            var elementDefinitionClone = elementDefinition.Clone(false);

            var transactionContext = TransactionContextResolver.ResolveContext(sourceIteration);
            var transaction = new ThingTransaction(transactionContext);
            Assert.Throws<ArgumentNullException>(() => transaction.Copy(elementDefinitionClone, null, OperationKind.Copy));
        }

        [Test]
        public void VerifyThatGetLastCloneCreatedThrowsExceptionWhenThingIsNullOrGuidIsEmptyGuid()
        {
            var model = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            
            model.Iteration.Add(iteration);
            
            var transactionContext = TransactionContextResolver.ResolveContext(iteration);
            var transaction = new ThingTransaction(transactionContext);

            Assert.Throws<ArgumentNullException>(() => transaction.GetLastCloneCreated(null));

            var elementDefinition = new ElementDefinition(Guid.Empty, this.cache, this.uri);

            Assert.Throws<ArgumentOutOfRangeException>(() => transaction.GetLastCloneCreated(elementDefinition));
        }

        [Test]
        public void VerifyThatArgumentNullExceptionIsThrownWhenContextIsNull()
        {
             Assert.Throws<ArgumentNullException>(() => new ThingTransaction(null));
        }
        
        [Test]
        public void VerifyThatArgumentNullExceptionIsThrownWhenCloneIsNull()
        {
            var model = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);

            model.Iteration.Add(iteration);
            iteration.Element.Add(elementDefinition);

            var transactionContext = TransactionContextResolver.ResolveContext(elementDefinition);

            var iterationClone = iteration.Clone(false);
            var elementDefinitionClone = elementDefinition.Clone(false);

            Assert.Throws<ArgumentNullException>(() => new ThingTransaction(null, null, iterationClone));            
        }
    }
}
