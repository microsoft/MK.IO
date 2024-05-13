// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IStreamingPoliciesOperations
    {
        /// <summary>
        /// Returns a list of Streaming Policies for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<StreamingPolicySchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of Streaming Policies for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<StreamingPolicySchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of Streaming Policies for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<StreamingPolicySchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of Streaming Policies for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingPolicySchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of Streaming Policies for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<StreamingPolicySchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Returns a list of Streaming Policies for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingPolicySchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a Streaming Policy.
        /// If the policy does not exist, this will return a 204.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <returns></returns>
        void Delete(string streamingPolicyName);

        /// <summary>
        /// Delete a Streaming Policy.
        /// If the policy does not exist, this will return a 204.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string streamingPolicyName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Streaming Policy by name.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <returns></returns>
        StreamingPolicySchema Get(string streamingPolicyName);

        /// <summary>
        /// Get a Streaming Policy by name.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingPolicySchema> GetAsync(string streamingPolicyName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a Streaming Policy.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <param name="properties">Properties for Streaming Policy</param>
        /// <returns></returns>
        StreamingPolicySchema Create(string streamingPolicyName, StreamingPolicyProperties properties);

        /// <summary>
        /// Create a Streaming Policy.
        /// </summary>
        /// <param name="streamingPolicyName">The name of the Streaming Policy.</param>
        /// <param name="properties">Properties for Streaming Policy</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingPolicySchema> CreateAsync(string streamingPolicyName, StreamingPolicyProperties properties, CancellationToken cancellationToken = default);
    }
}