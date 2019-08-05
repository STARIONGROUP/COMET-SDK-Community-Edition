// <copyright file="RuleCheckerEngine.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;
    using CDP4Common.Polyfills;
    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="RuleCheckerEngine"/> is execute the <see cref="RuleChecker"/> on
    /// the provided <see cref="Thing"/>s.
    /// </summary>
    public class RuleCheckerEngine
    {
        /// <summary>
        /// A Dictionary used to store queried RuleCheckers per <see cref="Type"/>
        /// for fast access.
        /// </summary>
        private readonly Dictionary<Type, RuleChecker> ruleCheckers;

        /// <summary>
        /// A Dictionary of <see cref="Type"/>s and the Interfacse/Types they implement.
        /// </summary>
        private readonly Dictionary<Type, IEnumerable<Type>> typesAndInterfacesMap;

        /// <summary>
        /// Initializes a new instance of <see cref="RuleCheckerEngine"/>
        /// </summary>
        public RuleCheckerEngine()
        {
            this.ruleCheckers = new Dictionary<Type, RuleChecker>();
            this.typesAndInterfacesMap = new Dictionary<Type, IEnumerable<Type>>();

            foreach (var ruleCheckerType in this.QueryRuleCheckerTypes())
            {
                var ruleCheckerAttribute = ruleCheckerType.QueryGetCustomAttribute<RuleCheckerAttribute>() as RuleCheckerAttribute;

                if (ruleCheckerAttribute != null)
                {
                    var ruleChecker = Activator.CreateInstance(ruleCheckerType) as RuleChecker;

                    this.ruleCheckers.Add(ruleCheckerAttribute.Type, ruleChecker);
                }
            }
        }

        /// <summary>
        /// Queries all the current assembly for all the types that implement
        /// the abstract <see cref="RuleChecker"/> type.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Type}"/>
        /// </returns>
        private IEnumerable<Type> QueryRuleCheckerTypes()
        {
            var assembly = Assembly.GetAssembly(typeof(RuleChecker));

            var ruleCheckerTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(RuleChecker)));

            return ruleCheckerTypes;
        }
        
        /// <summary>
        /// Runs the <see cref="RuleCheckerEngine"/> on the provided <see cref="Thing"/>s
        /// </summary>
        /// <param name="things">
        /// The <see cref="Thing"/>s that need to be checked
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{RuleCheckResult}"/>
        /// </returns>
        public IEnumerable<RuleCheckResult> Run(IEnumerable<Thing> things)
        {
            foreach (var thing in things)
            {
                var runTimeType = thing.GetType();
                if (!this.typesAndInterfacesMap.TryGetValue(runTimeType, out var typesAndInterfaces))
                {
                    typesAndInterfaces = runTimeType.QueryBaseClassesAndInterfaces().ToList();
                    this.typesAndInterfacesMap.Add(runTimeType, typesAndInterfaces);
                }

                foreach (var type in typesAndInterfaces)
                {
                    if (this.ruleCheckers.TryGetValue(type, out var ruleChecker))
                    {
                        var methodInfos = ruleChecker.GetType().GetMethods().Where(m => m.GetCustomAttribute<RuleAttribute>() != null);
                        foreach (var methodInfo in methodInfos)
                        {
                            var ruleCheckResult = methodInfo.Invoke(ruleChecker, new object[] { thing }) as RuleCheckResult;
                            if (ruleCheckResult != null)
                            {
                                yield return ruleCheckResult;
                            }
                        }
                    }
                }
            }
        }
    }
}