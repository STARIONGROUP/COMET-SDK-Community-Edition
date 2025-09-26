// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyDescriptor.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.PropertyAccesor
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The <see cref="PropertyDescriptor"/> is used to convert and capture the 
    /// (nested) property path of a Thing into the name of the parameter, the lower and
    /// upper bound as well as the next part of the path.
    /// </summary>
    /// <example>
    /// definition[0..*].content
    ///    name: definitopn
    ///    lower: 0
    ///    upper: 1
    ///    next: content
    /// </example>
    public class PropertyDescriptor
    {
        /// <summary>
        /// Gets or sets the name of the property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the lower bound of the property
        /// </summary>
        public int? Lower { get; set; }

        /// <summary>
        /// Gets or sets the upper bound of the propety
        /// </summary>
        public int? Upper { get; set; }

        /// <summary>
        /// Gets or sets the complete path of the current property
        /// </summary>
        public string PathLiteral { get; set; }

        /// <summary>
        /// Gets or sets the next part of the property, if any
        /// </summary>
        public string NextPath { get; set; }

        /// <summary>
        /// Gets or sets the input from which the <see cref="PropertyDescriptor"/>
        /// has been created.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the next <see cref="PropertyDescriptor"/>
        /// </summary>
        public PropertyDescriptor Next { get; set; }

        /// <summary>
        /// Gets or sets the depth of the current <see cref="Input"/>
        /// </summary>
        public int Depth => this.GetDepth();

        /// <summary>
        /// Gets or sets the previous part of the property, if any
        /// </summary>
        public string PreviousPath { get; set; }

        /// <summary>
        /// Queries the <see cref="PropertyDescriptor"/> from the <paramref name="input"/>
        /// string. 
        /// </summary>
        /// <param name="input">
        /// The string that represents a property path
        /// </param>
        /// <param name="previous">The previous <see cref="PropertyDescriptor"/></param>
        /// <returns>
        /// an instance of <see cref="PropertyDescriptor"/>
        /// </returns>
        public static PropertyDescriptor QueryPropertyDescriptor(string input, PropertyDescriptor previous = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Contains("-"))
            {
                throw new ArgumentException("The input may not contain a hyphen or minus sign");
            }

            const string pattern = @"^(\w+)(?:\[(\d+)(?:\.\.(\d+|\*))?\])?";

            var match = Regex.Match(input, pattern);

            if (!match.Success)
            {
                return new PropertyDescriptor
                {
                    Name = input,
                    Lower = null,
                    Upper = null,
                    PathLiteral = input,
                    Input = input,
                    NextPath = string.Empty,
                    PreviousPath = previous?.PathLiteral ?? string.Empty,
                };
            }

            var name = match.Groups[1].Value;
            var lowerStr = match.Groups[2].Value;
            var upperStr = match.Groups[3].Value;
            var nextPath = input.Substring(match.Length).TrimStart('.');

            int? lower = null;

            if (!string.IsNullOrEmpty(lowerStr))
            {
                lower = int.TryParse(lowerStr, out var lowerValue) ? lowerValue : (int?)null;
            }

            int? upper;

            if (string.IsNullOrEmpty(upperStr))
            {
                upper = null;
            }
            else if (upperStr == "*")
            {
                upper = int.MaxValue;
            }
            else
            {
                upper = int.TryParse(upperStr, out var upperValue) ? upperValue : (int?)null;
            }

            if (lower.HasValue && !upper.HasValue)
            {
                throw new ArgumentException("when the lower bound is speficifed, so should the upper bound");
            }

            if (!lower.HasValue && upper.HasValue)
            {
                throw new ArgumentException("when the upper bound is speficifed, so should the lower bound");
            }

            if (lower.HasValue)
            {
                if (lower.Value < 0)
                {
                    throw new ArgumentException("The lower bound may not be less than zero");
                }

                if (upper.Value < lower.Value)
                {
                    throw new ArgumentException("The upper bound may not be less than the lower bound");
                }
            }

            var pathLiteral = name;

            if (!string.IsNullOrEmpty(lowerStr) && !string.IsNullOrEmpty(upperStr))
            {
                pathLiteral = $"{name}[{lowerStr}..{upperStr}]";
            }

            var propertyDescriptor = new PropertyDescriptor
            {
                Name = name,
                Lower = lower,
                Upper = upper,
                PathLiteral = pathLiteral,
                NextPath = nextPath,
                Input = input,
                PreviousPath = previous?.PathLiteral,
            };

            var next = !string.IsNullOrEmpty(nextPath)
                ? PropertyDescriptor.QueryPropertyDescriptor(nextPath, propertyDescriptor)
                : null;

            propertyDescriptor.Previous = previous;
            propertyDescriptor.Next = next;
            
            return propertyDescriptor;
        }

        /// <summary>
        /// Verifies whether the properties of the <see cref="PropertyDescriptor"/>
        /// are correct for a Value property with multiplicity [0..1] or [1..1]
        /// </summary>
        public void VerifyPropertyDescriptorForValueProperty()
        {
            if (this.Lower.HasValue || this.Upper.HasValue)
            {
                throw new ArgumentException($"Invalid Multiplicity for { this.Name } property");
            }

            if (!string.IsNullOrEmpty(this.NextPath))
            {
                throw new ArgumentException($"Invalid nesting for {this.Name} property");
            }
        }

        /// <summary>
        /// Verifies whether the properties of the <see cref="PropertyDescriptor"/>
        /// are correct for a Value property with multiplicity [0..*]
        /// </summary>
        public void VerifyPropertyDescriptorForEnumerableValueProperty()
        {
            if (!this.Lower.HasValue || !this.Upper.HasValue)
            {
                throw new ArgumentException($"Invalid Multiplicity for {this.Name} property, the lower and upper bound must be specified");
            }

            if (!string.IsNullOrEmpty(this.NextPath))
            {
	            throw new ArgumentException($"Invalid nesting for {this.Name} property");
            }
		}

        /// <summary>
        /// Verifies whether the properties of the <see cref="PropertyDescriptor"/>
        /// are correct for a Reference property with multiplicity [0..1] or [1..1]
        /// </summary>
        public void VerifyPropertyDescriptorForReferenceProperty()
        {
            if (this.Lower.HasValue && this.Upper.HasValue)
            {
                throw new ArgumentException($"Invalid Multiplicity for {this.Name} property");
            }
        }

        /// <summary>
        /// Verifies whether the properties of the <see cref="PropertyDescriptor"/>
        /// are correct for a Reference property with multiplicity [0..*]
        /// </summary>
        public void VerifyPropertyDescriptorForEnumerableReferenceProperty()
        {
            if (!this.Lower.HasValue || !this.Upper.HasValue)
            {
                throw new ArgumentException($"Invalid Multiplicity for {this.Name} property, the lower and upper bound must be specified");
            }
        }

        /// <summary>
        /// Gets or sets the previous <see cref="PropertyDescriptor"/>
        /// </summary>
        public PropertyDescriptor Previous { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PropertyDescriptor"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The <see cref="PropertyDescriptor"/> at the specified index.</returns>
        public PropertyDescriptor this[int index] => this.GetByIndex(index);

        /// <summary>
        /// Gets the <see cref="PropertyDescriptor"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The <see cref="PropertyDescriptor"/> at the specified index.</returns>
        private PropertyDescriptor GetByIndex(int index)
        {
            if (index >= 0)
            {
                var current = this;

                for (var nextIndex = 0; nextIndex < index; nextIndex++)
                {
                    if (current.Next == null)
                    {
                        return null;
                    }

                    current = current.Next;
                }

                return current;
            }
            else
            {
                var current = this;

                for (var previous = 0; previous > index; previous--)
                {
                    if (current.Previous == null)
                    {
                        return null;
                    }

                    current = current.Previous;
                }

                return current;
            }
        }

        /// <summary>
        /// Gets the depth of this property descriptor
        /// </summary>
        /// <returns>The computed depth</returns>
        private int GetDepth()
        {
            var depth = 0;
            var current = this;

            while (current != null)
            {
                depth++;
                current = current.Next;
            }

            return depth;
        }
    }
}
