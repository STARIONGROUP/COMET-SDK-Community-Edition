// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDTO.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    /// <summary>
    /// A classless Data Transfer Object is a wrapper for a <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    public class ClasslessDTO : Dictionary<string, object>
    {
        /// <summary>
        /// The <see cref="IMetaDataProvider"/>
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="IMetaDataProvider"/>
        /// </summary>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/> used in the application</param>
        public ClasslessDTO(IMetaDataProvider metaDataProvider)
        {
            this.metaDataProvider = metaDataProvider;
        }

        /// <summary>
        /// Given a <see cref="List{T}"/> of properties to add, populate this plain DTO from a <see cref="CDP4Common.DTO.Thing"/>. The Iid and Classkind are populated automatically and thus
        /// do not require to be entered into the <see cref="propertyList"/> variable. If <see cref="propertyList"/> is null then only the Iid and ClassKind are passed.
        /// </summary>
        /// <typeparam name="T">
        /// Of type <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// The <see cref="Thing"/>, properties of which to use to populate this DTO with.
        /// </param>
        /// <param name="propertyList">
        /// The list of names of property names to use to filter. Can be null to produce the simplest form with just Id and ClassKind
        /// </param>
        /// <returns>
        /// The <see cref="ClasslessDTO"/>.
        /// </returns>
        public ClasslessDTO FromThing<T>(T thing, IEnumerable<string> propertyList = null) where T : Thing
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            // the Iid and ClassKind properties are transferred automatically
            this.Add("ClassKind", thing.ClassKind);
            this.Add("Iid", thing.Iid);
            var metainfo = this.metaDataProvider.GetMetaInfo(thing.ClassKind.ToString());

            // all other named properties
            if (propertyList != null)
            {
                foreach (var property in propertyList)
                {
                    // If Iid somehow gets included into the list just skip it
                    if (property.Equals("Iid") || property.Equals("ClassKind"))
                    {
                        continue;
                    }

                    var propertyMetadata = metainfo.GetPropertyMetaInfo(property);
                    if (!propertyMetadata.IsDerived && propertyMetadata.IsDataMember)
                    {
                        var propertyValue = metainfo.GetValue(property, thing);
                        if (propertyValue == null && !propertyMetadata.IsNullable)
                        {
                            propertyValue = string.Empty;
                        }

                        this.Add(property, propertyValue);
                    }
                } 
            }

            return this;
        }

        /// <summary>
        /// The full <see cref="ClasslessDTO"/> from thing.
        /// </summary>
        /// <param name="thing">
        /// The thing.
        /// </param>
        /// <typeparam name="T">
        /// Of type <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// The <see cref="ClasslessDTO"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the provided <see cref="Thing"/> is null this exception is thrown.
        /// </exception>
        public ClasslessDTO FullFromThing<T>(T thing) where T : Thing
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            // the Iid and ClassKind properties are transferred automatically
            this.Add("ClassKind", thing.ClassKind);
            this.Add("Iid", thing.Iid);
            var metainfo = this.metaDataProvider.GetMetaInfo(thing.ClassKind.ToString());

            foreach (var property in metainfo.GetPropertyNameCollection())
            {
                var propertyMetadata = metainfo.GetPropertyMetaInfo(property);
                if (property.Equals("Iid") || property.Equals("ClassKind") || propertyMetadata.IsDerived || !propertyMetadata.IsDataMember)
                {
                    continue;
                }

                var propertyValue = metainfo.GetValue(property, thing);
                if (propertyValue == null && !propertyMetadata.IsNullable)
                {
                    propertyValue = string.Empty;
                }

                this.Add(property, propertyValue);
            }

            return this;
        }
    }
}
