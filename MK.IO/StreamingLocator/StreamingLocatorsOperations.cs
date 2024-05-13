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
    internal class StreamingLocatorsOperations : IStreamingLocatorsOperations
    {
        //
        // streaming locators
        //
        private const string _streamingLocatorsApiUrl = MKIOClient._streamingLocatorsApiUrl;
        private const string _streamingLocatorApiUrl = _streamingLocatorsApiUrl + "/{1}";
        private const string _streamingLocatorListPathsApiUrl = _streamingLocatorApiUrl + "/listPaths";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the StreamingLocatorsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal StreamingLocatorsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<StreamingLocatorSchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StreamingLocatorSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<StreamingLocatorSchema> objectsSchema = [];
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

        public PagedResult<StreamingLocatorSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<StreamingLocatorSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingLocatorSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_streamingLocatorsApiUrl);
            return await Client.ListAsPageGenericAsync<StreamingLocatorSchema>(url, typeof(StreamingLocatorListResponseSchema), "streaming locator", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<StreamingLocatorSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<StreamingLocatorSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingLocatorSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<StreamingLocatorSchema>(nextPageLink, typeof(StreamingLocatorListResponseSchema), "streaming locator", cancellationToken);
        }

        /// <inheritdoc/>
        public StreamingLocatorSchema Get(string streamingLocatorName)
        {
            var task = Task.Run(async () => await GetAsync(streamingLocatorName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingLocatorSchema> GetAsync(string streamingLocatorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingLocatorName, nameof(streamingLocatorName));

            var url = Client.GenerateApiUrl(_streamingLocatorApiUrl, streamingLocatorName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<StreamingLocatorSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming locator deserialization");
        }

        /// <inheritdoc/>
        public StreamingLocatorSchema Create(string streamingLocatorName, StreamingLocatorProperties properties)
        {
            var task = Task.Run(async () => await CreateAsync(streamingLocatorName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingLocatorSchema> CreateAsync(string streamingLocatorName, StreamingLocatorProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingLocatorName, nameof(streamingLocatorName));
            Argument.AssertNotMoreThanLength(streamingLocatorName, nameof(streamingLocatorName), 260);
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_streamingLocatorApiUrl, streamingLocatorName);
            var content = new StreamingLocatorSchema { Properties = properties };
            string responseContent = await Client.CreateObjectPutAsync(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<StreamingLocatorSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming locator deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string streamingLocatorName)
        {
            Task.Run(async () => await DeleteAsync(streamingLocatorName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string streamingLocatorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingLocatorName, nameof(streamingLocatorName));

            var url = Client.GenerateApiUrl(_streamingLocatorApiUrl, streamingLocatorName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }

        /// <inheritdoc/>
        public StreamingLocatorListPathsResponseSchema ListUrlPaths(string streamingLocatorName)
        {
            var task = Task.Run(async () => await ListUrlPathsAsync(streamingLocatorName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingLocatorListPathsResponseSchema> ListUrlPathsAsync(string streamingLocatorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingLocatorName, nameof(streamingLocatorName));

            var url = Client.GenerateApiUrl(_streamingLocatorListPathsApiUrl, streamingLocatorName);
            string responseContent = await Client.ObjectContentAsync(url, HttpMethod.Post, cancellationToken);
            return JsonConvert.DeserializeObject<StreamingLocatorListPathsResponseSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming locator list paths deserialization");
        }
    }
}