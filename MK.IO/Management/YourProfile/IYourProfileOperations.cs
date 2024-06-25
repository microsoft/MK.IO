// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Models;
using MK.IO.Management.Models;

namespace MK.IO.Management
{
    public interface IYourProfileOperations
    {

        /// <summary>
        /// Get current user profile information.
        /// </summary>
        /// <returns></returns>
        UserProfileSpecV1 Get();

        /// <summary>
        /// Get current user profile information.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<UserProfileSpecV1> GetAsync(CancellationToken cancellationToken = default);
    }
}