// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;



namespace MK.IO.Models
{

    /// <summary>
    /// Configures the Play Right in the PlayReady license.
    /// </summary>

    public class ContentKeyPolicyPlayReadyPlayRight
    {
        /// <summary>
        /// Configures Automatic Gain Control (AGC) and Color Stripe in the license. Must be between 0 and 3 inclusive.
        /// </summary>
        /// <value>Configures Automatic Gain Control (AGC) and Color Stripe in the license. Must be between 0 and 3 inclusive.</value>
        public int? AgcAndColorStripeRestriction { get; set; }

        /// <summary>
        /// Configures Unknown output handling settings of the license.
        /// </summary>
        /// <value>Configures Unknown output handling settings of the license.</value>
        public AllowPassingVideoContentToUnknownOutput AllowPassingVideoContentToUnknownOutput { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital audio.</value>
        public int? AnalogVideoOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital audio.</value>
        public int? CompressedDigitalAudioOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for compressed digital video.
        /// </summary>
        /// <value>Specifies the output protection level for compressed digital video.</value>
        public int? CompressedDigitalVideoOpl { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        public bool? DigitalVideoOnlyContentRestriction { get; set; }

        /// <summary>
        /// Gets or Sets ExplicitAnalogTelevisionOutputRestriction
        /// </summary>
        public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction ExplicitAnalogTelevisionOutputRestriction { get; set; }

        /// <summary>
        /// The amount of time that the license is valid after the license is first used to play content.
        /// </summary>
        /// <value>The amount of time that the license is valid after the license is first used to play content.</value>
        public string FirstPlayExpiration { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        public bool? ImageConstraintForAnalogComponentVideoRestriction { get; set; }

        /// <summary>
        /// Enables the Image Constraint For Analog Component Video Restriction in the license.
        /// </summary>
        /// <value>Enables the Image Constraint For Analog Component Video Restriction in the license.</value>
        public bool? ImageConstraintForAnalogComputerMonitorRestriction { get; set; }

        /// <summary>
        /// Configures the Serial Copy Management System (SCMS) in the license. Must be between 0 and 3 inclusive.
        /// </summary>
        /// <value>Configures the Serial Copy Management System (SCMS) in the license. Must be between 0 and 3 inclusive.</value>
        public int? ScmsRestriction { get; set; }

        /// <summary>
        /// Specifies the output protection level for uncompressed digital audio.
        /// </summary>
        /// <value>Specifies the output protection level for uncompressed digital audio.</value>
        public int? UncompressedDigitalAudioOpl { get; set; }

        /// <summary>
        /// Specifies the output protection level for uncompressed digital video.
        /// </summary>
        /// <value>Specifies the output protection level for uncompressed digital video.</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
