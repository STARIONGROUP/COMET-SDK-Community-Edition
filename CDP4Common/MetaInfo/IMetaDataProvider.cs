// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetaDataProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    /// <summary>
    /// Utility class that responsible for providing meta-data for any Thing.
    /// </summary>
    public interface IMetaDataProvider
    {
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
        IMetaInfo GetMetaInfo(string typeName);

        /// <summary>
        /// Get the base type name of the supplied type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The base type or the same type name if class is the inheritance root.
        /// </returns>
        string BaseType(string typeName);

        /// <summary>
        /// Get the class version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        string GetClassVersion(string typeName);

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
        string GetPropertyVersion(string typeName, string propertyName);
    }
}
