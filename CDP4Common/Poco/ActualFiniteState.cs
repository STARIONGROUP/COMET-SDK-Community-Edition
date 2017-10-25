// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteState.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Linq;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ActualFiniteState"/>
    /// </summary>
    public partial class ActualFiniteState
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.Name; }
        }

        /// <summary>
        /// Gets the user-friendly short name
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ShortName; }
        }

        /// <summary>
        /// Returns the <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new NullReferenceException("Container of ActualFiniteState is null");
            }

            // Get the names of the possible states in the same order as the possible state lists of the container actualfinitestatelist
            var possibleFiniteStateListIids = container.PossibleFiniteStateList.Select(x => x.Iid).ToList();
            var sortedNames = new string[possibleFiniteStateListIids.Count];

            foreach (var possibleFiniteState in this.PossibleState)
            {
                var index = possibleFiniteStateListIids.IndexOf(possibleFiniteState.Container.Iid);
                if (index >= 0)
                {
                    sortedNames[index] = possibleFiniteState.Name;
                }
            }

            var name = string.Join(" → ", sortedNames);
            return name;
        }

        /// <summary>
        /// Returns the <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new NullReferenceException("Container of ActualFiniteState is null");
            }

            // Get the short names of the possible states in the same order as the possible state lists of the container actualfinitestatelist
            var possibleFiniteStateListIids = container.PossibleFiniteStateList.Select(x => x.Iid).ToList();
            var sortedNames = new string[possibleFiniteStateListIids.Count];

            foreach (var possibleFiniteState in this.PossibleState)
            {
                var index = possibleFiniteStateListIids.IndexOf(possibleFiniteState.Container.Iid);
                if (index >= 0)
                {
                    sortedNames[index] = possibleFiniteState.ShortName;
                }
            }

            var name = string.Join(".", sortedNames);
            return name;
        }

        /// <summary>
        /// Returns the <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new NullReferenceException("Container of ActualFiniteState is null");
            }

            return container.Owner;
        }

        /// <summary>
        /// Gets a value indicating whether this is the default <see cref="ActualFiniteState"/> of a <see cref="ActualFiniteStateList"/>
        /// </summary>
        /// <remarks>
        /// The default <see cref="ActualFiniteState"/> is defined as the one which <see cref="PossibleFiniteState"/> are all the default value of their respective <see cref="PossibleFiniteStateList"/>
        /// </remarks>
        public bool IsDefault
        {
            get { return this.PossibleState.All(x => x.IsDefault); }
        }
    }
}