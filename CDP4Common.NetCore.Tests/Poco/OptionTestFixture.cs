// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    internal class OptionTestFixture
    {
        [Test]
        public void VerifyThatIsDefaultWorks()
        {
            var iteration = new Iteration();
            var option1 = new Option();
            var option2 = new Option();

            iteration.Option.Add(option1);
            iteration.Option.Add(option2);
            iteration.DefaultOption = option1;

            Assert.IsTrue(option1.IsDefault);
            Assert.IsFalse(option2.IsDefault);
        }
    }
}