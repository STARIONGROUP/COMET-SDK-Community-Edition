// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticMetadataProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    using System;

    /// <summary>
    /// The static metadata provider
    /// </summary>
    public static class StaticMetadataProvider
    {
        /// <summary>
        /// The <see cref="MetaDataProvider"/> instance for the application
        /// </summary>
        private static readonly MetaDataProvider provider = new MetaDataProvider();

        /// <summary>
        /// Returns a meta info instance based on the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// A meta info instance.
        /// </returns>
        /// <exception cref="TypeLoadException">
        /// If type name not supported
        /// </exception>
        public static IMetaInfo GetMetaInfo(string typeName)
        {
            return provider.GetMetaInfo(typeName);
        }

        /// <summary>
        /// Gets the <see cref="IMetaDataProvider"/>
        /// </summary>
        public static IMetaDataProvider GetMetaDataProvider
        {
            get { return provider; }
        }

        /// <summary>
        /// Get the base type name of the supplied type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The base type or the same type name if class is the inheritance root.
        /// </returns>
        public static string BaseType(string typeName)
        {
            return provider.BaseType(typeName);
        }

        /// <summary>
        /// Get the class version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public static string GetClassVersion(string typeName)
        {
            return provider.GetClassVersion(typeName);
        }

        /// <summary>
        /// Get the property version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public static string GetPropertyVersion(string typeName, string propertyName)
        {
            return provider.GetPropertyVersion(typeName, propertyName);
        }
    }
}