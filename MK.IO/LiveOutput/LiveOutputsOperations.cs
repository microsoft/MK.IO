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
    internal class LiveOutputsOperations : ILiveOutputsOperations
    {
        //
        // live outputs
        //
        private const string _liveOutputsApiUrl = MKIOClient._liveEventsApiUrl + "/{1}/liveOutputs";
        private const string _liveOutputApiUrl = _liveOutputsApiUrl + "/{2}";

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
        internal LiveOutputsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<LiveOutputSchema> List(string liveEventName, string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<LiveOutputSchema>>(async () => await ListAsync(liveEventName, orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LiveOutputSchema>> ListAsync(string liveEventName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<LiveOutputSchema> objectsSchema = [];
            var objectsResult = await ListAsPageAsync(liveEventName, orderBy, filter, top, cancellationToken);
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
        public PagedResult<LiveOutputSchema> ListAsPage(string liveEventName, string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<LiveOutputSchema>> task = Task.Run(async () => await ListAsPageAsync(liveEventName, orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<LiveOutputSchema>> ListAsPageAsync(string liveEventName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {

            var url = Client.GenerateApiUrl(_liveOutputsApiUrl, liveEventName);
            return await Client.ListAsPageGenericAsync<LiveOutputSchema>(url, typeof(LiveOutputListResponseSchema), "live output", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<LiveOutputSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<LiveOutputSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<LiveOutputSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<LiveOutputSchema>(nextPageLink, typeof(LiveOutputListResponseSchema), "live output", cancellationToken);
        }

        /// <inheritdoc/>
        public LiveOutputSchema Get(string liveEventName, string liveOutputName)
        {
            var task = Task.Run<LiveOutputSchema>(async () => await GetAsync(liveEventName, liveOutputName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveOutputSchema> GetAsync(string liveEventName, string liveOutputName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));
            Argument.AssertNotNullOrEmpty(liveOutputName, nameof(liveOutputName));

            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName, liveOutputName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<LiveOutputSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with live output deserialization");
        }

        /// <inheritdoc/>
        public LiveOutputSchema Create(string liveEventName, string liveOutputName, LiveOutputProperties properties)
        {
            var task = Task.Run<LiveOutputSchema>(async () => await CreateAsync(liveEventName, liveOutputName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<LiveOutputSchema> CreateAsync(string liveEventName, string liveOutputName, LiveOutputProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));
            Argument.AssertNotNullOrEmpty(liveOutputName, nameof(liveOutputName));
            Argument.AssertNotMoreThanLength(liveOutputName, nameof(liveOutputName), 260);
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName, liveOutputName);
            //tags ??= new Dictionary<string, string>();
            var content = new LiveOutputSchema { Properties = properties };
            string responseContent = await Client.CreateObjectPutAsync(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<LiveOutputSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with live output deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string liveEventName, string liveOutputName)
        {
            Task.Run(async () => await DeleteAsync(liveEventName, liveOutputName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string liveEventName, string liveOutputName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(liveEventName, nameof(liveEventName));
            Argument.AssertNotNullOrEmpty(liveOutputName, nameof(liveOutputName));

            var url = Client.GenerateApiUrl(_liveOutputApiUrl, liveEventName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}