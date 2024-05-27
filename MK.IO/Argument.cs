// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace MK.IO
{
    internal class Argument
    {
        /// <summary>
        /// Asserts that the value is not null or empty.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertNotNullOrEmpty(string value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }

            if (value.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", name);
            }
        }

        /// <summary>
        /// Asserts that the value is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AssertNotNull<T>(T value, string name)
        {
            if (value is null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Asserts that the value does not contain space.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertNotContainsSpace(string? value, string name)
        {
            if (value != null && value.Contains(' '))
            {
                throw new ArgumentException("Value cannot contain space.", name);
            }
        }

        /// <summary>
        /// Asserts that the value does not have a length higher than the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertNotMoreThanLength(string? value, string name, int length)
        {
            if (value != null && value.Length > length)
            {
                throw new ArgumentException($"Value length cannot exceed {length}.", name);
            }
        }

        /// <summary>
        /// Assert that value is conform to regex pattern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="regexPattern"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertRespectRegex(string? value, string name, string regexPattern)
        {
            // check if value respects regex pattern
            if (value != null && !Regex.IsMatch(value, regexPattern))
            {
                throw new ArgumentException($"Value does not respect regex pattern {regexPattern}.", name);
            }
        }
    }
}