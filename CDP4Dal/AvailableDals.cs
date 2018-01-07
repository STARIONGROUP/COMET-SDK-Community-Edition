// -------------------------------------------------------------------------------------------------
// <copyright file="AvailableDals.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    using System;
    using System.Collections.Generic;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.ComponentModel.Composition;
#endif
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;

    /// <summary>
    /// Instantiated by MEF to provide a list of <see cref="IDal"/> available in the application
    /// </summary>
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    [Export(typeof(AvailableDals))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public class AvailableDals
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableDals"/> class
        /// </summary>
        /// <param name="dataAccessLayerKinds">the list of <see cref="IDal"/> in the application</param>
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
        [ImportingConstructor]
        public AvailableDals([ImportMany] IEnumerable<Lazy<IDal, IDalMetaData>> dataAccessLayerKinds)
        {
            this.DataAccessLayerKinds = new List<Lazy<IDal, IDalMetaData>>();

            foreach (var dalkind in dataAccessLayerKinds)
            {
                this.DataAccessLayerKinds.Add(dalkind);
            }
        }
#else
        public AvailableDals(IEnumerable<Lazy<IDal, IDalMetaData>> dataAccessLayerKinds)
        {
            this.DataAccessLayerKinds = new List<Lazy<IDal, IDalMetaData>>();

            foreach (var dalkind in dataAccessLayerKinds)
            {
                this.DataAccessLayerKinds.Add(dalkind);
            }
        }
#endif

        /// <summary>
        /// Gets the Available IDAL implementations that the user can select one from
        /// </summary>
        public List<Lazy<IDal, IDalMetaData>> DataAccessLayerKinds { get; private set; }
    }
}