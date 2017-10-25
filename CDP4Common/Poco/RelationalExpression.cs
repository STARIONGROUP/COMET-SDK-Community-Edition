// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpression.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// Extended part for the auto-generated <see cref="RelationalExpression"/>
    /// </summary>
    public partial class RelationalExpression
    {
        /// <summary>
        /// Gets the representation of the <see cref="RelationalExpression"/> as a string
        /// </summary>
        public override string StringValue
        {
            get
            {
                return string.Format(
                    "{0} {1} {2} {3}",
                    this.ParameterType.ShortName,
                    this.RelationalOperator,
                    string.Join(", ", this.Value),
                    (this.Scale != null) ? this.Scale.ShortName : string.Empty);
            }
        }
    }
}