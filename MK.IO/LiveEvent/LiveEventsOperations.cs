// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using System.Net;
#if NET462
using System.Net.Http;
#endif
namespace MK.IO.Operations
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class LiveEventsOperations : ILiveEventsOperations
    {
        //
        // live events
        //
        private const string _liveEventsApiUrl = MKIOClient._liveEventsApiUrl;
        private const string _liveEventApiUrl = _liveEventsApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the LiveEventsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal LiveEventsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<LiveEventSchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<LiveEventSchema>>(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LiveEventSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<LiveEventSchema> objectsSchema = [];
            var objectsResult = await ListAsPageAsync(orderBy, filter, top, cancellationToken);
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                objectsSchema.AddRange(objectsResult.Results);
                if (objectsResult.NextPageLink == null || (top != null && objectsSchema.Count >= top)) break;
                objectsResult = await ListAsPageNextAsync(objectsResult.NextPageLink, cancellationToken);
            }

            if (top != null && top < objectsSchema.Count)
            {
                return objectsSchema.Take((int)top);
            }

            return objectsSchema;
        }

        /// <inheritdoc/>
        public PagedResult<LiveEventSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<LiveEventSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<LiveEventSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_liveEventsApiUrl);
            return await Client.ListAsPageGenericAsync<LiveEventSchema>(url, typeof(LiveEventListResponseSchema), "live event", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<LiveEventSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<LiveEventSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<LiveEventSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<LiveEventSchema>(nextPageLink, typeof(LiveEventListResponseSchema), "live event", cancellationToken);
        }

        /// <inheritdoc/>
        public LiveEventSchema Get(string liveEventName)
        {
            var task = Task.Run<LiveEventSchema>(async () => await GetAsync(liveEventName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveEventSchema> GetAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            var url = Client.GenerateApiUrl(_liveEventApiUrl, liveEventName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<LiveEventSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with live event deserialization");
        }

        /*
#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <inheritdoc/>
        public LiveEventSchema Update(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null)
        {
            var task = Task.Run<LiveEventSchema>(async () => await UpdateAsync(liveEventName, location, properties, tags));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveEventSchema> UpdateAsync(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));
            Argument.AssertNotContainsSpace(liveEventName, nameof(liveEventName));
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(properties, nameof(properties));

            return await CreateOrUpdateAsync(liveEventName, location, properties, tags, Client.UpdateObjectPatchAsync, cancellationToken);
        }
#endif
        */

        /// <inheritdoc/>
        public LiveEventSchema Create(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags = null)
        {
            var task = Task.Run<LiveEventSchema>(async () => await CreateAsync(liveEventName, location, properties, tags));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveEventSchema> CreateAsync(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));
            Argument.AssertNotContainsSpace(liveEventName, nameof(liveEventName));
            Argument.AssertNotMoreThanLength(liveEventName, nameof(liveEventName), 260);
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(properties, nameof(properties));

            return await CreateOrUpdateAsync(liveEventName, location, properties, tags, Client.CreateObjectPutAsync, cancellationToken);
        }

        internal async Task<LiveEventSchema> CreateOrUpdateAsync(string liveEventName, string location, LiveEventProperties properties, Dictionary<string, string>? tags, Func<string, string, CancellationToken, Task<string>> func, CancellationToken cancellationToken)
        {
            var url = Client.GenerateApiUrl(_liveEventApiUrl, liveEventName);
            tags ??= new Dictionary<string, string>();
            var content = new LiveEventSchema { Location = location, Tags = tags, Properties = properties };
            string responseContent = await func(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<LiveEventSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with live event deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string liveEventName)
        {
            Task.Run(async () => await DeleteAsync(liveEventName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            var url = Client.GenerateApiUrl(_liveEventApiUrl, liveEventName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }

        /// <inheritdoc/>
        public void Start(string liveEventName)
        {
            Task.Run(async () => await StartAsync(liveEventName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task StartAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            await LiveEventOperationAsync(liveEventName, "start", HttpMethod.Post, cancellationToken);
        }

        public void Stop(string liveEventName)
        {
            Task.Run(async () => await StopAsync(liveEventName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task StopAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            await LiveEventOperationAsync(liveEventName, "stop", HttpMethod.Post, cancellationToken);
        }

        /*
        /// <inheritdoc/>
        public void Reset(string liveEventName)
        {
            Task.Run(async () => await ResetAsync(liveEventName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task ResetAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            await LiveEventOperationAsync(liveEventName, "reset", HttpMethod.Post, cancellationToken);
        }
        
        /// <inheritdoc/>
        public void Allocate(string liveEventName)
        {
            Task.Run(async () => await AllocateAsync(liveEventName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task AllocateAsync(string liveEventName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));

            await LiveEventOperationAsync(liveEventName, "allocate", HttpMethod.Post, cancellationToken);
        }
        */

        private async Task LiveEventOperationAsync(string liveEventName, string? operation, HttpMethod httpMethod, CancellationToken cancellationToken)
        {
            var url = Client.GenerateApiUrl(_liveEventApiUrl + (operation != null ? "/" + operation : string.Empty), liveEventName);
            await Client.ObjectContentAsync(url, httpMethod, cancellationToken);
        }
    }
}