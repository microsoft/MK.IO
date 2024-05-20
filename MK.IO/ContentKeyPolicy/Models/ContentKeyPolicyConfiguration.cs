// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyPlayReadyConfiguration), "#Microsoft.Media.ContentKeyPolicyPlayReadyConfiguration")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyWidevineConfiguration), "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyFairPlayConfiguration), "#Microsoft.Media.ContentKeyPolicyFairPlayConfiguration")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyClearKeyConfiguration), "#Microsoft.Media.ContentKeyPolicyClearKeyConfiguration")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyUnknownConfiguration), "#Microsoft.Media.ContentKeyPolicyUnknownConfiguration")]

    //
    // Summary:
    //     Base class for Content Key Policy configuration. A derived class must be used
    //     to create a configuration.
    public class ContentKeyPolicyConfiguration
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}