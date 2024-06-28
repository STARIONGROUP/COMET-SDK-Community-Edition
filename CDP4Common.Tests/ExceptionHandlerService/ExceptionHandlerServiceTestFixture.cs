// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Helpers
{
    using System;

    using NUnit.Framework;

    using ExceptionHandlerService;

    /// <summary>
    /// Suite of tests for the <see cref="ExceptionHandlerService"/> class.
    /// </summary>
    [TestFixture]
    public class ExceptionHandlerServiceTestFixture
    {
        private Uri uri;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.stariongroup.eu");
        }

        [Test]
        public void Test_if_basic_handling_works_and_returns_false()
        {
            var testExceptionHandler = new TestExceptionHandler(false);
            var exceptionHandlerService = new ExceptionHandlerService(new[] { testExceptionHandler });

            Assert.Multiple(() =>
            {
                Assert.That(exceptionHandlerService.HandleException(new Exception()), Is.False);
                Assert.That(testExceptionHandler.WasExecuted, Is.True);
            });
        }

        [Test]
        public void Test_if_basic_handling_works_and_returns_true()
        {
            var testExceptionHandler = new TestExceptionHandler(true);
            var exceptionHandlerService = new ExceptionHandlerService(new[] { testExceptionHandler });

            Assert.Multiple(() =>
            {
                Assert.That(exceptionHandlerService.HandleException(new Exception()), Is.True);
                Assert.That(testExceptionHandler.WasExecuted, Is.True);
            });
        }

        [Test]
        public void Test_that_multiple_handlers_return_true()
        {
            var testExceptionHandler1 = new TestExceptionHandler(true);
            var testExceptionHandler2 = new TestExceptionHandler(true);
            var exceptionHandlerService = new ExceptionHandlerService(new[] { testExceptionHandler1, testExceptionHandler2 });

            Assert.Multiple(() =>
            {
                Assert.That(exceptionHandlerService.HandleException(new Exception()), Is.True);
                Assert.That(testExceptionHandler1.WasExecuted, Is.True);
                Assert.That(testExceptionHandler2.WasExecuted, Is.True);
            });
        }

        [Test]
        public void Test_that_multiple_handlers_return_true_when_at_least_one_returns_true_1()
        {
            var testExceptionHandler1 = new TestExceptionHandler(true);
            var testExceptionHandler2 = new TestExceptionHandler(false);
            var exceptionHandlerService = new ExceptionHandlerService(new[] { testExceptionHandler1, testExceptionHandler2 });

            Assert.Multiple(() =>
            {
                Assert.That(exceptionHandlerService.HandleException(new Exception()), Is.True);
                Assert.That(testExceptionHandler1.WasExecuted, Is.True);
                Assert.That(testExceptionHandler2.WasExecuted, Is.True);
            });
        }

        [Test]
        public void Test_that_multiple_handlers_return_true_when_at_least_one_returns_true_2()
        {
            var testExceptionHandler1 = new TestExceptionHandler(false);
            var testExceptionHandler2 = new TestExceptionHandler(true);
            var exceptionHandlerService = new ExceptionHandlerService(new[] { testExceptionHandler1, testExceptionHandler2 });

            Assert.Multiple(() =>
            {
                Assert.That(exceptionHandlerService.HandleException(new Exception()), Is.True);
                Assert.That(testExceptionHandler1.WasExecuted, Is.True);
                Assert.That(testExceptionHandler2.WasExecuted, Is.True);
            });
        }
    }

    public class TestExceptionHandler : IExceptionHandler
    {
        private bool result = false;
        public bool WasExecuted = false;

        public TestExceptionHandler(bool result)
        {
            this.result = result;
        }

        public bool HandleException(Exception exception, params object[] payload)
        {
            this.WasExecuted = true;
            return this.result;
        }
    }
}
