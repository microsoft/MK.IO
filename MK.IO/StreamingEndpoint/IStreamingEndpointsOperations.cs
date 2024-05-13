// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IStreamingEndpointsOperations
    {
        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<StreamingEndpointSchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<StreamingEndpointSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<StreamingEndpointSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingEndpointSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<StreamingEndpointSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Retrieves a list of Streaming Endpoints for the specified subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<StreamingEndpointSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a Streaming Endpoint. If the Streaming Endpoint does not exist, this API will return a 204.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        void Delete(string streamingEndpointName);

        /// <summary>
        /// Delete a Streaming Endpoint. If the Streaming Endpoint does not exist, this API will return a 204.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string streamingEndpointName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a single Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <returns></returns>
        StreamingEndpointSchema Get(string streamingEndpointName);

        /// <summary>
        /// Retrieves a single Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingEndpointSchema> GetAsync(string streamingEndpointName, CancellationToken cancellationToken = default);

#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <summary>
        /// Update a Streaming Endpoint.
        /// Only the Name and cdnProvider fields are immutable.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="location">The name of the location in which the Streaming Endpoint is located. This field must match the location in which the user's subscription is provisioned.</param>
        /// <param name="properties">The properties of the Streaming Endpoint.</param>
        /// <param name="tags">A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.</param>
        /// <returns></returns>
        StreamingEndpointSchema Update(string streamingEndpointName, string location, StreamingEndpointProperties properties, Dictionary<string, string>? tags = null);

        /// <summary>
        /// Update a Streaming Endpoint.
        /// Only the Name and cdnProvider fields are immutable.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="location">The name of the location in which the Streaming Endpoint is located. This field must match the location in which the user's subscription is provisioned.</param>
        /// <param name="properties">The properties of the Streaming Endpoint.</param>
        /// <param name="tags">A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingEndpointSchema> UpdateAsync(string streamingEndpointName, string location, StreamingEndpointProperties properties, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default);
#endif

        /// <summary>
        /// Create a Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="location">The name of the location in which the Streaming Endpoint is located. This field must match the location in which the user's subscription is provisioned.</param>
        /// <param name="properties">The properties of the Streaming Endpoint.</param>
        /// <param name="autoStart"></param>
        /// <param name="tags">A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.</param>
        /// <returns></returns>
        StreamingEndpointSchema Create(string streamingEndpointName, string location, StreamingEndpointProperties properties, bool autoStart = false, Dictionary<string, string>? tags = null);

        /// <summary>
        /// Create a Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="location">The name of the location in which the Streaming Endpoint is located. This field must match the location in which the user's subscription is provisioned.</param>
        /// <param name="properties">The properties of the Streaming Endpoint.</param>
        /// <param name="autoStart"></param>
        /// <param name="tags">A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StreamingEndpointSchema> CreateAsync(string streamingEndpointName, string location, StreamingEndpointProperties properties, bool autoStart = false, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Changes the scale of the Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="scaleUnit">The scale unit count for this Streaming Endpoint.</param>
        void Scale(string streamingEndpointName, int scaleUnit);

        /// <summary>
        /// Changes the scale of the Streaming Endpoint.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="scaleUnit">The scale unit count for this Streaming Endpoint.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task ScaleAsync(string streamingEndpointName, int scaleUnit, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start a Streaming Endpoint.
        /// This operation transitions your Streaming Endpoint into a running state.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        void Start(string streamingEndpointName);

        /// <summary>
        /// Start a Streaming Endpoint.
        /// This operation transitions your Streaming Endpoint into a running state.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task StartAsync(string streamingEndpointName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop a Streaming Endpoint. Any active playback sessions will be interrupted.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        void Stop(string streamingEndpointName);

        /// <summary>
        /// Stop a Streaming Endpoint. Any active playback sessions will be interrupted.
        /// </summary>
        /// <param name="streamingEndpointName">The name of the Streaming Endpoint.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task StopAsync(string streamingEndpointName, CancellationToken cancellationToken = default);
    }
}