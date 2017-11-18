// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileIOTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2016 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonFileDal.Tests.Json
{
    using CDP4JsonFileDal.Json;

    using NUnit.Framework;

    [TestFixture]
    public class FileIOTestFixture
    {
        [Test]
        public void VerifyThatMemoryStreamIsGeneratedFromString()
        {
            var someString = "[somejsonstring]";

            var stream = FileIO.GenerateStreamFromString(someString);
            Assert.NotNull(stream);
            Assert.AreNotEqual(0, stream.Length);
        }
    }
}
