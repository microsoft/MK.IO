// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Management.Models;

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
        private const string _accountProfileApiUrl = "api/v1/user/profile";

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
        public UserProfileSpecV1 Get()
        {
            var task = Task.Run(async () => await GetAsync());
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<UserProfileSpecV1> GetAsync(CancellationToken cancellationToken = default)
        {
            string responseContent = await Client.GetObjectContentAsync(Client._baseUrl + _accountProfileApiUrl, cancellationToken);
            return ProfileGetSchemaV1.FromJson(responseContent).Spec;
        }
    }
}