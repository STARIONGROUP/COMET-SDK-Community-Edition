#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalUtils.cs" company="RHEA System S.A.">
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

namespace CDP4JsonFileDal
{
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4JsonFileDal.Json;

    /// <summary>
    /// Utility class for JSON File Data-Access-Layer
    /// </summary>
    internal static class JsonFileDalUtils
    {
        /// <summary>
        /// A remark to be included in the exchange header file.
        /// </summary>
        private const string ExchangeHeaderRemark = "This is an ECSS-E-TM-10-25 exchange file";

        /// <summary>
        /// The copyright text to be included in the exchange header file.
        /// </summary>
        private const string ExchangeHeaderCopyright = "Copyright 2016 © RHEA.";

        /// <summary>
        /// Adds the <see cref="referenceDataLibraries"/> to the target <see cref="siteReferenceDataLibraries"/> or <see cref="modelReferenceDataLibraries"/>
        /// depending on the type and whether the targets already contain them or not.
        /// </summary>
        /// <param name="referenceDataLibraries">
        /// The <see cref="ReferenceDataLibrary"/>s that are to be added to the target <see cref="HashSet{ReferenceDataLibrary}"/>
        /// </param>
        /// <param name="siteReferenceDataLibraries">
        /// The target <see cref="HashSet{SiteReferenceDataLibrary}"/>
        /// </param>
        /// <param name="modelReferenceDataLibraries">
        /// The target <see cref="HashSet{ModelReferenceDataLibrary}"/>
        /// </param>
        internal static void AddReferenceDataLibraries(
            IEnumerable<ReferenceDataLibrary> referenceDataLibraries,
            ref HashSet<SiteReferenceDataLibrary> siteReferenceDataLibraries,
            ref HashSet<ModelReferenceDataLibrary> modelReferenceDataLibraries)
        {
            foreach (var referenceDataLibrary in referenceDataLibraries)
            {
                var modelReferenceDataLibrary = referenceDataLibrary as ModelReferenceDataLibrary;
                if (modelReferenceDataLibrary != null && !modelReferenceDataLibraries.Contains(modelReferenceDataLibrary))
                {
                    modelReferenceDataLibraries.Add(modelReferenceDataLibrary);
                }

                var siteReferenceDataLibrary = referenceDataLibrary as SiteReferenceDataLibrary;
                if (siteReferenceDataLibrary != null && !siteReferenceDataLibraries.Contains(siteReferenceDataLibrary))
                {
                    siteReferenceDataLibraries.Add(siteReferenceDataLibrary);
                }
            }
        }

        /// <summary>
        /// Adds the provided <see cref="iteration"/> to the <see cref="iterations"/> if this does not already contain it
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is to be added
        /// </param>
        /// <param name="iterations">
        /// The target <see cref="HashSet{Iteration}"/>.
        /// </param>
        internal static void AddIteration(Iteration iteration, ref HashSet<Iteration> iterations)
        {
            if (!iterations.Contains(iteration))
            {
                iterations.Add(iteration);
            }
        }

        /// <summary>
        /// Adds the provided <see cref="engineeringModelSetup"/> to the <see cref="engineeringModelSetups"/> if this does not already contain it
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The <see cref="EngineeringModelSetup"/> that is to be added
        /// </param>
        /// <param name="engineeringModelSetups">
        /// The target <see cref="HashSet{EngineeringModelSetup}"/>.
        /// </param>
        internal static void AddEngineeringModelSetup(EngineeringModelSetup engineeringModelSetup, ref HashSet<EngineeringModelSetup> engineeringModelSetups)
        {
            if (!engineeringModelSetups.Contains(engineeringModelSetup))
            {
                engineeringModelSetups.Add(engineeringModelSetup);
            }
        }

        /// <summary>
        /// Adds the provided <see cref="iterationSetup"/> to the <see cref="iterationSetups"/> if this does not already contain it
        /// </summary>
        /// <param name="iterationSetup">
        /// The <see cref="IterationSetup"/> that is to be added
        /// </param>
        /// <param name="iterationSetups">
        /// The target <see cref="HashSet{IterationSetup}"/>.
        /// </param>
        internal static void AddIterationSetup(IterationSetup iterationSetup, ref HashSet<IterationSetup> iterationSetups)
        {
            if (!iterationSetups.Contains(iterationSetup))
            {
                iterationSetups.Add(iterationSetup);
            }
        }

