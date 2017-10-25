// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamHelper.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Helper
{
    using System.IO;

    /// <summary>
    /// The purpose of the <see cref="StreamHelper"/> is to generate a <see cref="Stream"/>
    /// from a <see cref="string"/>
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// Generates a <see cref="Stream"/> from a string
        /// </summary>
        /// <param name="s">
        /// The string that is to be converted into a stram
        /// </param>
        /// <returns>
        /// a <see cref="Stream"/> that contains the string
        /// </returns>
        public static Stream GenerateStreamFromString(string s)
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
