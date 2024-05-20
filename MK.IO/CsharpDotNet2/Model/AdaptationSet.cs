// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AdaptationSet
    {
        /// <summary>
        /// Gets or Sets Accessibility
        /// </summary>
        [DataMember(Name = "accessibility", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "accessibility")]
        public List<Accessibility> Accessibility { get; set; }

        /// <summary>
        /// Gets or Sets ContentType
        /// </summary>
        [DataMember(Name = "contentType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets MaxFrameRate
        /// </summary>
        [DataMember(Name = "maxFrameRate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxFrameRate")]
        public string MaxFrameRate { get; set; }

        /// <summary>
        /// Gets or Sets MaxHeight
        /// </summary>
        [DataMember(Name = "maxHeight", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxHeight")]
        public string MaxHeight { get; set; }

        /// <summary>
        /// Gets or Sets MaxWidth
        /// </summary>
        [DataMember(Name = "maxWidth", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxWidth")]
        public string MaxWidth { get; set; }

        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [DataMember(Name = "mimeType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets Par
        /// </summary>
        [DataMember(Name = "par", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "par")]
        public string Par { get; set; }

        /// <summary>
        /// Gets or Sets Representation
        /// </summary>
        [DataMember(Name = "representation", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "representation")]
        public List<Representation> Representation { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "role")]
        public List<Role> Role { get; set; }

        /// <summary>
        /// Gets or Sets SegmentAlignment
        /// </summary>
        [DataMember(Name = "segmentAlignment", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "segmentAlignment")]
        public string SegmentAlignment { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AdaptationSet {\n");
            sb.Append("  Accessibility: ").Append(Accessibility).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MaxFrameRate: ").Append(MaxFrameRate).Append("\n");
            sb.Append("  MaxHeight: ").Append(MaxHeight).Append("\n");
            sb.Append("  MaxWidth: ").Append(MaxWidth).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Par: ").Append(Par).Append("\n");
            sb.Append("  Representation: ").Append(Representation).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  SegmentAlignment: ").Append(SegmentAlignment).Append("\n");
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
