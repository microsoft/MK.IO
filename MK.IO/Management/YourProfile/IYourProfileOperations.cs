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

        /// <summary>
        /// Request a new token granting access to the MK.IO API. There are three types of tokens.
        /// 'restricted' tokens can have an expireDate set to up to a year in the future grant a reduced set of capabilities.Please see our online documentation for a description of how the capabilities are defined.
        /// 'login' tokens are short-lived and grant the full user capabilities.
        /// 'full-access' tokens can have an expireDate set to up to a year in the future and grant the full user capabilities.
        /// Where possible you should prefer 'restricted' tokens over 'full-access' tokens to reduce the impact if one is exposed accidentally.
        /// An API token allows access to MK.IO to anyone who has a copy of it - you should treat these like your car keys and keep them safe.
        /// </summary>
        /// <returns></returns>
        UserTokenSchema RequestNewToken(CreateTokenSchema tokenRequest);

        /// <summary>
        /// Request a new token granting access to the MK.IO API. There are three types of tokens.
        /// 'restricted' tokens can have an expireDate set to up to a year in the future grant a reduced set of capabilities.Please see our online documentation for a description of how the capabilities are defined.
        /// 'login' tokens are short-lived and grant the full user capabilities.
        /// 'full-access' tokens can have an expireDate set to up to a year in the future and grant the full user capabilities.
        /// Where possible you should prefer 'restricted' tokens over 'full-access' tokens to reduce the impact if one is exposed accidentally.
        /// An API token allows access to MK.IO to anyone who has a copy of it - you should treat these like your car keys and keep them safe.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<UserTokenSchema> RequestNewTokenAsync(CreateTokenSchema tokenRequest, CancellationToken cancellationToken = default);
    }
}