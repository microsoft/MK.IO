// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader), "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier), "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier")]

    //
    // Summary:
    //     Base class for PlayReady content key location. A derived class must be used
    //     to specify a location.
    public class PlayReadyContentKeyLocation
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
