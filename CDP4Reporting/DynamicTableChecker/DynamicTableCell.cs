// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicTableCell.cs" company="Starion Group S.A.">
//  © Copyright European Space Agency, 2017-2023
//  <author>
//   Software developed by Starion Group S.A.
//  </author>
//  This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  No part of the package, including this file, may be copied, modified, propagated, or distributed
//  except according to the terms contained in the file 'LICENSE.txt'.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.DynamicTableChecker
{
    /// <summary>
    /// Wrapper class that is used to add dynamically generated tablecell in an existing report definition
    /// and set specific properties to thos table cells.
    /// </summary>
    public class DynamicTableCell
    {
        /// <summary>
        /// The expression that defines the text of the TableCell
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// The ForecolorExpression
        /// </summary>
        public string ForeColorExpression { get; set; }

        /// <summary>
        /// The BackcolorExpression
        /// </summary>
        public string BackColorExpression { get; set; }

        /// <summary>
        /// Instanciates a new <see cref="DynamicTableCell"/>
        /// </summary>
        /// <param name="expression"></param>
        public DynamicTableCell(string expression)
        {
            this.Expression = expression;
        }
    }
}
