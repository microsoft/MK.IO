// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// When PlayerVisibility is set to 'Visible', the track will be present in the DASH manifest or HLS playlist when requested by a client. When the PlayerVisibility is set to 'Hidden', the track will not be available to the client. The default value is 'Visible'.
    /// </summary>
    /// <value>When PlayerVisibility is set to 'Visible', the track will be present in the DASH manifest or HLS playlist when requested by a client. When the PlayerVisibility is set to 'Hidden', the track will not be available to the client. The default value is 'Visible'.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackInserterPresetTextTrackPlayerVisibility
    {
        [EnumMember(Value = "Visible")]
        Visible,

        [EnumMember(Value = "Hidden")]
        Hidden
    }
}