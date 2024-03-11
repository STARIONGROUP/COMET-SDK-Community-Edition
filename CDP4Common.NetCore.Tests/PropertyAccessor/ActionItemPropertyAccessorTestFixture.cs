// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemPropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.PropertyAccessor
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="ActionItem.QueryValue"/> method
    /// </summary>
    [TestFixture]
    public class ActionItemPropertyAccessorTestFixture
    {
        [Test]
        public void Verify_that_ActionItemPropertyAccessor_can_access_approvedby()
        {
            var actionitem = new ActionItem
            {
                Iid = Guid.Parse("f6157c74-c0a1-4a8c-a6d0-468628496e5c"),
                RevisionNumber = 1,
            };

            var approvals = (IEnumerable<string>)actionitem.QueryValue("ApprovedBy[0..*].Content");
            Assert.That(approvals, Is.Empty);
        }

        [Test]
        public void Verify_that_ActionItemPropertyAccessor_can_access_actionee()
        {
            var participant = new Participant()
            {
                Iid = Guid.Parse("f6157c74-c0a1-4a8c-a6d0-468628496e5c"),
                RevisionNumber = 1,
                IsActive = true
            };

            var actionItem = new ActionItem
            {
                Iid = Guid.Parse("f6157c74-c0a1-4a8c-a6d0-468628496e5c"),
                RevisionNumber = 1,
                Actionee = participant
            };

            var actionee_IsActive = (bool)actionItem.QueryValue("actionee.isActive");
            Assert.That(actionee_IsActive, Is.True);

            var selectedDomain = (DomainOfExpertise)actionItem.QueryValue("actionee.selectedDomain");
            Assert.That(selectedDomain, Is.Null);

            var domainOfExpertise = new DomainOfExpertise()
            {
                Iid = Guid.Parse("8fe906b1-3529-4c19-8287-25e1ea1839b6"),
                RevisionNumber = 1,
                ShortName = "SYS"
            };

            participant.SelectedDomain = domainOfExpertise;

            selectedDomain = (DomainOfExpertise)actionItem.QueryValue("actionee.selectedDomain");
            Assert.That(selectedDomain, Is.EqualTo(domainOfExpertise));

            var selectedDomainShortName = (string)actionItem.QueryValue("actionee.selectedDomain.shortname");
            Assert.That(selectedDomainShortName, Is.EqualTo("SYS"));

            Assert.That(() => actionItem.QueryValue("actionee.selectedDomain.alias[1..1]"),
                Throws.TypeOf<IndexOutOfRangeException>());

            var queriedAliases = (List<Alias>)actionItem.QueryValue("actionee.selectedDomain.alias[0..*]");
            Assert.That(queriedAliases, Is.Empty);

            var alias_1 = new Alias(Guid.Parse("2d8a7eef-53f5-400f-9cd1-782b589c70a6"), null, null)
            {
                Content = "alias_1 content",
                IsSynonym = true,
                LanguageCode = "en-GB"
            };

            domainOfExpertise.Alias.Add(alias_1);
            
            var selectedDomain_Alias_1 = (Alias)actionItem.QueryValue("actionee.selectedDomain.alias[0..0]");
            Assert.That(selectedDomain_Alias_1, Is.EqualTo(alias_1));

            var selectedDomainFirstAliasContent = (string)actionItem.QueryValue("actionee.selectedDomain.alias[0..0].Content");
            Assert.That(selectedDomainFirstAliasContent, Is.EqualTo(alias_1.Content));

            var alias_2 = new Alias(Guid.Parse("39c4d145-1212-4cc7-b58a-313925b138a1"), null, null)
            {
                Content = "alias_2 content",
                IsSynonym = false,
                LanguageCode = "en-CA"
            };

            domainOfExpertise.Alias.Add(alias_2);

            selectedDomain_Alias_1 = (Alias)actionItem.QueryValue("actionee.selectedDomain.alias[0..0]");
            Assert.That(selectedDomain_Alias_1, Is.EqualTo(alias_1));

            var selectedDomain_Alias_2 = (Alias)actionItem.QueryValue("actionee.selectedDomain.alias[1..1]");
            Assert.That(selectedDomain_Alias_2, Is.EqualTo(alias_2));

            var aliases = actionItem.QueryValue("actionee.selectedDomain.alias[0..*]");
            Assert.That(aliases, Is.EquivalentTo(domainOfExpertise.Alias));

            var selectedDomain_Alias_2_languagecode = (string)actionItem.QueryValue("actionee.selectedDomain.alias[1..1].Languagecode");
            Assert.That(selectedDomain_Alias_2_languagecode, Is.EqualTo(alias_2.LanguageCode));

            var definition_1 = new Definition(Guid.Parse("63c30711-3c74-44a4-a069-89280ce761e1"), null, null);
            definition_1.Example.Add("example_1");

            domainOfExpertise.Definition.Add(definition_1);

            var selectedDomain_Definition_1_example_1 = (string)actionItem.QueryValue("actionee.selectedDomain.definition[0..0].Example[0..0]");
            Assert.That(selectedDomain_Definition_1_example_1, Is.EqualTo(definition_1.Example[0]));

            definition_1.Example.Add("example_2");

            var selectedDomain_Definition_1_examples = (List<string>)actionItem.QueryValue("actionee.selectedDomain.definition[0..0].Example[0..*]");
            Assert.That(selectedDomain_Definition_1_examples, Is.EquivalentTo(definition_1.Example));
        }
        
        [Test]
        public void Verify_that_ActionItemPropertyAccessor_returns_iid()
        {
            var actionitem = new ActionItem
            {
                Iid = Guid.Parse("f6157c74-c0a1-4a8c-a6d0-468628496e5c"),
                RevisionNumber = 1,
                CloseOutDate = new DateTime(1976, 8, 20),
                CloseOutStatement = "this is a closeout statement",
                Content = "this is some content"
            };

            var actionItemIid = (Guid)actionitem.QueryValue("iid");
            Assert.That(actionItemIid, Is.EqualTo(actionitem.Iid));

            var revisionNumber = (int)actionitem.QueryValue("RevisionNumber");
            Assert.That(revisionNumber, Is.EqualTo(actionitem.RevisionNumber));

            var closeOutDate = (DateTime)actionitem.QueryValue("CloseOutDate");
            Assert.That(closeOutDate, Is.EqualTo(actionitem.CloseOutDate));

            var closeOutStatement = (string)actionitem.QueryValue("CloseOutStatement");
            Assert.That(closeOutStatement, Is.EqualTo(actionitem.CloseOutStatement));

            var content = (string)actionitem.QueryValue("Content");
            Assert.That(content, Is.EqualTo(actionitem.Content));
        }

        [Test]
        public void Verify_that_ActionItemPropertyAccessor_returns_actionee_iid()
        {
            var actionitem = new ActionItem
            {
                Iid = Guid.Parse("f6157c74-c0a1-4a8c-a6d0-468628496e5c"),
                RevisionNumber = 1,
                CloseOutDate = new DateTime(1976, 8, 20),
                CloseOutStatement = "this is a closeout statement",
                Content = "this is some content"
            };

            var actionItemIid = (Guid)actionitem.QueryValue("iid");
            Assert.That(actionItemIid, Is.EqualTo(actionitem.Iid));
        }

        // Case for Guid value
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForIid()
        {
            var actionItem = new ActionItem();
            const string iidName = nameof(ActionItem.Iid);
            Assert.That(actionItem.Iid, Is.EqualTo(Guid.Empty));
            var newIid = Guid.NewGuid();

            actionItem.SetValue(iidName, newIid);
            Assert.That(actionItem.Iid, Is.EqualTo(newIid));

            actionItem.Iid = Guid.Empty;
            actionItem.SetValue(iidName, newIid.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.Iid, Is.EqualTo(newIid));
                Assert.That(() => actionItem.SetValue(iidName, 5), Throws.ArgumentException);
                Assert.That(() => actionItem.SetValue(iidName, null), Throws.ArgumentNullException);
            });
        }

        // Case for int value (non-nullable)
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForRevisionNumber()
        {
            var actionItem = new ActionItem();
            const string revisionNumberName = nameof(ActionItem.RevisionNumber);

            Assert.That(actionItem.RevisionNumber, Is.EqualTo(0));
            actionItem.SetValue(revisionNumberName, 5);

            Assert.That(actionItem.RevisionNumber, Is.EqualTo(5));
            actionItem.SetValue(revisionNumberName, "7");

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.RevisionNumber, Is.EqualTo(7));
                Assert.That(() => actionItem.SetValue(revisionNumberName, false), Throws.ArgumentException);
                Assert.That(() => actionItem.SetValue(revisionNumberName, null), Throws.ArgumentNullException);
            });
        }

        // Case for InvalidOperationException
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForClasskind()
        {
            var actionItem = new ActionItem();
            Assert.That(() => actionItem.SetValue("classKind", ClassKind.ParameterType), Throws.InvalidOperationException);
        }

        // Case for collection of Reference
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForExcludedDomain()
        {
            var actionItem = new ActionItem();
            var domainOfExpertise = new DomainOfExpertise();
            const string excludedDomainName = $"{nameof(ActionItem.ExcludedDomain)}[0..*]";

            Assert.That(actionItem.ExcludedDomain, Is.Empty);
            actionItem.SetValue(excludedDomainName, domainOfExpertise);

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.ExcludedDomain, Has.Count.EqualTo(1));
                Assert.That(actionItem.ExcludedDomain, Is.EquivalentTo(new List<DomainOfExpertise>{domainOfExpertise}));
            });

            var newExcludedDomains = new List<DomainOfExpertise>()
            {
                new (),
                new ()
            };

            actionItem.SetValue(excludedDomainName, newExcludedDomains);

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.ExcludedDomain, Has.Count.EqualTo(2));
                Assert.That(actionItem.ExcludedDomain, Is.EquivalentTo(newExcludedDomains));
                Assert.That(actionItem.ExcludedDomain, Does.Not.Contain(domainOfExpertise));
                Assert.That(() => actionItem.SetValue(excludedDomainName, new List<string>(){"domain"}), Throws.ArgumentException);
            });

            actionItem.SetValue(excludedDomainName, null);
            Assert.That(actionItem.ExcludedDomain, Is.Empty);
        }

        // Case for string
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForThingPreference()
        {
            var actionItem = new ActionItem();
            Assert.That(actionItem.ThingPreference, Is.Null);
            const string thingPreferenceName = nameof(ActionItem.ThingPreference);

            const string preferenceValue = "my new preference";
            actionItem.SetValue(thingPreferenceName, preferenceValue);

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.ThingPreference, Is.EqualTo(preferenceValue));
                Assert.That(() => actionItem.SetValue(thingPreferenceName, false), Throws.ArgumentException);
            });

            actionItem.SetValue(thingPreferenceName, null);
            Assert.That(actionItem.ThingPreference, Is.Null);
        }

        // Case for nullable Reference
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForActor()
        {
            var actionItem = new ActionItem();
            const string actorName = nameof(ActionItem.Actor);

            Assert.That(actionItem.Actor, Is.Null);

            var actor = new Person();
            actionItem.SetValue(actorName, actor);

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.Actor, Is.EqualTo(actor));
                Assert.That(() => actionItem.SetValue(actorName, new List<Person>{actor}), Throws.Exception);
                Assert.That(() => actionItem.SetValue(actorName, "Actor"), Throws.Exception);
            });

            actionItem.SetValue(actorName, null);
            Assert.That(actionItem.Actor, Is.Null);
        }

        // Case for Enum
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForClassification()
        {
            var actionItem = new ActionItem();
            const string classificationName = nameof(ActionItem.Classification);

            Assert.That(actionItem.Classification, Is.EqualTo(AnnotationClassificationKind.MAJOR));
            actionItem.SetValue(classificationName, AnnotationClassificationKind.MINOR);

            Assert.That(actionItem.Classification, Is.EqualTo(AnnotationClassificationKind.MINOR));
            actionItem.SetValue(classificationName, "MAJOR");

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.Classification, Is.EqualTo(AnnotationClassificationKind.MAJOR));
                Assert.That(() => actionItem.SetValue(classificationName, "major"), Throws.ArgumentException);
                Assert.That(() => actionItem.SetValue(classificationName,  false), Throws.ArgumentException);
                Assert.That(() => actionItem.SetValue(classificationName, null), Throws.ArgumentNullException);
            });
        }

        // Case nullable non reference value
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForCloseOutDate()
        {
            var actionItem = new ActionItem();
            const string closeOutDateName = nameof(ActionItem.CloseOutDate);
            var dateTime = DateTime.UtcNow.ToLocalTime();

            Assert.That(actionItem.CloseOutDate, Is.Null);
            actionItem.SetValue(closeOutDateName, dateTime);

            Assert.That(actionItem.CloseOutDate, Is.EqualTo(dateTime));

            actionItem.SetValue(closeOutDateName, null);
            Assert.That(actionItem.CloseOutDate, Is.Null);

            actionItem.SetValue(closeOutDateName, dateTime.ToString("O"));

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.CloseOutDate, Is.EqualTo(dateTime));
                Assert.That(() => actionItem.SetValue(closeOutDateName, "45"), Throws.ArgumentException);
                Assert.That(() => actionItem.SetValue(closeOutDateName, true), Throws.ArgumentException);
            });
        }

        // Case non nullable Reference
        [Test]
        public void VerifyActionItemPropertyAccessorSetValueForOwner()
        {
            var actionItem = new ActionItem();
            const string ownerName = nameof(ActionItem.Owner);
            Assert.That(actionItem.Owner, Is.Null);

            var owner = new DomainOfExpertise();
            actionItem.SetValue(ownerName, owner);

            Assert.Multiple(() =>
            {
                Assert.That(actionItem.Owner, Is.EqualTo(owner));
                Assert.That(() => actionItem.SetValue(ownerName, null), Throws.ArgumentNullException);
                Assert.That(() => actionItem.SetValue(ownerName, 45), Throws.ArgumentException);
            });
        }
    }
}
