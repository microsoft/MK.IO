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
    internal class AssetFiltersOperations : IAssetFiltersOperations
    {
        private const string _assetsApiUrl = MKIOClient._assetsApiUrl;
        private const string _assetApiUrl = _assetsApiUrl + "/{1}";
        private const string _assetFiltersApiUrl = _assetApiUrl + "/assetFilters";
        private const string _assetFilterApiUrl = _assetApiUrl + "/filters/{2}";


        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the AssetFiltersOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal AssetFiltersOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<AssetFilterSchema> List(string assetName, string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<IEnumerable<AssetFilterSchema>> task = Task.Run(async () => await ListAsync(assetName, orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AssetFilterSchema>> ListAsync(string assetName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));

            List<AssetFilterSchema> objectsSchema = [];
            var objectsResult = await ListAsPageAsync(assetName, orderBy, filter, top, cancellationToken);
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
        public PagedResult<AssetFilterSchema> ListAsPage(string assetName, string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<AssetFilterSchema>> task = Task.Run(async () => await ListAsPageAsync(assetName, orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AssetFilterSchema>> ListAsPageAsync(string assetName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_assetFiltersApiUrl, assetName);
            return await Client.ListAsPageGenericAsync<AssetFilterSchema>(url, typeof(AssetFilterListResponseSchema), "asset filter", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<AssetFilterSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<AssetFilterSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AssetFilterSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<AssetFilterSchema>(nextPageLink, typeof(AssetFilterListResponseSchema), "asset filter", cancellationToken);
        }

        /// <inheritdoc/>
        public AssetFilterSchema Get(string assetName, string filterName)
        {
            return GetAsync(assetName, filterName).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AssetFilterSchema> GetAsync(string assetName, string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            var url = Client.GenerateApiUrl(_assetFilterApiUrl, assetName, filterName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<AssetFilterSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with asset filter deserialization");
        }

        /// <inheritdoc/>
        public AssetFilterSchema CreateOrUpdate(string assetName, string filterName, MediaFilterProperties properties)
        {
            Task<AssetFilterSchema> task = Task.Run(async () => await CreateOrUpdateAsync(assetName, filterName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AssetFilterSchema> CreateOrUpdateAsync(string assetName, string filterName, MediaFilterProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));
            Argument.AssertNotContainsSpace(filterName, nameof(filterName));
            Argument.AssertNotMoreThanLength(filterName, nameof(filterName), 260);
            Argument.AssertRespectRegex(filterName, nameof(filterName), @"^[a-zA-Z0-9\-_.~]+$");
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_assetFilterApiUrl, assetName, filterName);
            AssetFilterSchema content = new()
            {
                Properties = properties
            };

            string responseContent = await Client.CreateObjectPutAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
            return JsonConvert.DeserializeObject<AssetFilterSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with asset filter deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string assetName, string filterName)
        {
            Task.Run(async () => await DeleteAsync(assetName, filterName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string assetName, string filterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));
            Argument.AssertNotNullOrEmpty(filterName, nameof(filterName));

            var url = Client.GenerateApiUrl(_assetFilterApiUrl, assetName, filterName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}
