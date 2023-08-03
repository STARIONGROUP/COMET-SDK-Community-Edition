// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemPropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    }
}
