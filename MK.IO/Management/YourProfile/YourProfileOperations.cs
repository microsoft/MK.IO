// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Management.Models;
using Newtonsoft.Json;
#if NET462
using System.Net.Http;
#endif

namespace MK.IO.Management
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class YourProfileOperations : IYourProfileOperations
    {
        //
        // subscription operations
        //
        private const string _yourProfileProfileApiUrl = "api/v1/user/profile";
        private const string _yourProfileOrganizationsApiUrl = "api/v1/user/organizations";
        private const string _yourProfileTokensApiUrl = "api/v1/user/tokens";
        private const string _yourProfileTokenApiUrl = _yourProfileTokensApiUrl+ "/{0}";


        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the SubscriptionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal YourProfileOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public UserProfileSpecV1 GetProfile()
        {
            var task = Task.Run(async () => await GetProfileAsync());
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<UserProfileSpecV1> GetProfileAsync(CancellationToken cancellationToken = default)
        {
            string responseContent = await Client.GetObjectContentAsync(Client._baseUrl + _yourProfileProfileApiUrl, cancellationToken);
            return ProfileGetSchemaV1.FromJson(responseContent).Spec;
        }

        /// <inheritdoc/>
        public List<UserOrganizationSchema> ListOrganizations()
        {
            var task = Task.Run(async () => await ListOrganizationsAsync());
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<UserOrganizationSchema>> ListOrganizationsAsync(CancellationToken cancellationToken = default)
        {
            string responseContent = await Client.GetObjectContentAsync(Client._baseUrl + _yourProfileOrganizationsApiUrl, cancellationToken);
            return UserOrganizationsListSchema.FromJson(responseContent).Value;
        }

        /// <inheritdoc/>
        public UserTokenSchema GetToken(Guid tokenId)
        {
            var task = Task.Run(async () => await GetTokenAsync(tokenId));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<UserTokenSchema> GetTokenAsync(Guid tokenId, CancellationToken cancellationToken = default)
        {
            var url = string.Format(Client._baseUrl + _yourProfileTokenApiUrl, tokenId.ToString());
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return UserTokenSchema.FromJson(responseContent);
        }

        /// <inheritdoc/>
        public List<UserTokenSchema> ListTokens()
        {
            var task = Task.Run(async () => await ListTokensAsync());
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<List<UserTokenSchema>> ListTokensAsync(CancellationToken cancellationToken = default)
        {
            string responseContent = await Client.GetObjectContentAsync(Client._baseUrl + _yourProfileTokensApiUrl, cancellationToken);
            return UserTokenListSchema.FromJson(responseContent).Value;
        }

        /// <inheritdoc/>
        public UserTokenWithSecretSchema RequestNewToken(CreateTokenSchema tokenRequest)
        {
            var task = Task.Run(async () => await RequestNewTokenAsync(tokenRequest));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<UserTokenWithSecretSchema> RequestNewTokenAsync(CreateTokenSchema tokenRequest, CancellationToken cancellationToken = default)
        {
            string responseContent = await Client.CreateObjectPostAsync(Client._baseUrl + _yourProfileTokensApiUrl, tokenRequest.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<UserTokenWithSecretSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with UserTokenWithSecretSchema deserialization");
        }

        /// <inheritdoc/>
        public void RevokeAllTokens()
        {
            var task = Task.Run(async () => await RevokeAllTokensAsync());
            task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task RevokeAllTokensAsync(CancellationToken cancellationToken = default)
        {
            await Client.ObjectContentAsync(Client._baseUrl + _yourProfileTokensApiUrl, HttpMethod.Delete, cancellationToken);
        }
    }
}