using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LiveEventInput
    {
        /// <summary>
        /// Gets or Sets AccessControl
        /// </summary>
        [DataMember(Name = "accessControl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "accessControl")]
        public InputAccessControl AccessControl { get; set; }

        /// <summary>
        /// A UUID in string form to uniquely identify the stream.          This can be specified at creation time but cannot be updated.          If omitted or null, the service will generate a unique value.
        /// </summary>
        /// <value>A UUID in string form to uniquely identify the stream.          This can be specified at creation time but cannot be updated.          If omitted or null, the service will generate a unique value.</value>
        [DataMember(Name = "accessToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "accessToken")]
        public Guid? AccessToken { get; set; }

        /// <summary>
        /// Populated server-side. The input endpoints for the live event.
        /// </summary>
        /// <value>Populated server-side. The input endpoints for the live event.</value>
        [DataMember(Name = "endpoints", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endpoints")]
        public List<LiveEventEndpoint> Endpoints { get; set; }

        /// <summary>
        /// ISO 8601 time duration of the key frame interval duration of the input. This value sets the EXT-X-TARGETDURATION property in the HLS output. For example, use PT2S to indicate 2 seconds. Leave the value empty for encoding live events.
        /// </summary>
        /// <value>ISO 8601 time duration of the key frame interval duration of the input. This value sets the EXT-X-TARGETDURATION property in the HLS output. For example, use PT2S to indicate 2 seconds. Leave the value empty for encoding live events.</value>
        [DataMember(Name = "keyFrameIntervalDuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "keyFrameIntervalDuration")]
        public TimeSpan? KeyFrameIntervalDuration { get; set; }

        /// <summary>
        /// The input protocol for the live event.          This is specified at creation time and cannot be updated.         Must be one of RTMP or SRT. fmp4 smooth input is not supported.         
        /// </summary>
        /// <value>The input protocol for the live event.          This is specified at creation time and cannot be updated.         Must be one of RTMP or SRT. fmp4 smooth input is not supported.         </value>
        [DataMember(Name = "streamingProtocol", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "streamingProtocol")]
        public LiveEventInputProtocol StreamingProtocol { get; set; }

        /// <summary>
        /// The metadata endpoints for the live event.
        /// </summary>
        /// <value>The metadata endpoints for the live event.</value>
        [DataMember(Name = "timedMetadataEndpoints", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "timedMetadataEndpoints")]
        public List<LiveEventTimedMetadataEndpoint> TimedMetadataEndpoints { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventInput {\n");
            sb.Append("  AccessControl: ").Append(AccessControl).Append("\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  Endpoints: ").Append(Endpoints).Append("\n");
            sb.Append("  KeyFrameIntervalDuration: ").Append(KeyFrameIntervalDuration).Append("\n");
            sb.Append("  StreamingProtocol: ").Append(StreamingProtocol).Append("\n");
            sb.Append("  TimedMetadataEndpoints: ").Append(TimedMetadataEndpoints).Append("\n");
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
