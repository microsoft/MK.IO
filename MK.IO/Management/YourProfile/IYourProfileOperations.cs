// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Management.Models;

namespace MK.IO.Management
{
    public interface IYourProfileOperations
    {

        /// <summary>
        /// Get current user profile information.
        /// </summary>
        /// <returns></returns>
        UserProfileSpecV1 GetProfile();

        /// <summary>
        /// Get current user profile information.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<UserProfileSpecV1> GetProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List user's organizations and any associated invitation.
        /// </summary>
        /// <returns></returns>
        List<UserOrganizationSchema> ListOrganizations();

        /// <summary>
        /// List user's organizations and any associated invitation.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<List<UserOrganizationSchema>> ListOrganizationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all non-expired API tokens issued to the current user.
        /// </summary>
        /// <returns></returns>
        List<UserTokenSchema> ListTokens();

        /// <summary>
        /// Get all non-expired API tokens issued to the current user.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<List<UserTokenSchema>> ListTokensAsync(CancellationToken cancellationToken = default);
    }
}