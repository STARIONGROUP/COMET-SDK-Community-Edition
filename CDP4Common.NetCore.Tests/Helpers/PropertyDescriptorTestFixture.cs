// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDescriptorTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.Helpers
{
    using System;

    using CDP4Common.PropertyAccesor;

    using NUnit.Framework;
    
    /// <summary>
    /// Suite of tests for the <see cref="PropertyDescriptor"/> class.
    /// </summary>
    [TestFixture]
    public class PropertyDescriptorTestFixture
    {
        [Test]
        public void Verify_that_QueryPropertyDescriptor_returns_expected_results()
        {
            PropertyDescriptor descriptor = null;

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Name");
            Assert.That(descriptor.Name, Is.EqualTo("Name"));
            Assert.That(descriptor.Lower, Is.Null);
            Assert.That(descriptor.Upper, Is.Null);
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Name"));
            Assert.That(descriptor.NextPath, Is.Empty);
            
            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Name.Me");
            Assert.That(descriptor.Name, Is.EqualTo("Name"));
            Assert.That(descriptor.Lower, Is.Null);
            Assert.That(descriptor.Upper, Is.Null);
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Name"));
            Assert.That(descriptor.NextPath, Is.EqualTo("Me"));
            Assert.That(descriptor.Next.Name, Is.EqualTo("Me"));

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter[1..1]");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.EqualTo(1));
            Assert.That(descriptor.Upper, Is.EqualTo(1));
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Parameter[1..1]"));
            Assert.That(descriptor.NextPath, Is.Empty);
            Assert.That(descriptor.Next, Is.Null);

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter[0..*]");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.EqualTo(0));
            Assert.That(descriptor.Upper, Is.EqualTo(int.MaxValue));
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Parameter[0..*]"));
            Assert.That(descriptor.NextPath, Is.Empty);
            Assert.That(descriptor.Next, Is.Null);

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter[1..1].Name");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.EqualTo(1));
            Assert.That(descriptor.Upper, Is.EqualTo(1));
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Parameter[1..1]"));
            Assert.That(descriptor.NextPath, Is.EqualTo("Name"));
            Assert.That(descriptor.Next.Name, Is.EqualTo("Name"));
            Assert.That(descriptor.Next.PathLiteral, Is.EqualTo("Name"));

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter[1..*].Name");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.EqualTo(1));
            Assert.That(descriptor.Upper, Is.EqualTo(int.MaxValue));
            Assert.That(descriptor.NextPath, Is.EqualTo("Name"));

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter.Name[1..*]");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.Null);
            Assert.That(descriptor.Upper, Is.Null);
            Assert.That(descriptor.PathLiteral, Is.EqualTo("Parameter"));
            Assert.That(descriptor.NextPath, Is.EqualTo("Name[1..*]"));
            Assert.That(descriptor.Next.Name, Is.EqualTo("Name"));
            Assert.That(descriptor.Next.Lower, Is.EqualTo(1));
            Assert.That(descriptor.Next.Upper, Is.EqualTo(int.MaxValue));
            Assert.That(descriptor.Next.PathLiteral, Is.EqualTo("Name[1..*]"));

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter.Name[1..*].Me");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.Null);
            Assert.That(descriptor.Upper, Is.Null);
            Assert.That(descriptor.NextPath, Is.EqualTo("Name[1..*].Me"));
            Assert.That(descriptor.Next.Name, Is.EqualTo("Name"));
            Assert.That(descriptor.Next.Next.Name, Is.EqualTo("Me"));

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("Parameter[10..11]");
            Assert.That(descriptor.Name, Is.EqualTo("Parameter"));
            Assert.That(descriptor.Lower, Is.EqualTo(10));
            Assert.That(descriptor.Upper, Is.EqualTo(11));
            Assert.That(descriptor.NextPath, Is.EqualTo(""));
            Assert.That(descriptor.Next, Is.Null);

            descriptor = PropertyDescriptor.QueryPropertyDescriptor("actionee.selectedDomain.alias[1..1]");
            Assert.That(descriptor.Name, Is.EqualTo("actionee"));
            Assert.That(descriptor.Lower, Is.Null);
            Assert.That(descriptor.Upper, Is.Null);
            Assert.That(descriptor.NextPath, Is.EqualTo("selectedDomain.alias[1..1]"));
            Assert.That(descriptor.Next.Next.Name, Is.EqualTo("alias"));
            Assert.That(descriptor.Next.Next.Lower, Is.EqualTo(1));
            Assert.That(descriptor.Next.Next.Upper, Is.EqualTo(1));
            Assert.That(descriptor.Next.Next.Next, Is.Null);
        }

        [Test]
        public void Verify_that_QueryPropertyDescriptor_throws_exception_on_incorrect_multiplicity()
        {
            Assert.That(() =>
                PropertyDescriptor.QueryPropertyDescriptor("Parameter[-1..1]"), 
                Throws.Exception.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("The input may not contain a hyphen or minus sign"));
        }
    }
}
