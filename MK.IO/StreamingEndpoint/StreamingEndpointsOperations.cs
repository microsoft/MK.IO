// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using System.Net;
#if NET462
using System.Net.Http;
using System.Threading;
#endif

namespace MK.IO.Operations
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class StreamingEndpointsOperations : IStreamingEndpointsOperations
    {
        //
        // streaming endpoints
        //
        private const string _streamingEndpointsApiUrl = MKIOClient._streamingEndpointsApiUrl;
        private const string _streamingEndpointApiUrl = _streamingEndpointsApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the StreamingEndpointsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal StreamingEndpointsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<StreamingEndpointSchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<StreamingEndpointSchema>>(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StreamingEndpointSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<StreamingEndpointSchema> objectsSchema = [];
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
        public PagedResult<StreamingEndpointSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<StreamingEndpointSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingEndpointSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_streamingEndpointsApiUrl);
            return await Client.ListAsPageGenericAsync<StreamingEndpointSchema>(url, typeof(StreamingEndpointListResponseSchema), "streaming endpoint", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<StreamingEndpointSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<StreamingEndpointSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingEndpointSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<StreamingEndpointSchema>(nextPageLink, typeof(StreamingEndpointListResponseSchema), "streaming endpoint", cancellationToken);
        }

        /// <inheritdoc/>
        public StreamingEndpointSchema Get(string streamingEndpointName)
        {
            var task = Task.Run<StreamingEndpointSchema>(async () => await GetAsync(streamingEndpointName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingEndpointSchema> GetAsync(string streamingEndpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));

            var url = Client.GenerateApiUrl(_streamingEndpointApiUrl, streamingEndpointName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<StreamingEndpointSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming endpoint deserialization");
        }

#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <inheritdoc/>
        public StreamingEndpointSchema Update(string streamingEndpointName, string location, StreamingEndpointProperties properties, Dictionary<string, string>? tags = null)
        {
            var task = Task.Run<StreamingEndpointSchema>(async () => await UpdateAsync(streamingEndpointName, location, properties, tags));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingEndpointSchema> UpdateAsync(string streamingEndpointName, string location, StreamingEndpointProperties properties, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));
            Argument.AssertNotContainsSpace(streamingEndpointName, nameof(streamingEndpointName));
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_streamingEndpointApiUrl, streamingEndpointName);
            tags ??= new Dictionary<string, string>();
            var content = new StreamingEndpointSchema { Location = location, Properties = properties, Tags = tags };
            string responseContent = await Client.UpdateObjectPatchAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
            return JsonConvert.DeserializeObject<StreamingEndpointSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming endpoint deserialization");
        }
#endif

        /// <inheritdoc/>
        public StreamingEndpointSchema Create(string streamingEndpointName, string location, StreamingEndpointProperties properties, bool autoStart = false, Dictionary<string, string>? tags = null)
        {
            var task = Task.Run<StreamingEndpointSchema>(async () => await CreateAsync(streamingEndpointName, location, properties, autoStart, tags));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingEndpointSchema> CreateAsync(string streamingEndpointName, string location, StreamingEndpointProperties properties, bool autoStart = false, Dictionary<string, string>? tags = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));
            Argument.AssertNotContainsSpace(streamingEndpointName, nameof(streamingEndpointName));
            Argument.AssertNotMoreThanLength(streamingEndpointName, nameof(streamingEndpointName), 24);
            Argument.AssertRespectRegex(streamingEndpointName, nameof(streamingEndpointName), @"^[a-zA-Z0-9]+$");
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_streamingEndpointApiUrl + "?autoStart=" + autoStart.ToString(), streamingEndpointName);
            tags ??= new Dictionary<string, string>();
            var content = new StreamingEndpointSchema
            {
                Location = location,
                Properties = properties,
                Tags = tags
            };
            string responseContent = await Client.CreateObjectPutAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
            return JsonConvert.DeserializeObject<StreamingEndpointSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming endpoint deserialization");
        }

        /// <inheritdoc/>
        public void Scale(string streamingEndpointName, int scaleUnit)
        {
            Task.Run(async () => await ScaleAsync(streamingEndpointName, scaleUnit)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task ScaleAsync(string streamingEndpointName, int scaleUnit, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));
            var url = Client.GenerateApiUrl(_streamingEndpointApiUrl + "/scale", streamingEndpointName);
            var content = new StreamingEndpointScaleSchema { ScaleUnit = scaleUnit };
            await Client.CreateObjectPostAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
        }

        /// <inheritdoc/>
        public void Stop(string streamingEndpointName)
        {
            Task.Run(async () => await StopAsync(streamingEndpointName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task StopAsync(string streamingEndpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));

            await StreamingEndpointOperationAsync(streamingEndpointName, "stop", HttpMethod.Post, cancellationToken);
        }

        /// <inheritdoc/>
        public void Start(string streamingEndpointName)
        {
            Task.Run(async () => await StartAsync(streamingEndpointName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task StartAsync(string streamingEndpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));

            await StreamingEndpointOperationAsync(streamingEndpointName, "start", HttpMethod.Post, cancellationToken);
        }

        /// <inheritdoc/>
        public void Delete(string streamingEndpointName)
        {
            Task.Run(async () => await DeleteAsync(streamingEndpointName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string streamingEndpointName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingEndpointName, nameof(streamingEndpointName));

            await StreamingEndpointOperationAsync(streamingEndpointName, null, HttpMethod.Delete, cancellationToken);
        }

        private async Task StreamingEndpointOperationAsync(string streamingEndpointName, string? operation, HttpMethod httpMethod, CancellationToken cancellationToken)
        {
            var url = Client.GenerateApiUrl(_streamingEndpointApiUrl + (operation != null ? "/" + operation : string.Empty), streamingEndpointName);
            await Client.ObjectContentAsync(url, httpMethod, cancellationToken);
        }
    }
}