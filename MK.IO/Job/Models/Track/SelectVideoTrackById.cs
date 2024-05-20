// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SelectVideoTrackById : TrackDiscriminator
    {
        public SelectVideoTrackById(int trackId)
        {
            TrackId = trackId;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonProperty(PropertyName = "@odata.type")]
        internal override string OdataType => "SelectVideoTrackById";

        /// <summary>
        /// Track indentifer to select
        /// </summary>
        /// <value>Track indentifer to select</value>
        [DataMember(Name = "trackId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackId")]
        public int? TrackId { get; set; }
    }
}
