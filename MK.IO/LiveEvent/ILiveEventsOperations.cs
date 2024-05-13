// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface ILiveEventsOperations
    {
        /// <summary>
        /// Returns a complete list of all live events.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<LiveEventSchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a complete list of all live events.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<LiveEventSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<LiveEventSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<LiveEventSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<LiveEventSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Returns a complete list of all live events using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<LiveEventSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a live event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        void Delete(string liveEventName);

        /// <summary>
        /// Delete a live event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string liveEventName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a live event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <returns></returns>
        LiveEventSchema Get(string liveEventName);

        /// <summary>
        /// Returns a live event.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<LiveEventSchema> GetAsync(string liveEventName, CancellationToken cancellationToken = default);

        /*
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <summary>
        /// NOT IMPLEMENTED. Update a live event
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="location">The location of the live event. This must match the configured location for your account.</param>
        /// <param name="properties">The properties of the live event.</param>
        /// <param name="tags">A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.</param>
        /// <returns></returns>
        [Obsolete]
        LiveEventSchema Update(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null);

        /// <summary>
        /// NOT IMPLEMENTED. Update a live event
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="location">The location of the live event. This must match the configured location for your account.</param>
        /// <param name="properties">The properties of the live event.</param>
        /// <param name="tags">A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
  /// <returns></returns>
        [Obsolete]
        Task<LiveEventSchema> UpdateAsync(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default);
#endif
        */

        /// <summary>
        /// Create a live event
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="location">The location of the live event. This must match the configured location for your account.</param>
        /// <param name="properties">The properties of the live event.</param>
        /// <param name="tags">A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.</param>
        /// <returns></returns>
        LiveEventSchema Create(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null);

        /// <summary>
        /// Create a live event
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="location">The location of the live event. This must match the configured location for your account.</param>
        /// <param name="properties">The properties of the live event.</param>
        /// <param name="tags">A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<LiveEventSchema> CreateAsync(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default);

        /*
        /// <summary>
        /// NOT IMPLEMENTED. Allocates resources for a Live Event. A live event is in StandBy state after allocation completes, and is ready to start.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        void Allocate(string liveEventName);

        /// <summary>
        /// NOT IMPLEMENTED. Allocates resources for a Live Event. A live event is in StandBy state after allocation completes, and is ready to start.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task AllocateAsync(string liveEventName, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// NOT IMPLEMENTED. Resets a Live Event. All live outputs for the live event are deleted and the live event is stopped and will be started again.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        void Reset(string liveEventName);

        /// <summary>
        /// NOT IMPLEMENTED. Resets a Live Event. All live outputs for the live event are deleted and the live event is stopped and will be started again.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <returns></returns>
        Task ResetAsync(string liveEventName, CancellationToken cancellationToken = default);
        */

        /// <summary>
        /// Start a Live Event. This operation transitions your Live Event into a running state
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        void Start(string liveEventName);

        /// <summary>
        /// Start a Live Event. This operation transitions your Live Event into a running state
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task StartAsync(string liveEventName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stops a Live Event. Any active playback sessions will be interrupted.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        void Stop(string liveEventName);

        /// <summary>
        /// Stops a Live Event. Any active playback sessions will be interrupted.
        /// </summary>
        /// <param name="liveEventName">The name of the live event.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task StopAsync(string liveEventName, CancellationToken cancellationToken = default);
    }
}