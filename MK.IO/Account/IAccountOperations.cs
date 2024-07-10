// Copyright (c) Microsoft Corporation.
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
        /// Get subscription usage information for current month.
        /// </summary>
        /// <returns></returns>
        SubscriptionMeterUsageListResponseSchema GetSubscriptionUsage();

        /// <summary>
        /// Get subscription usage information for current month.
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<SubscriptionMeterUsageListResponseSchema> GetSubscriptionUsageAsync(CancellationToken cancellationToken = default);

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

        /// <summary>
        /// Get the location of the MK.IO subscription.
        /// </summary>
        /// <returns>Location entity</returns>
        LocationMetadataSchema? GetSubscriptionLocation();

        /// <summary>
        /// Get the location of the MK.IO subscription.
        /// </summary>
        /// <returns>Location metadata.</returns>
        Task<LocationMetadataSchema?> GetSubscriptionLocationAsync();
    }
}