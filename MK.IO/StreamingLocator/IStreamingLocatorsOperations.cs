// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IStreamingLocatorsOperations
    {
        /// <summary>
        /// Returns a list of Streaming Locators for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<StreamingLocatorSchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of Streaming Locators for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<StreamingLocatorSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of Streaming Locators for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<StreamingLocatorSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of Streaming Locators for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingLocatorSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of Streaming Locators for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<StreamingLocatorSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Returns a list of Streaming Locators for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingLocatorSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a Streaming Locator.
        /// If the Streaming Locator does not exist, a 204 is returned same as if it does.
        /// Once the Streaming Locator is deleted, all future requests to the path owned by the Streaming Locator will fail. If content is
        /// cached in a CDN, playback may continue to work for some time until the cached content expires.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// /// <returns></returns>
        void Delete(string streamingLocatorName);

        /// <summary>
        /// Delete a Streaming Locator.
        /// If the Streaming Locator does not exist, a 204 is returned same as if it does.
        /// Once the Streaming Locator is deleted, all future requests to the path owned by the Streaming Locator will fail. If content is
        /// cached in a CDN, playback may continue to work for some time until the cached content expires.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string streamingLocatorName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Streaming Locator by name.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <returns></returns>
        StreamingLocatorSchema Get(string streamingLocatorName);

        /// <summary>
        /// Get a Streaming Locator by name.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingLocatorSchema> GetAsync(string streamingLocatorName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a Streaming Locator.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <param name="properties">Properties for Streaming Locator</param>
        /// <returns></returns>
        StreamingLocatorSchema Create(string streamingLocatorName, StreamingLocatorProperties properties);

        /// <summary>
        /// Create a Streaming Locator.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <param name="properties">Properties for Streaming Locator</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingLocatorSchema> CreateAsync(string streamingLocatorName, StreamingLocatorProperties properties, CancellationToken cancellationToken = default);

        /// <summary>
        /// ListPaths returns the set of valid streaming paths for a given Streaming Locator. A distinct set of paths
        /// is returned for each type of DRM configured, per the 'EnabledProtocols' property of the streaming policy.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <returns></returns>
        StreamingLocatorListPathsResponseSchema ListUrlPaths(string streamingLocatorName);

        /// <summary>
        /// ListPaths returns the set of valid streaming paths for a given Streaming Locator. A distinct set of paths
        /// is returned for each type of DRM configured, per the 'EnabledProtocols' property of the streaming policy.
        /// </summary>
        /// <param name="streamingLocatorName">The name of the Streaming Locator.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingLocatorListPathsResponseSchema> ListUrlPathsAsync(string streamingLocatorName, CancellationToken cancellationToken = default);
    }
}