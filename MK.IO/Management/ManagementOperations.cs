// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Management
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class ManagementOperations : IManagementOperations
    {
        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        internal ManagementOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            // Initialize properties
            YourProfile = new YourProfileOperations(Client);
        }

        /// <inheritdoc/>
        public virtual IYourProfileOperations YourProfile { get; private set; }

    }
}