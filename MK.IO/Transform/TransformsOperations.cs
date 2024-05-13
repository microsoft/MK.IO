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
    internal class TransformsOperations : ITransformsOperations
    {
        //
        // transforms
        //

        private const string _transformsApiUrl = MKIOClient._transformsApiUrl;
        private const string _transformApiUrl = _transformsApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the TransformsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal TransformsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<TransformSchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<TransformSchema>>(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransformSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<TransformSchema> objectsSchema = [];
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
        public PagedResult<TransformSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<TransformSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<TransformSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_transformsApiUrl);
            url = MKIOClient.AddParametersToUrl(url, "$orderby", orderBy);
            url = MKIOClient.AddParametersToUrl(url, "$filter", filter);
            url = MKIOClient.AddParametersToUrl(url, "$top", top != null ? ((int)top).ToString() : null);

            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);

            dynamic responseObject = JsonConvert.DeserializeObject(responseContent);
            string? nextPageLink = responseObject["@odata.nextLink"];

            var objectToReturn = JsonConvert.DeserializeObject<TransformListResponseSchema>(responseContent, ConverterLE.Settings);
            if (objectToReturn == null)
            {
                throw new Exception($"Error with streaming policy list deserialization");
            }
            else
            {
                return new PagedResult<TransformSchema>
                {
                    NextPageLink = WebUtility.UrlDecode(nextPageLink),
                    Results = objectToReturn.Value
                };
            }
        }

        /// <inheritdoc/>
        public PagedResult<TransformSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<TransformSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<TransformSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<TransformSchema> (nextPageLink, typeof(TransformListResponseSchema), "transform", cancellationToken);
        }

        /// <inheritdoc/>
        public TransformSchema Get(string transformName)
        {
            var task = Task.Run<TransformSchema>(async () => await GetAsync(transformName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<TransformSchema> GetAsync(string transformName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));

            var url = Client.GenerateApiUrl(_transformApiUrl, transformName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<TransformSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with transform deserialization");
        }

        /// <inheritdoc/>
        public TransformSchema CreateOrUpdate(string transformName, TransformProperties properties)
        {
            var task = Task.Run<TransformSchema>(async () => await CreateOrUpdateAsync(transformName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<TransformSchema> CreateOrUpdateAsync(string transformName, TransformProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotContainsSpace(transformName, nameof(transformName));
            Argument.AssertNotMoreThanLength(transformName, nameof(transformName), 260);
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_transformApiUrl, transformName);
            var content = new TransformSchema { Properties = properties };
            string responseContent = await Client.CreateObjectPutAsync(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<TransformSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with transform deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string transformName)
        {
            Task.Run(async () => await DeleteAsync(transformName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string transformName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));

            var url = Client.GenerateApiUrl(_transformApiUrl, transformName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}