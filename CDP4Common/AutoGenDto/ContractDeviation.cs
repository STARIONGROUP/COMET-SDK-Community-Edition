// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractDeviation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ContractDeviation"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModel), "ModellingAnnotation")]
    public abstract partial class ContractDeviation : ModellingAnnotationItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDeviation"/> class.
        /// </summary>
        protected ContractDeviation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractDeviation"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ContractDeviation(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets the route for the current <see ref="ContractDeviation"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();

            dictionary.Add("ApprovedBy", this.ApprovedBy);

            if (this.Author != null)
            {
                dictionary.Add("Author", new [] { this.Author });
            }

            dictionary.Add("Category", this.Category);

            dictionary.Add("Discussion", this.Discussion);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            if (this.Owner != null)
            {
                dictionary.Add("Owner", new [] { this.Owner });
            }

            if (this.PrimaryAnnotatedThing != null)
            {
                dictionary.Add("PrimaryAnnotatedThing", new [] { this.PrimaryAnnotatedThing.Value });
            }

            dictionary.Add("RelatedThing", this.RelatedThing);

            dictionary.Add("SourceAnnotation", this.SourceAnnotation);

            return dictionary;
        }

        /// <summary>
        /// Tries to remove references to id's if they exist in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to remove references for.</param>
        /// <param name="errors">The errors collected while trying to remove references</param>
        /// <returns>True if no errors were found while trying to remove references</returns>
        public override bool TryRemoveReferences(IEnumerable<Guid> ids, out List<string> errors)
        {
            errors = new List<string>();
            var referencedProperties = this.GetReferenceProperties();
            var addModelErrors = !ids.Contains(this.Iid);
            var result = true;

            foreach (var id in ids)
            {
                var foundProperty = referencedProperties.Where(x => x.Value.Contains(id)).ToList();

                if (foundProperty.Any())
                {
                    foreach (var kvp in foundProperty)
                    {
                        switch (kvp.Key)
                        {
                            case "ApprovedBy":
                                this.ApprovedBy.Remove(id);
                                break;

                            case "Author":
                                if (addModelErrors)
                                {
                                    errors.Add($"Removed reference '{id}' from Author property results in inconsistent ContractDeviation.");
                                    result = false;
                                }
                                break;

                            case "Category":
                                this.Category.Remove(id);
                                break;

                            case "Discussion":
                                this.Discussion.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "Owner":
                                if (addModelErrors)
                                {
                                    errors.Add($"Removed reference '{id}' from Owner property results in inconsistent ContractDeviation.");
                                    result = false;
                                }
                                break;

                            case "PrimaryAnnotatedThing":
                                this.PrimaryAnnotatedThing = null;
                                break;

                            case "RelatedThing":
                                this.RelatedThing.Remove(id);
                                break;

                            case "SourceAnnotation":
                                this.SourceAnnotation.Remove(id);
                                break;
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Tries to remove references to id's if they don't exist in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids</param>
        /// <param name="errors">The errors collected while trying to remove references</param>
        /// <returns>True if no errors were found while trying to remove references</returns>
        public override bool TryRemoveReferencesNotIn(IEnumerable<Guid> ids, out List<string> errors)
        {
            errors = new List<string>();
            var result = true;

            foreach (var referencedProperty in this.GetReferenceProperties())
            {
                switch (referencedProperty.Key)
                {
                    case "ApprovedBy":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ApprovedBy.Remove(toBeRemoved);
                        } 
                        break;

                    case "Author":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            errors.Add($"Removed reference '{referencedProperty.Key}' from Author property results in inconsistent ContractDeviation.");
                            result = false;
                        }
                        break;

                    case "Category":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Category.Remove(toBeRemoved);
                        } 
                        break;

                    case "Discussion":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Discussion.Remove(toBeRemoved);
                        } 
                        break;

                    case "ExcludedDomain":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ExcludedDomain.Remove(toBeRemoved);
                        } 
                        break;

                    case "ExcludedPerson":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ExcludedPerson.Remove(toBeRemoved);
                        } 
                        break;

                    case "Owner":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            errors.Add($"Removed reference '{referencedProperty.Key}' from Owner property results in inconsistent ContractDeviation.");
                            result = false;
                        }
                        break;

                    case "PrimaryAnnotatedThing":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.PrimaryAnnotatedThing = null;
                        }
                        break;

                    case "RelatedThing":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.RelatedThing.Remove(toBeRemoved);
                        } 
                        break;

                    case "SourceAnnotation":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.SourceAnnotation.Remove(toBeRemoved);
                        } 
                        break;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to any of the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to search for.</param>
        /// <returns>True is any of the id's in <paramref name="ids"/> is found in this instance's reference properties.</returns>
        public override bool HasMandatoryReferenceToAny(IEnumerable<Guid> ids)
        {
            var result = false;

            if (!ids.Any())
            {
                return false;
            }

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Author":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;

                    case "Owner":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to an id that cannot be found in the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The HashSet of Guids to search for.</param>
        /// <returns>True is the id in this instance's mandatory reference properties is not found in in <paramref name="ids"/>.</returns>
        public override bool HasMandatoryReferenceNotIn(HashSet<Guid> ids)
        {
            var result = false;

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Author":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;

                    case "Owner":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
