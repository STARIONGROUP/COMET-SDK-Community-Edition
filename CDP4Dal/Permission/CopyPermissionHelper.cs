// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyPermissionHelper.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Dal.Permission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// A structure that contains information about the possibilities to copy a <see cref="Thing"/>
    /// </summary>
    public struct CopyPermissionResult
    {
        /// <summary>
        /// Backing field for <see cref="CopyableThings"/> populated by the <see cref="CopyPermissionHelper"/> class
        /// </summary>
        internal List<Thing> copyableThings { get; set; } 

        /// <summary>
        /// Backing field for <see cref="ErrorList"/> populated by the <see cref="CopyPermissionHelper"/> class
        /// </summary>
        internal Dictionary<Thing, string> errorList { get; set; }

        /// <summary>
        /// Gets the <see cref="Thing"/>s that may be copied
        /// </summary>
        public IEnumerable<Thing> CopyableThings
        {
            get { return this.copyableThings; }
        }

        /// <summary>
        /// Gets the error list for the <see cref="Thing"/>s that may not be copied
        /// </summary>
        public IReadOnlyDictionary<Thing, string> ErrorList
        {
            get { return this.errorList; }
        }
    }

    /// <summary>
    /// A service class that computes the copy permission for <see cref="Thing"/>s
    /// </summary>
    public class CopyPermissionHelper
    {
        /// <summary>
        /// The <see cref="ISession"/>
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// The <see cref="IPermissionService"/> associated with this <see cref="session"/>
        /// </summary>
        private readonly IPermissionService permissionService;

        /// <summary>
        /// The <see cref="ReferenceDataLibrary"/> available
        /// </summary>
        private readonly List<ReferenceDataLibrary> availableRdls;

        /// <summary>
        /// The active <see cref="DomainOfExpertise"/>
        /// </summary>
        private readonly List<DomainOfExpertise> activeDomains;

        /// <summary>
        /// A value indicating whether the <see cref="DomainOfExpertise"/> of <see cref="IOwnedThing"/> is changed
        /// </summary>
        private readonly bool ownerIsChanged;

        /// <summary>
        /// The new <see cref="DomainOfExpertise"/> for <see cref="IOwnedThing"/> if applicable
        /// </summary>
        private DomainOfExpertise changedOwner;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyPermissionHelper"/> class
        /// </summary>
        /// <param name="session">The <see cref="ISession"/> associated to the copy operation target</param>
        /// <param name="ownerIsChanged">A value indicating whether the <see cref="DomainOfExpertise"/> of <see cref="IOwnedThing"/> is changed</param>
        public CopyPermissionHelper(ISession session, bool ownerIsChanged)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.ownerIsChanged = ownerIsChanged;

            this.availableRdls = new List<ReferenceDataLibrary>();
            this.activeDomains = new List<DomainOfExpertise>();
            this.session = session;
            this.permissionService = this.session.PermissionService;
        }

        /// <summary>
        /// Computes the copy permission asynchronously
        /// </summary>
        /// <param name="thingToCopy">The <see cref="Thing"/> to copy</param>
        /// <param name="targetContainer">The target container</param>
        /// <returns>The <see cref="CopyPermissionResult"/></returns>
        public Task<CopyPermissionResult> ComputeCopyPermissionAsync(Thing thingToCopy, Thing targetContainer)
        {
            return Task.Run(() => this.ComputeCopyPermission(thingToCopy, targetContainer));
        }

        /// <summary>
        /// Compute the copy permission for the <paramref name="thingToCopy"/>
        /// </summary>
        /// <param name="thingToCopy">The <see cref="Thing"/> to copy</param>
        /// <param name="targetContainer">The target container</param>
        /// <returns>The <see cref="CopyPermissionResult"/></returns>
        public CopyPermissionResult ComputeCopyPermission(Thing thingToCopy, Thing targetContainer)
        {
            if (thingToCopy == null)
            {
                throw new ArgumentNullException("thingToCopy");
            }

            if (targetContainer == null)
            {
                throw new ArgumentNullException("targetContainer", "The destination of the thing to copy cannot be null.");
            }

            if (!this.CheckContainement(thingToCopy, targetContainer))
            {
                throw new InvalidOperationException("The container is invalid for the thing to copy.");
            }

            if (!(thingToCopy is ElementDefinition) && thingToCopy.GetContainerOfType<ElementDefinition>() == null)
            {
                throw new NotImplementedException("The method is only implemented for things contained by ElementDefinition. The RequiredRdls property needs to be implemented in all things.");
            }

            var result = new CopyPermissionResult();
            result.errorList = new Dictionary<Thing, string>();
            result.copyableThings = new List<Thing>();

            var model = targetContainer.TopContainer as EngineeringModel;
            var iteration = targetContainer is Iteration it ? it : targetContainer.GetContainerOfType<Iteration>();
            this.changedOwner = this.session.OpenIterations.Single(x => x.Key.Iid == iteration.Iid).Value.Item1;

            if (model != null)
            {
                if (thingToCopy.TopContainer == targetContainer.TopContainer)
                {
                    throw new InvalidOperationException("The copy operation is only supported between 2 different models.");
                }

                this.ComputeAvailableRdl(model);
                this.ComputeActiveDomains(model);
                this.ComputeModelCopyPermission(thingToCopy, targetContainer, result);
            }

            return result;
        }

        /// <summary>
        /// Compute the copy permission for the <see cref="Thing"/> contained by an <see cref="EngineeringModel"/>, 
        /// its contained <see cref="Thing"/>s and its dependencies.
        /// </summary>
        /// <param name="thingToCopy">The <see cref="Thing"/> to copy</param>
        /// <param name="targetContainer">The target container</param>
        /// <param name="permissionResult">The <see cref="CopyPermissionResult"/> containing the result of the copy permission computation</param>
        private void ComputeModelCopyPermission(Thing thingToCopy, Thing targetContainer, CopyPermissionResult permissionResult)
        {
            if (thingToCopy.ClassKind == ClassKind.ParameterValueSet
                || thingToCopy.ClassKind == ClassKind.ParameterOverrideValueSet
                || thingToCopy.ClassKind == ClassKind.ParameterSubscriptionValueSet)
            {
                // value sets are not copied
                return;
            }

            if (!this.permissionService.CanWrite(thingToCopy.ClassKind, targetContainer))
            {
                permissionResult.errorList.Add(thingToCopy, $"You do not have permission to copy the {thingToCopy.ClassKind} with id {thingToCopy.Iid}.");
                return;
            }

            // all the required rdls for the thing to copy shall be available in the model destination
            var requiredRdls = thingToCopy.RequiredRdls.ToList();
            if (this.availableRdls.Intersect(requiredRdls).Count() != requiredRdls.Count)
            {
                permissionResult.errorList.Add(thingToCopy, $"The copy operation cannot be performed for the {thingToCopy.ClassKind} with id {thingToCopy.Iid} as some required reference data libraries are missing in the target model.");
                return;
            }

            var ownedThing = thingToCopy as IOwnedThing;
            if (ownedThing != null && !this.ownerIsChanged && !this.activeDomains.Contains(ownedThing.Owner))
            {
                permissionResult.errorList.Add(thingToCopy, $"The copy operation cannot be performed for the {thingToCopy.ClassKind} with id {thingToCopy.Iid}. The owner is not active in the target model");
                return;
            }

            // compute copy dependencies, if fail, dont copy
            if (!this.ComputeDependenciesCopyPermission(thingToCopy, targetContainer, permissionResult))
            {
                permissionResult.errorList.Add(thingToCopy, $"The copy operation cannot be performed for the {thingToCopy.ClassKind} with id {thingToCopy.Iid}. Some of its dependencies cannot be copied.");
                return;
            }

            var subscription = thingToCopy as ParameterSubscription;
            if (subscription != null && this.ownerIsChanged && (subscription.Owner == this.changedOwner || !this.activeDomains.Contains(ownedThing.Owner)))
            {
                permissionResult.errorList.Add(thingToCopy, $"The parameter subscription {thingToCopy.Iid} will not be copied. The owner of the subscribed parameter or override in the target destination is the same of the subscription or is not active in the target model.");
                return;
            }

            permissionResult.copyableThings.Add(thingToCopy);
            this.ComputeModelContainedThingPermission(thingToCopy, targetContainer, permissionResult);
        }

        /// <summary>
        /// Compute the copy permission for the contained <see cref="Thing"/>s of the <paramref name="thingToCopy"/>
        /// </summary>
        /// <param name="thingToCopy">The <see cref="Thing"/> to copy</param>
        /// <param name="targetContainer">The target container for <paramref name="thingToCopy"/></param>
        /// <param name="permissionResult">The <see cref="CopyPermissionResult"/></param>
        private void ComputeModelContainedThingPermission(Thing thingToCopy, Thing targetContainer, CopyPermissionResult permissionResult)
        {
            var thingToCopyClone = thingToCopy.Clone(false);
            thingToCopyClone.Container = targetContainer;

            foreach (var containerList in thingToCopyClone.ContainerLists)
            {
                foreach (Thing thing in containerList)
                {
                    this.ComputeModelCopyPermission(thing, thingToCopyClone, permissionResult);
                }
            }
        }

        /// <summary>
        /// Compute the copy permissions for the dependencies of the <paramref name="thingToCopy"/>
        /// </summary>
        /// <param name="thingToCopy">The <see cref="Thing"/> to copy</param>
        /// <param name="targetContainer">The target container for the <paramref name="thingToCopy"/></param>
        /// <param name="permissionResult">The <see cref="CopyPermissionResult"/> that is updated</param>
        /// <returns>True if the mandatory data of the dependencies can be copied</returns>
        private bool ComputeDependenciesCopyPermission(Thing thingToCopy, Thing targetContainer, CopyPermissionResult permissionResult)
        {
            switch (thingToCopy.ClassKind)
            {
                case ClassKind.ElementUsage:
                    return this.ComputeDependenciesCopyPermission((ElementUsage)thingToCopy, (ElementDefinition)targetContainer, permissionResult);
                default:
                    return true;
            }
        }

        /// <summary>
        /// Compute the copy permissions for the dependencies of the <paramref name="usage"/>
        /// </summary>
        /// <param name="usage">The <see cref="ElementUsage"/> to copy</param>
        /// <param name="targetContainer">The target container for the <paramref name="usage"/></param>
        /// <param name="permissionResult">The <see cref="CopyPermissionResult"/> that is updated</param>
        /// <returns>
        /// True if the <see cref="ElementDefinition"/> for the <paramref name="usage"/> can be copied 
        /// with all its <see cref="Parameter"/>
        /// </returns>
        private bool ComputeDependenciesCopyPermission(ElementUsage usage, ElementDefinition targetContainer, CopyPermissionResult permissionResult)
        {
            if (!permissionResult.copyableThings.Contains(usage.ElementDefinition) &&
                !permissionResult.errorList.ContainsKey(usage.ElementDefinition))
            {
                this.ComputeModelCopyPermission(usage.ElementDefinition, targetContainer.Container, permissionResult);
            }

            var errorThingIds = permissionResult.errorList.Select(err => err.Key.Iid).ToList();

            // the element definition should be copyable along its parameters
            var mandatoryIds = usage.ElementDefinition.Parameter.Select(p => p.Iid).ToList();
            mandatoryIds.Add(usage.ElementDefinition.Iid);

            return !errorThingIds.Intersect(mandatoryIds).Any();
        }

        /// <summary>
        /// Compute the required <see cref="ReferenceDataLibrary"/> for the <paramref name="model"/>
        /// </summary>
        /// <param name="model">The <see cref="EngineeringModel"/></param>
        private void ComputeAvailableRdl(EngineeringModel model)
        {
            this.availableRdls.Clear();
            var requiredRdl = model.EngineeringModelSetup.RequiredRdl.Single();
            this.availableRdls.Add(requiredRdl);
            this.availableRdls.AddRange(requiredRdl.RequiredRdls);
        }

        /// <summary>
        /// Compute the active <see cref="DomainOfExpertise"/> for the <paramref name="model"/>
        /// </summary>
        /// <param name="model">The <see cref="EngineeringModel"/></param>
        private void ComputeActiveDomains(EngineeringModel model)
        {
            this.activeDomains.Clear();
            this.activeDomains.AddRange(model.EngineeringModelSetup.ActiveDomain);
        }

        /// <summary>
        /// Check that the target <paramref name="container"/> is of the correct type for the <paramref name="thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to add</param>
        /// <param name="container">The potential container</param>
        /// <returns>True if the container is of the correct time</returns>
        private bool CheckContainement(Thing thing, Thing container)
        {
            var containerType = thing.GetContainerInformation().Item1;
            return containerType.IsInstanceOfType(container);
        }
    }
}