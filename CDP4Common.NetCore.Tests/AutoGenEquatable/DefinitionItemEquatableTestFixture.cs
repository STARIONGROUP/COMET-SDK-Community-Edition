﻿// ---------------------------------------------------------------------------------------------
// <copyright file="DefinitionEquatableTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of CDP4-COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// ---------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.AutoGenEquatable
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using CDP4Common.DTO.Equatable;
	using CDP4Common.Types;

	using NUnit.Framework;

	using Definition = CDP4Common.DTO.Definition;

	/// <summary>
	/// Suite of tests for the <see cref="DefinitionEquatable"/>
	/// </summary>
	[TestFixture]
	public class DefinitionEquatableTestFixture
	{
		[Test]
		public void Verify_That_ActionItems_are_equal()
		{
			var me = new Definition(Guid.Parse("5b5843fb-9310-4f19-aea6-2419d92fc65c"), 1)
			{
				Note = new List<OrderedItem>
				{
					new OrderedItem { K = 1, V = "value 1"},
					new OrderedItem { K = 2, V = "value 2"}
				}
			};

			var other = new Definition(Guid.Parse("5b5843fb-9310-4f19-aea6-2419d92fc65c"), 1)
			{
				Note = new List<OrderedItem>
				{
					new OrderedItem { K = 1, V = "value 1"},
					new OrderedItem { K = 2, V = "value 2"}
				}
			};

			Assert.That(me.ArePropertiesEqual(other), Is.True);

			me.Note.First().K = 3;

			Assert.That(me.ArePropertiesEqual(other), Is.False);

			me.Note.First().K = 1;

			Assert.That(me.ArePropertiesEqual(other), Is.True);

			me.Note.First().V = "value 3";

			Assert.That(me.ArePropertiesEqual(other), Is.False);
		}
	}
}
