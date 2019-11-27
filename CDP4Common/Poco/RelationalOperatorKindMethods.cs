namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// Extension methods for the <see cref="RelationalOperatorKind"/> enum
    /// </summary>
    public static class RelationalOperatorKindMethods
    {
        /// <summary>
        /// Extension method that converts a <see cref="RelationalOperatorKind"/> to a readable string
        /// </summary>
        /// <param name="value"><see cref="RelationalOperatorKind"/> to convert</param>
        /// <returns></returns>
        public static string ToFriendlyString(this RelationalOperatorKind value)
        {
            switch (value)
            {
                case RelationalOperatorKind.EQ:
                    return "=";

                case RelationalOperatorKind.GE:
                    return "≥";

                case RelationalOperatorKind.GT:
                    return ">";

                case RelationalOperatorKind.LT:
                    return "<";

                case RelationalOperatorKind.LE:
                    return "≤";

                case RelationalOperatorKind.NE:
                    return "≠";

                default:
                    return value.ToString();
            }
        }
    }
}
