// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryPropertyAccessorTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="SiteDirectory.QueryValue"/> method
    /// </summary>
    [TestFixture]
    public class SiteDirectoryPropertyAccessorTestFixture
    {
        [Test]
        public void Verify_that_empty_domainofexpertise_returns()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);

            var domainOfExpertises = (List<DomainOfExpertise>)siteDirectory.QueryValue("domain[0..*]");
            Assert.That(domainOfExpertises, Is.Empty);

            var names = (List<string>) siteDirectory.QueryValue("domain[0..*].name");
            Assert.That(names, Is.Empty);
            
            var aliases = (List<Alias>)siteDirectory.QueryValue("domain[0..*].alias[0..*]");
            Assert.That(aliases, Is.Empty);

            var contents = (List<string>)siteDirectory.QueryValue("domain[0..*].alias[0..*].content");
            Assert.That(contents, Is.Empty);
        }

        [Test]
        public void Verify_that_Participant_properties_can_be_accessed()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);

            var models = (List<EngineeringModelSetup>)siteDirectory.QueryValue("model[0..*]");
            Assert.That(models, Is.Empty);

            var engineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), null, null);
            siteDirectory.Model.Add(engineeringModelSetup);

            models = (List<EngineeringModelSetup>)siteDirectory.QueryValue("model[0..*]");
            var model = models.Single();
            Assert.That(model, Is.EqualTo(siteDirectory.Model.Single()));

            var objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*]");
            Assert.That(objects.Count, Is.EqualTo(0));
            var participants = objects.Cast<Participant>();
            Assert.That(participants.Count, Is.EqualTo(0));

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person");
            var persons = objects.Cast<Person>();
            Assert.That(persons.Count, Is.EqualTo(0));

            var participant_1 = new Participant(Guid.NewGuid(), null, null);
            engineeringModelSetup.Participant.Add(participant_1);

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person");
            persons = objects.Cast<Person>();
            Assert.That(persons.Count, Is.EqualTo(0));

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person.name");
            var names = objects.Cast<string>();
            Assert.That(names.Count, Is.EqualTo(0));

            var participant_2 = new Participant(Guid.NewGuid(), null, null);
            engineeringModelSetup.Participant.Add(participant_2);

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person");
            persons = objects.Cast<Person>();
            Assert.That(persons.Count, Is.EqualTo(0));

            var person = new Person(Guid.NewGuid(), null, null);
            participant_1.Person = person;

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person");
            persons = objects.Cast<Person>();
            Assert.That(persons.Count, Is.EqualTo(1));

            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person.shortname");
            var shortnames = objects.Cast<string>();
            Assert.That(shortnames.Count, Is.EqualTo(0));
            
            objects = (List<object>)siteDirectory.QueryValue("model[0..*].participant[0..*].person.name");
            names = objects.Cast<string>();
            Assert.That(names.Count, Is.EqualTo(1));
            Assert.That(names.Single(), Is.EqualTo(" "));
        }
    }
}
