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
    public class InputFile : InputFileDiscriminator
    {
        public InputFile(string filename, List<TrackDiscriminator> includedTracks)
        {
            Filename = filename;
            IncludedTracks = includedTracks;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonProperty(PropertyName = "@odata.type")]
        internal override string OdataType => "InputFile";

        /// <summary>
        /// Name of the file that this input definition applies to.
        /// </summary>
        /// <value>Name of the file that this input definition applies to.</value>
        [JsonProperty(PropertyName = "filename")]
        public string Filename { get; set; }

        /// <summary>
        /// The list of TrackDescriptors which define the metadata and selection of tracks in the input.
        /// </summary>
        /// <value>The list of TrackDescriptors which define the metadata and selection of tracks in the input.</value>
        [JsonProperty(PropertyName = "includedTracks")]
        public List<TrackDiscriminator> IncludedTracks { get; set; }
    }
}
