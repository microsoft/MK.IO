﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.IdentityModel.JsonWebTokens;
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
        /// Asserts that the value does not have a length lower than the specified value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertNotLessThanLength(string? value, string name, int length)
        {
            if (value != null && value.Length < length)
            {
                throw new ArgumentException($"Value length cannot be less than {length}.", name);
            }
        }

        /// <summary>
        /// Assert that value is conform to regex pattern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="regexPattern"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertRespectRegex(string? value, string name, string regexPattern, string? tip = null)
        {
            // check if value respects regex pattern
            if (value != null && !Regex.IsMatch(value, regexPattern))
            {
                throw new ArgumentException($"Value does not respect regex pattern {regexPattern}." + tip != null ? System.Environment.NewLine + tip : "", name);
            }
        }

        /// <summary>
        /// Assert that value is a JWT token.
        /// </summary>
        /// <param name="authToken"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void AssertJwtToken(string authToken, string name)
        {
            var jsonWebTokenHandler = new JsonWebTokenHandler();
            if (!jsonWebTokenHandler.CanReadToken(authToken))
            {
                throw new ArgumentException("Value is not a JWT Token. Please read https://docs.mk.io/docs/personal-access-tokens to learn how to generate a personal access token.", name);
            }
        }

        internal static void AssertTagsNullOrCompliant(Dictionary<string, string>? tags, int maxNumber, int maxLength)
        {
            if (tags != null)
            {
                if (tags.Count > maxNumber)
                {
                    throw new ArgumentException($"Tags are limited to {maxNumber} entries.");
                }

                foreach (var tag in tags)
                {
                    AssertNotMoreThanLength(tag.Key, "tag.Key", maxLength);
                    AssertNotMoreThanLength(tag.Value, "tag.Value", maxLength);
                }
            }
        }
    }
}