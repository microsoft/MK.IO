// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Represents an open restriction. License or key will be delivered on every request.
    /// </summary>
    public class ContentKeyPolicyOpenRestriction : ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyOpenRestriction()
        {
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyOpenRestriction";
    }
}
