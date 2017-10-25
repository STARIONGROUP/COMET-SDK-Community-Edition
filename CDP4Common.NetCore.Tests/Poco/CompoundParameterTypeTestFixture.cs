// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterTypeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class CompoundParameterTypeTestFixture
    {
        [Test]
        public void VerifyThatNumberOfValuesIsCorrect()
        {
            var compound = new CompoundParameterType();

            var compound2 = new CompoundParameterType();
            var scalar = new EnumerationParameterType();

            var scalarc1 = new ParameterTypeComponent() {ParameterType = scalar};
            compound2.Component.Add(scalarc1);
            compound2.Component.Add(scalarc1);
            compound2.Component.Add(scalarc1);

            var compound2Component = new ParameterTypeComponent() {ParameterType = compound2};

            compound.Component.Add(compound2Component);
            compound.Component.Add(scalarc1);

            Assert.AreEqual(4, compound.NumberOfValues);
        }
    }
}
