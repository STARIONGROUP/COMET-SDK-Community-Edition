// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroupTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="ParameterGroup"/> class
    /// </summary>
    public class ParameterGroupTestFixture
    {
        [Test]
        public void VerifytThatIfContainerIsNullReturnsEmptyGroupIEnumerable()
        {
            var parameterGroup = new ParameterGroup(Guid.NewGuid(), null, null);
            Assert.IsEmpty(parameterGroup.ContainedGroup());
        }

        [Test]
        public void VerifyThatContainedGroupsReturnsGroupsThatAreContained()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);
            var parameterGroup_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_2);

            var parameterGroup_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1);
            parameterGroup_1_1.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_2);
            parameterGroup_1_2.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1_1);
            parameterGroup_1_1_1.ContainingGroup = parameterGroup_1_1;

            Assert.IsEmpty(parameterGroup_2.ContainedGroup(elementDefinition.ParameterGroup));

            CollectionAssert.Contains(parameterGroup_1.ContainedGroup(elementDefinition.ParameterGroup), parameterGroup_1_1);
            CollectionAssert.Contains(parameterGroup_1.ContainedGroup(), parameterGroup_1_1);

            CollectionAssert.Contains(parameterGroup_1.ContainedGroup(elementDefinition.ParameterGroup), parameterGroup_1_2);            
            CollectionAssert.Contains(parameterGroup_1.ContainedGroup(), parameterGroup_1_2);

            CollectionAssert.DoesNotContain(parameterGroup_1.ContainedGroup(elementDefinition.ParameterGroup), parameterGroup_1_1_1);
            CollectionAssert.DoesNotContain(parameterGroup_1.ContainedGroup(), parameterGroup_1_1_1);
        }

        [Test]
        public void VerifyThatContainedGroupsDeepReturnsGroupsThatAreContained()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);
            var parameterGroup_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_2);

            var parameterGroup_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1);
            parameterGroup_1_1.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_2);
            parameterGroup_1_2.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1_1);
            parameterGroup_1_1_1.ContainingGroup = parameterGroup_1_1;

            Assert.IsEmpty(parameterGroup_2.ContainedGroup(true));

            Assert.IsFalse(parameterGroup_1.ContainedGroup(true).Contains(parameterGroup_1));
            Assert.IsTrue(parameterGroup_1.ContainedGroup(true).Contains(parameterGroup_1_1));
            Assert.IsTrue(parameterGroup_1.ContainedGroup(true).Contains(parameterGroup_1_2));
            Assert.IsTrue(parameterGroup_1.ContainedGroup(true).Contains(parameterGroup_1_1_1));
            Assert.AreEqual(3, parameterGroup_1.ContainedGroup(true).Count());

            Assert.IsTrue(parameterGroup_1_1.ContainedGroup(true).Contains(parameterGroup_1_1_1));
            Assert.AreEqual(1, parameterGroup_1_1.ContainedGroup(true).Count());

            Assert.IsEmpty(parameterGroup_1_2.ContainedGroup(true));
        }

        [Test]
        public void VerifytThatIfContainerIsNullReturnsEmptyParameterIEnumerable()
        {
            var parameterGroup = new ParameterGroup(Guid.NewGuid(), null, null);
            Assert.IsEmpty(parameterGroup.ContainedParameter());
        }

        [Test]
        public void VerifyThatParameterGroupReturnsContainedParameters()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);

            var parameterGroup_2 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_2);

            var parameter_0 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_0);

            var parameter_1_1 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_1_1);
            parameter_1_1.Group = parameterGroup_1;

            var parameter_1_2 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_1_2);
            parameter_1_2.Group = parameterGroup_1;

            var parameter_2_1 = new Parameter(Guid.NewGuid(), null, null);
            elementDefinition.Parameter.Add(parameter_2_1);
            parameter_2_1.Group = parameterGroup_2;

            CollectionAssert.Contains(parameterGroup_1.ContainedParameter(), parameter_1_1);
            CollectionAssert.Contains(parameterGroup_1.ContainedParameter(), parameter_1_2);
            CollectionAssert.DoesNotContain(parameterGroup_1.ContainedParameter(), parameter_0);
            CollectionAssert.DoesNotContain(parameterGroup_1.ContainedParameter(), parameter_2_1);

            CollectionAssert.Contains(parameterGroup_2.ContainedParameter(), parameter_2_1);
            CollectionAssert.DoesNotContain(parameterGroup_2.ContainedParameter(), parameter_1_1);
            CollectionAssert.DoesNotContain(parameterGroup_2.ContainedParameter(), parameter_1_2);
            CollectionAssert.DoesNotContain(parameterGroup_2.ContainedParameter(), parameter_0);
        }

        [Test]
        public void VerfiyThatLevelReturnsExpectedResult()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);

            var parameterGroup_0 = new ParameterGroup(Guid.NewGuid(), null, null);

            var parameterGroup_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1);

            var parameterGroup_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1);
            parameterGroup_1_1.ContainingGroup = parameterGroup_1;

            var parameterGroup_1_1_1 = new ParameterGroup(Guid.NewGuid(), null, null);
            elementDefinition.ParameterGroup.Add(parameterGroup_1_1_1);
            parameterGroup_1_1_1.ContainingGroup = parameterGroup_1_1;

            Assert.AreEqual(-1, parameterGroup_0.Level());
            Assert.AreEqual(0, parameterGroup_1.Level());
            Assert.AreEqual(1, parameterGroup_1_1.Level());
            Assert.AreEqual(2, parameterGroup_1_1_1.Level());
        }
    }
}

