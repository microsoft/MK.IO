using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LiveEventEncoding
    {
        /// <summary>
        /// Live event type. When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output. When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers
        /// </summary>
        /// <value>Live event type. When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output. When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers</value>
        [DataMember(Name = "encodingType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "encodingType")]
        public LiveEventEncodingType EncodingType { get; set; }

        /// <summary>
        /// Use an ISO 8601 time value between 1 and 10 seconds to specify the output fragment length for the video and audio tracks of an encoding live event. For example, use PT2S to indicate 2 seconds. For the video track it also defines the key frame interval, or the length of a GoP (group of pictures). If this value is not set for an encoding live event, the fragment duration defaults to 2 seconds. The value cannot be set for pass-through live events.
        /// </summary>
        /// <value>Use an ISO 8601 time value between 1 and 10 seconds to specify the output fragment length for the video and audio tracks of an encoding live event. For example, use PT2S to indicate 2 seconds. For the video track it also defines the key frame interval, or the length of a GoP (group of pictures). If this value is not set for an encoding live event, the fragment duration defaults to 2 seconds. The value cannot be set for pass-through live events.</value>
        [DataMember(Name = "keyFrameInterval", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "keyFrameInterval")]
        public TimeSpan? KeyFrameInterval { get; set; }

        /// <summary>
        /// Defaults to either Default720p or Default1080p depending on encoding type. May be used to specify alternative encoding templates - contact support for assistance if your needs are complex.
        /// </summary>
        /// <value>Defaults to either Default720p or Default1080p depending on encoding type. May be used to specify alternative encoding templates - contact support for assistance if your needs are complex.</value>
        [DataMember(Name = "presetName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "presetName")]
        public string PresetName { get; set; }

        /// <summary>
        /// Determines how aspect ratio will be preserved when there is a mismatch between the input and output aspect ratios. Autofit to pad the output. Autosize to ignore the output ratio and pick the largest dimension that fits, and None to clip the content.
        /// </summary>
        /// <value>Determines how aspect ratio will be preserved when there is a mismatch between the input and output aspect ratios. Autofit to pad the output. Autosize to ignore the output ratio and pick the largest dimension that fits, and None to clip the content.</value>
        [DataMember(Name = "stretchMode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "stretchMode")]
        public LiveStretchModeType StretchMode { get; set; } = LiveStretchModeType.AutoSize;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventEncoding {\n");
            sb.Append("  EncodingType: ").Append(EncodingType).Append("\n");
            sb.Append("  KeyFrameInterval: ").Append(KeyFrameInterval).Append("\n");
            sb.Append("  PresetName: ").Append(PresetName).Append("\n");
            sb.Append("  StretchMode: ").Append(StretchMode).Append("\n");
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
