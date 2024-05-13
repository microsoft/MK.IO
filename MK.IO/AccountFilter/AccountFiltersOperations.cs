// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using System.Net;
#if NET462
using System.Net.Http;
using System.Reflection.Emit;
#endif

namespace MK.IO.Operations
{
    internal class AccountFiltersOperations : IAccountFiltersOperations
    {
        private const string _accountFiltersApiUrl = MKIOClient._accountFiltersApiUrl;
        private const string _accountFilterApiUrl = _accountFiltersApiUrl + "/{1}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the AccountFiltersOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal AccountFiltersOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<AccountFilterSchema> List(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<IEnumerable<AccountFilterSchema>> task = Task.Run(async () => await ListAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<AccountFilterSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<AccountFilterSchema> objectsSchema = [];
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
        public PagedResult<AccountFilterSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<AccountFilterSchema>> task = Task.Run(async () => await ListAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AccountFilterSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_accountFiltersApiUrl);
            return await Client.ListAsPageGenericAsync<AccountFilterSchema>(url, typeof(AccountFilterListResponseSchema), "account filter", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<AccountFilterSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<AccountFilterSchema>> task = Task.Run(async () => await ListAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<AccountFilterSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<AccountFilterSchema>(nextPageLink, typeof(AccountFilterListResponseSchema), "account filter", cancellationToken);
        }

        /// <inheritdoc/>
        public AccountFilterSchema Get(string accountFilterName)
        {
            return GetAsync(accountFilterName).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AccountFilterSchema> GetAsync(string accountFilterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountFilterName, nameof(accountFilterName));

            var url = Client.GenerateApiUrl(_accountFilterApiUrl, accountFilterName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<AccountFilterSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with account filter deserialization");
        }

        /// <inheritdoc/>
        public AccountFilterSchema CreateOrUpdate(string accountFilterName, MediaFilterProperties properties)
        {
            Task<AccountFilterSchema> task = Task.Run(async () => await CreateOrUpdateAsync(accountFilterName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<AccountFilterSchema> CreateOrUpdateAsync(string accountFilterName, MediaFilterProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountFilterName, nameof(accountFilterName));
            Argument.AssertNotContainsSpace(accountFilterName, nameof(accountFilterName));
            Argument.AssertNotMoreThanLength(accountFilterName, nameof(accountFilterName), 260);
            Argument.AssertRespectRegex(accountFilterName, nameof(accountFilterName), @"^[a-zA-Z0-9\-_.~]+$");
            Argument.AssertNotNull(properties, nameof(properties));

            var url = Client.GenerateApiUrl(_accountFilterApiUrl, accountFilterName);
            AccountFilterSchema content = new()
            {
                //Name = accountFilterName,
                Properties = properties
            };

            string responseContent = await Client.CreateObjectPutAsync(url, JsonConvert.SerializeObject(content, ConverterLE.Settings), cancellationToken);
            return JsonConvert.DeserializeObject<AccountFilterSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with account filter deserialization");
        }

        /// <inheritdoc/>
        public void Delete(string accountFilterName)
        {
            Task.Run(async () => await DeleteAsync(accountFilterName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string accountFilterName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountFilterName, nameof(accountFilterName));

            var url = Client.GenerateApiUrl(_accountFilterApiUrl, accountFilterName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}
