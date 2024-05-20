// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// Configures the Play Right in the PlayReady license.
    /// </summary>
    [DataContract]
    public class ContentKeyPolicyPlayReadyPlayRight
    {
        /// <summary>
        /// Configures Automatic Gain Control (AGC) and Color Stripe in the license. Must be between 0 and 3 inclusive.
        /// </summary>
        /// <value>Configures Automatic Gain Control (AGC) and Color Stripe in the license. Must be between 0 and 3 inclusive.</value>
        [DataMember(Name = "agcAndColorStripeRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "agcAndColorStripeRestriction")]
        public int? AgcAndColorStripeRestriction { get; set; }

        /// <summary>
        /// Configures Unknown output handling settings of the license.
        /// </summary>
        /// <value>Configures Unknown output handling settings of the license.</value>
        [DataMember(Name = "allowPassingVideoContentToUnknownOutput", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "allowPassingVideoContentToUnknownOutput")]
        public AllowPassingVideoContentToUnknownOutput AllowPassingVideoContentToUnknownOutput { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital audio.</value>
        [DataMember(Name = "analogVideoOpl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "analogVideoOpl")]
        public int? AnalogVideoOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital audio.</value>
        [DataMember(Name = "compressedDigitalAudioOpl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "compressedDigitalAudioOpl")]
        public int? CompressedDigitalAudioOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital video.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital video.</value>
        [DataMember(Name = "compressedDigitalVideoOpl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "compressedDigitalVideoOpl")]
        public int? CompressedDigitalVideoOpl { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        [DataMember(Name = "digitalVideoOnlyContentRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "digitalVideoOnlyContentRestriction")]
        public bool? DigitalVideoOnlyContentRestriction { get; set; }

        /// <summary>
        /// Gets or Sets ExplicitAnalogTelevisionOutputRestriction
        /// </summary>
        [DataMember(Name = "explicitAnalogTelevisionOutputRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "explicitAnalogTelevisionOutputRestriction")]
        public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction ExplicitAnalogTelevisionOutputRestriction { get; set; }

        /// <summary>
        /// The amount of time that the license is valid after the license is first used to play content.
        /// </summary>
        /// <value>The amount of time that the license is valid after the license is first used to play content.</value>
        [DataMember(Name = "firstPlayExpiration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "firstPlayExpiration")]
        public string FirstPlayExpiration { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        [DataMember(Name = "imageConstraintForAnalogComponentVideoRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "imageConstraintForAnalogComponentVideoRestriction")]
        public bool? ImageConstraintForAnalogComponentVideoRestriction { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        [DataMember(Name = "imageConstraintForAnalogComputerMonitorRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "imageConstraintForAnalogComputerMonitorRestriction")]
        public bool? ImageConstraintForAnalogComputerMonitorRestriction { get; set; }

        /// <summary>
        /// Configures the Serial Copy Management System (SCMS) in the license. Must be between 0 and 3 inclusive.
        /// </summary>
        /// <value>Configures the Serial Copy Management System (SCMS) in the license. Must be between 0 and 3 inclusive.</value>
        [DataMember(Name = "scmsRestriction", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scmsRestriction")]
        public int? ScmsRestriction { get; set; }

        /// <summary>
        /// Specifies the output protection level for uncompressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for uncompressed digital audio.</value>
        [DataMember(Name = "uncompressedDigitalAudioOpl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "uncompressedDigitalAudioOpl")]
        public int? UncompressedDigitalAudioOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for uncompressed digital video.
        /// </summary>
        /// <value>Specifies the output protection level for uncompressed digital video.</value>
        [DataMember(Name = "uncompressedDigitalVideoOpl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "uncompressedDigitalVideoOpl")]
        public int? UncompressedDigitalVideoOpl { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyPlayReadyPlayRight {\n");
            sb.Append("  AgcAndColorStripeRestriction: ").Append(AgcAndColorStripeRestriction).Append("\n");
            sb.Append("  AllowPassingVideoContentToUnknownOutput: ").Append(AllowPassingVideoContentToUnknownOutput).Append("\n");
            sb.Append("  AnalogVideoOpl: ").Append(AnalogVideoOpl).Append("\n");
            sb.Append("  CompressedDigitalAudioOpl: ").Append(CompressedDigitalAudioOpl).Append("\n");
            sb.Append("  CompressedDigitalVideoOpl: ").Append(CompressedDigitalVideoOpl).Append("\n");
            sb.Append("  DigitalVideoOnlyContentRestriction: ").Append(DigitalVideoOnlyContentRestriction).Append("\n");
            sb.Append("  ExplicitAnalogTelevisionOutputRestriction: ").Append(ExplicitAnalogTelevisionOutputRestriction).Append("\n");
            sb.Append("  FirstPlayExpiration: ").Append(FirstPlayExpiration).Append("\n");
            sb.Append("  ImageConstraintForAnalogComponentVideoRestriction: ").Append(ImageConstraintForAnalogComponentVideoRestriction).Append("\n");
            sb.Append("  ImageConstraintForAnalogComputerMonitorRestriction: ").Append(ImageConstraintForAnalogComputerMonitorRestriction).Append("\n");
            sb.Append("  ScmsRestriction: ").Append(ScmsRestriction).Append("\n");
            sb.Append("  UncompressedDigitalAudioOpl: ").Append(UncompressedDigitalAudioOpl).Append("\n");
            sb.Append("  UncompressedDigitalVideoOpl: ").Append(UncompressedDigitalVideoOpl).Append("\n");
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