        /// <summary>
        /// Adds the active <see cref="DomainOfExpertise"/> to the target <see cref="HashSet{DomainOfExpertise}"/> if this does not already contain them
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The <see cref="EngineeringModelSetup"/> that contains the active <see cref="DomainOfExpertise"/> instances.
        /// </param>
        /// <param name="domainOfExpertises">
        /// The target <see cref="HashSet{DomainOfExpertise}"/>
        /// </param>
        internal static void AddDomainsOfExpertise(EngineeringModelSetup engineeringModelSetup, ref HashSet<DomainOfExpertise> domainOfExpertises)
        {
            foreach (var domainOfExpertise in engineeringModelSetup.ActiveDomain)
            {
                if (!domainOfExpertises.Contains(domainOfExpertise))
                {
                    domainOfExpertises.Add(domainOfExpertise);
                }
            }
        }

        /// <summary>
        /// Adds the <see cref="Person"/> of the <see cref="Participant"/> of the <see cref="engineeringModelSetup"/>
        /// to the target <see cref="HashSet{Person}"/> if this does not already contain them
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The <see cref="EngineeringModelSetup"/> that contains the active <see cref="DomainOfExpertise"/> instances.
        /// </param>
        /// <param name="persons">
        /// The target <see cref="HashSet{Person}"/>
        /// </param>
        internal static void AddPersons(EngineeringModelSetup engineeringModelSetup, ref HashSet<Person> persons)
        {
            foreach (var participant in engineeringModelSetup.Participant)
            {
                if (!persons.Contains(participant.Person))
                {
                    persons.Add(participant.Person);
                }
            }
        }

        /// <summary>
        /// Creates a  <see cref="IEnumerable{Thing}"/> that contains references to those objects that are to be included
        /// in the JSON file
        /// </summary>
        /// <param name="siteDirectory">
        /// The <see cref="SiteDirectory"/> object that is to be serialized to the JSON file
        /// </param>
        /// <param name="siteReferenceDataLibraries">
        /// The <see cref="SiteReferenceDataLibrary"/> instances that are to be included
        /// </param>
        /// <param name="domainOfExpertises">
        /// The <see cref="DomainOfExpertise"/> instances that are to be included
        /// </param>
        /// <param name="persons">
        /// /// The <see cref="Person"/> instances that are to be included
        /// </param>
        /// <param name="engineeringModelSetups">
        /// The engineering Model Setups.
        /// </param>
        /// <param name="iterIterationSetups">
        /// The Iteration Setups.
        /// </param>
        /// <returns>
        /// The pruned <see cref="Thing"/> collection.
        /// </returns>
        internal static IEnumerable<CDP4Common.DTO.Thing> CreateSiteDirectoryAndPrunedContainedThingDtos(
            SiteDirectory siteDirectory,
            HashSet<SiteReferenceDataLibrary> siteReferenceDataLibraries,
            HashSet<DomainOfExpertise> domainOfExpertises,
            HashSet<Person> persons,
            HashSet<EngineeringModelSetup> engineeringModelSetups,
            HashSet<IterationSetup> iterIterationSetups)
        {
            var dtos = new List<CDP4Common.DTO.Thing>();

            CDP4Common.DTO.SiteDirectory siteDirectoryDto = null;

            // collect the SiteDirectory objec graph, except for the graph branches that need to be pruned
            foreach (var siteDirectoryItem in siteDirectory.QueryContainedThingsDeep())
            {
                if (siteDirectoryItem.GetType() == typeof(SiteDirectory))
                {
                    // include the SiteDirectory shallow DTO
                    siteDirectoryDto = (CDP4Common.DTO.SiteDirectory)siteDirectoryItem.ToDto();
                    dtos.Add(siteDirectoryDto);
                }
                else if (siteDirectoryItem.GetType() == typeof(SiteReferenceDataLibrary))
                {
                    // include the SiteReferenceDataLibrary shallow DTO
                    dtos.Add(siteDirectoryItem.ToDto());
                }
                else if (
                    siteDirectoryItem.GetContainerOfType<SiteReferenceDataLibrary>() == null &&
                    siteDirectoryItem.GetContainerOfType<DomainOfExpertise>() == null &&
                    siteDirectoryItem.GetContainerOfType<Person>() == null &&
                    siteDirectoryItem.GetContainerOfType<EngineeringModelSetup>() == null)
                {
                    dtos.Add(siteDirectoryItem.ToDto());
                }
            }

            // remove the domains-of-expertise that should not be included in the cloned SiteDirectory
            siteDirectoryDto.Domain.Clear();
            foreach (var domainOfExpertise in domainOfExpertises)
            {
                var pocos = domainOfExpertise.QueryContainedThingsDeep();
                var domainOfExpertiseDtos = pocos.Select(poco => poco.ToDto());
                dtos.AddRange(domainOfExpertiseDtos);

                siteDirectoryDto.Domain.Add(domainOfExpertise.Iid);
            }

            // remove the persons that should not be included in SiteDirectory DTO from the DTO
            siteDirectoryDto.Person.Clear();
            foreach (var person in persons)
            {
                var pocos = person.QueryContainedThingsDeep();
                var personDtos = pocos.Select(poco => poco.ToDto());
                dtos.AddRange(personDtos);
                siteDirectoryDto.Person.Add(person.Iid);
            }

            // remove the EngineeringModelSetup instances and replace with pruned onces only inlcuding the required iterationsetups
            var clonedEngineeringModelSetups = new List<EngineeringModelSetup>();
            foreach (var engineeringModelSetup in engineeringModelSetups)
            {
                var clonedEngìneeringModelSetup = engineeringModelSetup.Clone(false);
                clonedEngìneeringModelSetup.IterationSetup.Clear();

                foreach (var iterIterationSetup in iterIterationSetups)
                {
                    if (iterIterationSetup.Container == engineeringModelSetup)
                    {
                        clonedEngìneeringModelSetup.IterationSetup.Add(iterIterationSetup);
                    }
                }

                clonedEngineeringModelSetups.Add(clonedEngìneeringModelSetup);
            }

            siteDirectoryDto.Model.Clear();
            foreach (var engineeringModelSetup in clonedEngineeringModelSetups)
            {
                // retrieve the EngineeringModelSetup contained object graph, including a shallow copy of the ModelReferenceDataLibrary
                // the ModelReferenceDataLibrary contained objects are written to its respective JSON file
                var nonModelReferenceLibrary = engineeringModelSetup.QueryContainedThingsDeep().Where(x =>
                    x.GetType() == typeof(ModelReferenceDataLibrary) ||
                    x.GetContainerOfType<ModelReferenceDataLibrary>() == null);
                dtos.AddRange(nonModelReferenceLibrary.Select(poco => poco.ToDto()));

                siteDirectoryDto.Model.Add(engineeringModelSetup.Iid);
            }

            return dtos;
        }

