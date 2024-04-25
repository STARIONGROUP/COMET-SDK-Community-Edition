// ---------------------------------------------------------------------------------------------
// <copyright file="ActionItemEquatableTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
	
	using CDP4Common.DTO.Equatable;

	using NUnit.Framework;

	using ActionItem = CDP4Common.DTO.ActionItem;

	/// <summary>
	/// Suite of tests for the <see cref="ActionItemEquatable"/>
	/// </summary>
	[TestFixture]
	public class ActionItemEquatableTestFixture
	{
		[Test]
		public void Verify_That_ActionItems_are_equal()
		{
			var me = new ActionItem(Guid.Parse("5b5843fb-9310-4f19-aea6-2419d92fc65c"), 1)
			{
				Actionee =  Guid.Parse("ace42ef8-0e5d-459d-9b9b-47aff4ff1cdc"),
				ApprovedBy = new List<Guid> { Guid.Parse("f60ea509-b7fc-4a87-bdf1-aab7d91a77f0"), Guid.Parse("eb4e96ba-f964-4466-bacf-33537458d1c4") },
				Classification = CDP4Common.ReportingData.AnnotationClassificationKind.MAJOR,
				CloseOutDate = null,
				Content = "some content"
			};

			var other = new ActionItem(Guid.Parse("5b5843fb-9310-4f19-aea6-2419d92fc65c"), 1)
			{
				Actionee = Guid.Parse("ace42ef8-0e5d-459d-9b9b-47aff4ff1cdc"),
				ApprovedBy = new List<Guid> { Guid.Parse("f60ea509-b7fc-4a87-bdf1-aab7d91a77f0"), Guid.Parse("eb4e96ba-f964-4466-bacf-33537458d1c4") },
				Classification = CDP4Common.ReportingData.AnnotationClassificationKind.MAJOR,
				CloseOutDate = null,
				Content = "some content"
			};

			Assert.That(me.ArePropertiesEqual(other), Is.True);
			
			me.CloseOutDate = new DateTime(1976, 8, 20);
			other.CloseOutDate = new DateTime(1976, 8, 20);
			Assert.That(me.ArePropertiesEqual(other), Is.True);

			me.CloseOutDate = null;
			Assert.That(me.ArePropertiesEqual(other), Is.False);
			me.CloseOutDate = new DateTime(1976, 8, 20);

			other.Content = null;
			Assert.That(me.ArePropertiesEqual(other), Is.False);
			other.Content = "some content";

			me.Content = null;
			Assert.That(me.ArePropertiesEqual(other), Is.False);
		}
	}
}
