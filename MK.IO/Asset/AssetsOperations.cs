// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
#if NET462
using System.Net.Http;
#endif

namespace MK.IO.Operations
{
    internal class AssetsOperations : IAssetsOperations
    {
        private const string _assetsApiUrl = MKIOClient._assetsApiUrl;
        private const string _assetApiUrl = _assetsApiUrl + "/{1}";
        private const string _assetListStreamingLocatorsApiUrl = _assetApiUrl + "/listStreamingLocators";
        private const string _assetListTracksAndDirectoryApiUrl = _assetApiUrl + "/storage/";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the AssetsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal AssetsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<AssetSchema> List(string? orderBy = null, string? filter = null, List<string>? label_key = null, List<string>? label = null, int? top = null)
        {
            Task<IEnumerable<AssetSchema>> task = Task.Run(async () => await ListAsync(orderBy, filter, label_key, label, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AssetSchema>> ListAsync(string? orderBy = null, string? filter = null, List<string>? label_key = null, List<string>? label = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<AssetSchema> objectsSchema = [];
            var objectsResult = await ListAsPageAsync(orderBy, filter, label_key, label, top, cancellationToken);
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
        public PagedResult<AssetSchema> ListAsPage(string? orderBy = null, string? filter = null, List<string>? label_key = null, List<string>? label = null, int? top = null)
        {
            Task<PagedResult<AssetSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, label_key, label, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AssetSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, List<string>? label_key = null, List<string>? label = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_assetsApiUrl);
            url = MKIOClient.AddParametersToUrl(url, "$label_key", label_key);
            url = MKIOClient.AddParametersToUrl(url, "$label", label);
            return await Client.ListAsPageGenericAsync<AssetSchema>(url, typeof(AssetListResponseSchema), "asset", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<AssetSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<AssetSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AssetSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<AssetSchema>(nextPageLink, typeof(AssetListResponseSchema), "asset", cancellationToken);
        }

        /// <inheritdoc/>
        public AssetSchema Get(string assetName)
        {
            return GetAsync(assetName).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AssetSchema> GetAsync(string assetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));

            var url = Client.GenerateApiUrl(_assetApiUrl, assetName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<AssetSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with asset deserialization");
        }

        /// <inheritdoc/>
        public AssetSchema CreateOrUpdate(string assetName, string containerName, string storageName, string? description = null, AssetContainerDeletionPolicyType containerDeletionPolicy = AssetContainerDeletionPolicyType.Retain, string? alternateId = null, Dictionary<string, string>? labels = null)
        {
            Task<AssetSchema> task = Task.Run(async () => await CreateOrUpdateAsync(assetName, containerName, storageName, description, containerDeletionPolicy, alternateId, labels));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AssetSchema> CreateOrUpdateAsync(string assetName, string containerName, string storageName, string? description = null, AssetContainerDeletionPolicyType containerDeletionPolicy = AssetContainerDeletionPolicyType.Retain, string? alternateId = null, Dictionary<string, string>? labels = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));
            Argument.AssertNotContainsSpace(assetName, nameof(assetName));
            Argument.AssertNotMoreThanLength(assetName, nameof(assetName), 260);
            Argument.AssertNotNullOrEmpty(containerName, nameof(containerName));
            Argument.AssertNotMoreThanLength(containerName, nameof(containerName), 63);
            Argument.AssertRespectRegex(containerName, nameof(containerName), @"^(?=.{3,63}$)[a-z0-9]+(-[a-z0-9]+)*$");
            Argument.AssertNotNullOrEmpty(storageName, nameof(storageName));

            var url = Client.GenerateApiUrl(_assetApiUrl, assetName);
            AssetSchema content = new()
            {
                Labels = labels!,
                Properties = new AssetProperties
                {
                    Container = containerName,
                    Description = description!,
                    StorageAccountName = storageName,
                    ContainerDeletionPolicy = containerDeletionPolicy,
                    AlternateId = alternateId!,
                }
            };

            string responseContent = await Client.CreateObjectPutAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
            return JsonConvert.DeserializeObject<AssetSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with asset deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string assetName)
        {
            Task.Run(async () => await DeleteAsync(assetName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string assetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));

            var url = Client.GenerateApiUrl(_assetApiUrl, assetName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }

        /// <inheritdoc/>
        public List<AssetStreamingLocator> ListStreamingLocators(string assetName)
        {
            Task<List<AssetStreamingLocator>> task = Task.Run(async () => await ListStreamingLocatorsAsync(assetName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<AssetStreamingLocator>> ListStreamingLocatorsAsync(string assetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));

            var url = Client.GenerateApiUrl(_assetListStreamingLocatorsApiUrl, assetName);
            string responseContent = await Client.GetObjectPostContentAsync(url, cancellationToken);
            return AssetListStreamingLocators.FromJson(responseContent).StreamingLocators;
        }

        /// <inheritdoc/>
        public AssetStorageResponseSchema ListTracksAndDirListing(string assetName)
        {
            var task = Task.Run(async () => await ListTracksAndDirListingAsync(assetName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AssetStorageResponseSchema> ListTracksAndDirListingAsync(string assetName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(assetName, nameof(assetName));

            var url = Client.GenerateApiUrl(_assetListTracksAndDirectoryApiUrl, assetName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<AssetStorageResponseSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with asset storage deserialization");
        }
    }
}
