// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDTO.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System.Collections.Generic;

    /// <summary>
    /// A classless Data Transfer Object is a wrapper for a <see cref="Dictionary{TKey,TValue}"/>
    /// </summary>
    public class ClasslessDTO : Dictionary<string, object>
    {
    }
}