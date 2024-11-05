// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class FromEachInputFile : InputFileDiscriminator
    {
        public FromEachInputFile(List<TrackDiscriminator> includedTracks)
        {
            IncludedTracks = includedTracks;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [DataMember(Name = "@odata.type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "@odata.type")]
        internal override string OdataType => "FromEachInputFile";

        /// <summary>
        /// The list of TrackDescriptors which define the metadata and selection of tracks in the input.
        /// </summary>
        /// <value>The list of TrackDescriptors which define the metadata and selection of tracks in the input.</value>
        [DataMember(Name = "includedTracks", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "includedTracks")]
        public List<TrackDiscriminator> IncludedTracks { get; set; }
    }
}
