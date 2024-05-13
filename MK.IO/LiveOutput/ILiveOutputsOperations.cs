// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface ILiveOutputsOperations
    {
        /// <summary>
        /// Returns a list of Live Outputs for a Live Event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<LiveOutputSchema> List(string liveEventName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of Live Outputs for a Live Event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<LiveOutputSchema>> ListAsync(string liveEventName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<LiveOutputSchema> ListAsPage(string liveEventName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<LiveOutputSchema>> ListAsPageAsync(string liveEventName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<LiveOutputSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<LiveOutputSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a Live Output.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        void Delete(string liveEventName, string liveOutputName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string liveEventName, string liveOutputName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single Live Output.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        /// <returns></returns>
        LiveOutputSchema Get(string liveEventName, string liveOutputName);

        /// <summary>
        /// Returns a single Live Output.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<LiveOutputSchema> GetAsync(string liveEventName, string liveOutputName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a Live Output
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        /// <param name="properties">The properties of the live output.</param>
        /// <returns></returns>
        LiveOutputSchema Create(string liveEventName, string liveOutputName, LiveOutputProperties properties);

        /// <summary>
        /// Creates a Live Output
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="liveOutputName">The name of the live output.</param>
        /// <param name="properties">The properties of the live output.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<LiveOutputSchema> CreateAsync(string liveEventName, string liveOutputName, LiveOutputProperties properties, CancellationToken cancellationToken = default);
    }
}