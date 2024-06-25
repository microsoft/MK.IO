// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Models;
using MK.IO.Management.Models;

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