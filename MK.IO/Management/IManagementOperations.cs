// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Management
{
    public interface IManagementOperations
    {

        /// <summary>
        /// Allow a user to manage their personal account within MK.IO.
        /// </summary>
        IYourProfileOperations YourProfile { get; }
    }
}