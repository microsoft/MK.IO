// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class LiveEventInput
    {
        /// <summary>
        /// Gets or Sets AccessControl
        /// </summary>
        public InputAccessControl AccessControl { get; set; }

        /// <summary>
        /// For RTMP, a UUID in string form to uniquely identify the stream.
        /// For SRT, an arbitrary string of between 10 and 79 characters, used as the passphrase.
        /// This can be specified at creation time but cannot be updated.
        /// If omitted or null, the service will generate a unique value.
        /// </summary>
        /// <value>For RTMP, a UUID in string form to uniquely identify the stream.
        /// For SRT, an arbitrary string of between 10 and 79 characters, used as the passphrase.
        /// This can be specified at creation time but cannot be updated.
        /// If omitted or null, the service will generate a unique value.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Populated server-side. The input endpoints for the live event.
        /// </summary>
        /// <value>Populated server-side. The input endpoints for the live event.</value>
        public List<LiveEventEndpoint> Endpoints { get; set; }

        /// <summary>
        /// ISO 8601 time duration of the key frame interval duration of the input. This value sets the EXT-X-TARGETDURATION property in the HLS output. For example, use PT2S to indicate 2 seconds. Leave the value empty for encoding live events.
        /// </summary>
        /// <value>ISO 8601 time duration of the key frame interval duration of the input. This value sets the EXT-X-TARGETDURATION property in the HLS output. For example, use PT2S to indicate 2 seconds. Leave the value empty for encoding live events.</value>
        public TimeSpan? KeyFrameIntervalDuration { get; set; }

        /// <summary>
        /// The input protocol for the live event.
        /// This is specified at creation time and cannot be updated.
        /// Must be one of RTMP or SRT. FragmentedMp4 is not supported.         
        /// </summary>
        /// <value>The input protocol for the live event.
        /// This is specified at creation time and cannot be updated.
        /// Must be one of RTMP or SRT. FragmentedMp4 is not supported.</value>
        public LiveEventInputProtocol StreamingProtocol { get; set; }

        /// <summary>
        /// The metadata endpoints for the live event.
        /// </summary>
        /// <value>The metadata endpoints for the live event.</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
