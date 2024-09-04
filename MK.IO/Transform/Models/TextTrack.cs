// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{
    public class TextTrack : TrackInserter
    {
        /// <summary>
        /// The discriminator for derived types. Must be set to #MediaKind.TextTrack
        /// </summary>
        /// <value>The discriminator for derived types. Must be set to #MediaKind.TextTrack</value>
        [JsonProperty("@odata.type")]
        internal override string OdataType => "#MediaKind.TextTrack";

        /// <summary>
        /// The display name of the track on a video player. In HLS, this maps to the NAME attribute of EXT-X-MEDIA.
        /// </summary>
        /// <value>The display name of the track on a video player. In HLS, this maps to the NAME attribute of EXT-X-MEDIA.</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets HlsSettings
        /// </summary>
        [DataMember(Name = "hlsSettings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hlsSettings")]
        public HlsSettings HlsSettings { get; set; }

        /// <summary>
        /// The RFC5646 language code for the track.
        /// </summary>
        /// <value>The RFC5646 language code for the track.</value>
        [DataMember(Name = "languageCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// When PlayerVisibility is set to 'Visible', the track will be present in the DASH manifest or HLS playlist when requested by a client. When the PlayerVisibility is set to 'Hidden', the track will not be available to the client. The default value is 'Visible'.
        /// </summary>
        /// <value>When PlayerVisibility is set to 'Visible', the track will be present in the DASH manifest or HLS playlist when requested by a client. When the PlayerVisibility is set to 'Hidden', the track will not be available to the client. The default value is 'Visible'.</value>
        [DataMember(Name = "playerVisibility", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "playerVisibility")]
        public TextTrackPlayerVisibility PlayerVisibility { get; set; } = TextTrackPlayerVisibility.Visible;

        /// <summary>
        /// The name of the track in the manifest.
        /// </summary>
        /// <value>The name of the track in the manifest.</value>
        [DataMember(Name = "trackName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackName")]
        public string TrackName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TextTrack {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  HlsSettings: ").Append(HlsSettings).Append("\n");
            sb.Append("  LanguageCode: ").Append(LanguageCode).Append("\n");
            sb.Append("  PlayerVisibility: ").Append(PlayerVisibility).Append("\n");
            sb.Append("  TrackName: ").Append(TrackName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }



        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }
    }
}