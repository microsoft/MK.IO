// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IAccountOperations
    {
        /// <summary>
        /// Get statistics for the current MK.IO subscription.
        /// </summary>
        /// <returns></returns>
        AccountStats GetSubscriptionStats();

        /// <summary>
        /// Get statistics for the current MK.IO subscription.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<AccountStats> GetSubscriptionStatsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get user profile information.
        /// </summary>
        /// <returns></returns>
        UserInfo GetUserProfile();

        /// <summary>
        /// Get user profile information.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<UserInfo> GetUserProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the list of all MK.IO subscriptions for the account.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SubscriptionResponseSchema> ListAllSubscriptions();

        /// <summary>
        /// Get the list of all MK.IO subscriptions for the account.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<SubscriptionResponseSchema>> ListAllSubscriptionsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get the current MK.IO subscription.
        /// </summary>
        /// <returns></returns>
        SubscriptionResponseSchema GetSubscription();

        /// <summary>
        /// Get the current MK.IO subscription.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<SubscriptionResponseSchema> GetSubscriptionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List all possible locations for MK.IO (Ids and names).
        /// </summary>
        /// <returns></returns>
        IEnumerable<LocationResponseSchema> ListAllLocations();

        /// <summary>
        /// List all possible locations for MK.IO (Ids and names).
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<LocationResponseSchema>> ListAllLocationsAsync(CancellationToken cancellationToken = default);
    }
}