        /// <summary>
        /// Queries the Person from the cache that is associated to the <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="userName">
        /// the username of the <see cref="Person"/> that is to be retrieved
        /// </param>
        /// <param name="siteDirectory">
        /// The <see cref="SiteDirectory"/> that references the cache to get the <see cref="Person"/> from
        /// </param>
        /// <returns>
        /// A instance of <see cref="Person"/>
        /// </returns>
        internal static Person QueryActivePerson(string userName, SiteDirectory siteDirectory)
        {
            var person = siteDirectory.Cache.Select(x => x.Value)
                     .Select(lazy => lazy.Value)
                     .OfType<Person>()
                     .SingleOrDefault(pers => pers.ShortName == userName);

            return person;
        }

        /// <summary>
        /// Factory method that creates a <see cref="ExchangeFileHeader"/> based on the provided <see cref="person"/>
        /// </summary>
        /// <param name="person">
        /// The <see cref="Person"/> that is used to create the <see cref="ExchangeFileHeader"/>
        /// </param>
        /// <returns>
        /// An instance of <see cref="ExchangeFileHeader"/>
        /// </returns>
        internal static ExchangeFileHeader CreateExchangeFileHeader(Person person)
        {
            var exchangeFileInitiator = new ExchangeFileInitiator
            {
                Iid = person.Iid,
                GivenName = person.GivenName,
                Surname = person.Surname,
                Email = person.DefaultEmailAddress != null ? person.DefaultEmailAddress.Value : null
            };

            var organization = person.Organization != null
                                   ? new OrganizationInfo
                                   {
                                       Iid = person.Organization.Iid,
                                       Name = person.Organization.Name,
                                       Site = null,
                                       Unit = !string.IsNullOrEmpty(person.OrganizationalUnit) ? person.OrganizationalUnit : null
                                   }
                                   : null;

            var exchangeFileHeader = new ExchangeFileHeader
            {
                DataModelVersion = "2.4.1",
                Remark = ExchangeHeaderRemark,
                Copyright = ExchangeHeaderCopyright,
                Extensions = null
            };

            exchangeFileHeader.CreatorPerson = exchangeFileInitiator;
            exchangeFileHeader.CreatorOrganization = organization;

            return exchangeFileHeader;
        }
    }
}
