# Sample for storage operations with MK.IO SDK

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("yourMKIOSubscriptionName", "yourMKIOPersonalAPIToken");

// *******************
// storage operations
// *******************

// Creation
var storage = client.StorageAccounts.Create(new StorageSchema
            {
                Name = "amsxpfrstorage",
                Location = "francecentral",
                Description = "my description",
                AzureStorageConfiguration = new BlobStorageAzureProperties
                {
                    Url = "https://insertyoursasuri"
                }
            }
            );

// List
var storages = client.StorageAccounts.List();

// Get
var storage2 = client.StorageAccounts.Get((Guid)storages.First().Metadata.Id);

// Delete
client.StorageAccounts.Delete((Guid)storages.First().Metadata.Id);

// List credentials of a storage
var credentials = client.StorageAccounts.ListCredentials((Guid)storages.First().Metadata.Id);

// Get specific credential
var credential = client.StorageAccounts.GetCredential((Guid)storages.First().Metadata.Id, (Guid)credentials.First().Metadata.Id);

```
