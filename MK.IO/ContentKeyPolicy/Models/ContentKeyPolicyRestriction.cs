// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyTokenRestriction), "#Microsoft.Media.ContentKeyPolicyTokenRestriction")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyOpenRestriction), "#Microsoft.Media.ContentKeyPolicyOpenRestriction")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyUnknownRestriction), "#Microsoft.Media.ContentKeyPolicyUnknownRestriction")]

    //
    // Summary:
    //     Base class for Content Key Policy restrictions. A derived class must be used
    //     to create a restriction.
    public class ContentKeyPolicyRestriction
    {

        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
