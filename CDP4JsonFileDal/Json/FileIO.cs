// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileIO.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonFileDal.Json
{
    using System.IO;

    /// <summary>
    /// The purpose of this class is to perform the writing and reading of local database exports of a SiteDirectory and EngineeringModel/Iteration combinations.
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        /// Generates a <see cref="MemoryStream"/> from a string.
        /// </summary>
        /// <param name="s">
        /// The string to convert.
        /// </param>
        /// <returns>
        /// The <see cref="MemoryStream"/> generated from the string.
        /// </returns>
        public static MemoryStream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
