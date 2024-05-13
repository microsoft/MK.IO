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
    internal class StreamingPoliciesOperations : IStreamingPoliciesOperations
    {
        //
        // streaming policies
        //
        private const string _streamingPoliciesApiUrl = MKIOClient._streamingPoliciesApiUrl;
        private const string _streamingPolicyApiUrl = _streamingPoliciesApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the StreamingPoliciesOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal StreamingPoliciesOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<StreamingPolicySchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StreamingPolicySchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<StreamingPolicySchema> objectsSchema = [];
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
        public PagedResult<StreamingPolicySchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<StreamingPolicySchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingPolicySchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_streamingPoliciesApiUrl);
            return await Client.ListAsPageGenericAsync<StreamingPolicySchema>(url, typeof(StreamingPolicyListResponseSchema), "streaming policy", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<StreamingPolicySchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<StreamingPolicySchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<StreamingPolicySchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<StreamingPolicySchema>(nextPageLink, typeof(StreamingPolicyListResponseSchema), "streaming policy", cancellationToken);
        }

        /// <inheritdoc/>
        public StreamingPolicySchema Get(string streamingPolicyName)
        {
            var task = Task.Run(async () => await GetAsync(streamingPolicyName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingPolicySchema> GetAsync(string streamingPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingPolicyName, nameof(streamingPolicyName));

            var url = Client.GenerateApiUrl(_streamingPolicyApiUrl, streamingPolicyName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<StreamingPolicySchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming policy deserialization");
        }

        /// <inheritdoc/>
        public StreamingPolicySchema Create(string streamingPolicyName, StreamingPolicyProperties properties)
        {
            var task = Task.Run(async () => await CreateAsync(streamingPolicyName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<StreamingPolicySchema> CreateAsync(string streamingPolicyName, StreamingPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingPolicyName, nameof(streamingPolicyName));
            Argument.AssertNotMoreThanLength(streamingPolicyName, nameof(streamingPolicyName), 260);
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_streamingPolicyApiUrl, streamingPolicyName);
            var content = new StreamingPolicySchema { Properties = properties };
            string responseContent = await Client.CreateObjectPutAsync(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<StreamingPolicySchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with streaming policy deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string streamingPolicyName)
        {
            Task.Run(async () => await DeleteAsync(streamingPolicyName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string streamingPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(streamingPolicyName, nameof(streamingPolicyName));

            var url = Client.GenerateApiUrl(_streamingPolicyApiUrl, streamingPolicyName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}