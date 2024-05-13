// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET462
using System.Net.Http;
#endif
using MK.IO.Models;
using Newtonsoft.Json;
using System.Net;

namespace MK.IO.Operations
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class ContentKeyPoliciesOperations : IContentKeyPoliciesOperations
    {
        //
        // content key policy
        //
        private const string _contentKeyPoliciesApiUrl = MKIOClient._contentKeyPoliciesApiUrl;
        private const string _contentKeyPolicyApiUrl = _contentKeyPoliciesApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the ContentKeyPoliciesOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal ContentKeyPoliciesOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<ContentKeyPolicySchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<IEnumerable<ContentKeyPolicySchema>> task = Task.Run(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ContentKeyPolicySchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<ContentKeyPolicySchema> objectsSchema = [];
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
        public PagedResult<ContentKeyPolicySchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<ContentKeyPolicySchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<ContentKeyPolicySchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_contentKeyPoliciesApiUrl);
            return await Client.ListAsPageGenericAsync<ContentKeyPolicySchema>(url, typeof(ContentKeyPolicyListResponseSchema), "content key", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<ContentKeyPolicySchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<ContentKeyPolicySchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<ContentKeyPolicySchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<ContentKeyPolicySchema>(nextPageLink, typeof(ContentKeyPolicyListResponseSchema), "content key", cancellationToken);
        }

        /// <inheritdoc/>
        public ContentKeyPolicySchema Get(string contentKeyPolicyName)
        {
            Task<ContentKeyPolicySchema> task = Task.Run(async () => await GetAsync(contentKeyPolicyName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<ContentKeyPolicySchema> GetAsync(string contentKeyPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentKeyPolicyName, nameof(contentKeyPolicyName));

            var url = Client.GenerateApiUrl(_contentKeyPolicyApiUrl, contentKeyPolicyName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<ContentKeyPolicySchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with content key policy deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string contentKeyPolicyName)
        {
            Task.Run(async () => await DeleteAsync(contentKeyPolicyName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string contentKeyPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentKeyPolicyName, nameof(contentKeyPolicyName));

            var url = Client.GenerateApiUrl(_contentKeyPolicyApiUrl, contentKeyPolicyName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }

        /// <inheritdoc/>
        public ContentKeyPolicySchema Create(string contentKeyPolicyName, ContentKeyPolicyProperties properties)
        {
            Task<ContentKeyPolicySchema> task = Task.Run(async () => await CreateAsync(contentKeyPolicyName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<ContentKeyPolicySchema> CreateAsync(string contentKeyPolicyName, ContentKeyPolicyProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentKeyPolicyName, nameof(contentKeyPolicyName));
            Argument.AssertNotContainsSpace(contentKeyPolicyName, nameof(contentKeyPolicyName));
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_contentKeyPolicyApiUrl, contentKeyPolicyName);
            var content = new ContentKeyPolicySchema { Properties = properties };
            string responseContent = await Client.CreateObjectPutAsync(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<ContentKeyPolicySchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with content key policy deserialization");
        }

        /// <inheritdoc/>
        public ContentKeyPolicyProperties GetPolicyPropertiesWithSecrets(string contentKeyPolicyName)
        {
            Task<ContentKeyPolicyProperties> task = Task.Run(async () => await GetPolicyPropertiesWithSecretsAsync(contentKeyPolicyName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<ContentKeyPolicyProperties> GetPolicyPropertiesWithSecretsAsync(string contentKeyPolicyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(contentKeyPolicyName, nameof(contentKeyPolicyName));

            var url = Client.GenerateApiUrl(_contentKeyPolicyApiUrl + "/getPolicyPropertiesWithSecrets", contentKeyPolicyName);
            string responseContent = await Client.GetObjectPostContentAsync(url, cancellationToken);
            //return ContentKeyPolicy.FromJson(responseContent).Properties;
            return JsonConvert.DeserializeObject<ContentKeyPolicySchema>(responseContent, ConverterLE.Settings).Properties ?? throw new Exception("Error with content key policy deserialization");
        }
    }
}