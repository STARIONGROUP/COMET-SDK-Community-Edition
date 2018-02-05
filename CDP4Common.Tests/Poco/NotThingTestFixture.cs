// -------------------------------------------------------------------------------------------------
// <copyright file="NotThingTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2018 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.CommonData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="NotThing"/> class
    /// </summary>
    [TestFixture]
    public class NotThingTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsProperties()
        {
            var name = "nothing";

            var nothing = new NotThing(name);

            Assert.AreEqual(name, nothing.Name);
            Assert.IsNull(nothing.Container);
            Assert.AreEqual(ClassKind.NotThing, nothing.ClassKind);
        }

        [Test]
        public void VerifyThatResolvePropertiesThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.ResolveProperties(null));
        }

        [Test]
        public void VerifyThatGenericCloneThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.Clone(false));
        }

        [Test]
        public void VerifyThatToDtoThrowsException()
        {
            var name = "nothing";
            var nothing = new NotThing(name);

            Assert.Throws<NotSupportedException>(() => nothing.ToDto());
        }
    }
}
