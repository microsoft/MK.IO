// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class BlobStorageAzurePrivateConnection
    {
        /// <summary>
        /// A message passed to the owner of the remote resource with this connection request.
        /// </summary>
        /// <value>A message passed to the owner of the remote resource with this connection request.</value>
        public string RequestMessage { get; set; }

        /// <summary>
        /// The name of the resource group containing the storage account
        /// </summary>
        /// <value>The name of the resource group containing the storage account</value>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the storage account.  The full Azure ID should be /subscriptions/<subscriptionId>/resourceGroups/<resourceGroupName>/providers/Microsoft.Storage/storageAccounts/<storageAccountName>
        /// </summary>
        /// <value>The name of the storage account.  The full Azure ID should be /subscriptions/<subscriptionId>/resourceGroups/<resourceGroupName>/providers/Microsoft.Storage/storageAccounts/<storageAccountName></value>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// The ID of the Azure subscription containing the storage account
        /// </summary>
        /// <value>The ID of the Azure subscription containing the storage account</value>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlobStorageAzurePrivateConnection {\n");
            sb.Append("  RequestMessage: ").Append(RequestMessage).Append("\n");
            sb.Append("  ResourceGroupName: ").Append(ResourceGroupName).Append("\n");
            sb.Append("  StorageAccountName: ").Append(StorageAccountName).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
