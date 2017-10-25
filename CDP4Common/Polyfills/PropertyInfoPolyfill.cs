// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyInfoPolyfill.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Polyfills
{
    using System.Reflection;

    internal static class PropertyInfoPolyfill
    {
        internal static bool IsAttributeDefined<TAttribute>(this PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
