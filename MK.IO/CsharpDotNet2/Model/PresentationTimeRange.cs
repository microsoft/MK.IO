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
    public class PresentationTimeRange
    {
        /// <summary>
        /// For VOD content only. Indicates the end of the presentation window, in units of timescale. Given a timescale of \"1\", a value of \"N\" set here will constrain the          video manifest to contain exactly \"N\" seconds of content. This value is relative to the actual start of the content, not the startTimestamp.                   Examples:         timescale=1, startTimestamp=0, endTimestamp=10: The first 10 seconds of content will be included in the output.         timescale=1, startTimestamp=10, endTimestamp=70: The 60 seconds of content starting at 10 seconds will be included in the output.         timescale=10000000, startTimestamp=0, endTimestamp=100000000: The first 10 seconds of content will be included in the output.          In cases where the endTimestamp does not perfectly align with a segment boundary, the endTimestamp will be rounded down to the nearest segment boundary.         
        /// </summary>
        /// <value>For VOD content only. Indicates the end of the presentation window, in units of timescale. Given a timescale of \"1\", a value of \"N\" set here will constrain the          video manifest to contain exactly \"N\" seconds of content. This value is relative to the actual start of the content, not the startTimestamp.                   Examples:         timescale=1, startTimestamp=0, endTimestamp=10: The first 10 seconds of content will be included in the output.         timescale=1, startTimestamp=10, endTimestamp=70: The 60 seconds of content starting at 10 seconds will be included in the output.         timescale=10000000, startTimestamp=0, endTimestamp=100000000: The first 10 seconds of content will be included in the output.          In cases where the endTimestamp does not perfectly align with a segment boundary, the endTimestamp will be rounded down to the nearest segment boundary.         </value>
        [DataMember(Name = "endTimestamp", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endTimestamp")]
        public int? EndTimestamp { get; set; }

        /// <summary>
        /// A validation parameter. When set, requires that the filter endTimestamp be set. This might be useful to limit the duration of an locator          associated with a long-running live event, once the live event has ended and the video manifest is closed.         
        /// </summary>
        /// <value>A validation parameter. When set, requires that the filter endTimestamp be set. This might be useful to limit the duration of an locator          associated with a long-running live event, once the live event has ended and the video manifest is closed.         </value>
        [DataMember(Name = "forceEndTimestamp", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "forceEndTimestamp")]
        public bool? ForceEndTimestamp { get; set; }

        /// <summary>
        /// For live content only. Truncates content from the head of a live video manifest by the specified duration. In effect, setting this value         creates a buffer between the client and the true live point by omitting content from the head of a manifest. This is a useful capability in cases where          CDN latency and other \"network realities\" make it difficult to deliver a true live experience, and result in content being presented in the manifest that          is not yet available in caches.                   For example, if you set this value to 30 seconds, the client will see a manifest that is 30 seconds behind the true live point. This means that the client         will not be able to play the first 30 seconds of content, but will be able to play the content that is 30 seconds old and newer.          The maximum live backoff duration is 300 seconds.         
        /// </summary>
        /// <value>For live content only. Truncates content from the head of a live video manifest by the specified duration. In effect, setting this value         creates a buffer between the client and the true live point by omitting content from the head of a manifest. This is a useful capability in cases where          CDN latency and other \"network realities\" make it difficult to deliver a true live experience, and result in content being presented in the manifest that          is not yet available in caches.                   For example, if you set this value to 30 seconds, the client will see a manifest that is 30 seconds behind the true live point. This means that the client         will not be able to play the first 30 seconds of content, but will be able to play the content that is 30 seconds old and newer.          The maximum live backoff duration is 300 seconds.         </value>
        [DataMember(Name = "liveBackoffDuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "liveBackoffDuration")]
        public int? LiveBackoffDuration { get; set; }

        /// <summary>
        /// For live content only. Indicates the duration of the presentation window, in units of timescale. A presentation window is the depth of content         present in the live manifest. For example, if you set this value to 300 seconds, the client will see a manifest containing 300 seconds of content, even if the underlying         asset is much longer. This is useful for restricting playback to the very latest content, or for restricting seek positions in content.                  The minimum presentation window duration is 60 seconds.         
        /// </summary>
        /// <value>For live content only. Indicates the duration of the presentation window, in units of timescale. A presentation window is the depth of content         present in the live manifest. For example, if you set this value to 300 seconds, the client will see a manifest containing 300 seconds of content, even if the underlying         asset is much longer. This is useful for restricting playback to the very latest content, or for restricting seek positions in content.                  The minimum presentation window duration is 60 seconds.         </value>
        [DataMember(Name = "presentationWindowDuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "presentationWindowDuration")]
        public int? PresentationWindowDuration { get; set; }

        /// <summary>
        /// For VOD content only. Indicates the start of the presentation window, in units of timescale. Given a timescale of \"1\", a value of \"N\" set here will          clip the first \"N\" seconds of content from the beginning of the video manifest.                   Examples:         timescale=1, startTimestamp=0, endTimestamp=10: The first 10 seconds of content will be included in the output.         timescale=1, startTimestamp=10, endTimestamp=70: The 60 seconds of content starting at 10 seconds will be included in the output.         timescale=10000000, startTimestamp=0, endTimestamp=100000000: The first 10 seconds of content will be included in the output.          In cases where the startTimestamp does not perfectly align with a segment boundary, the endTimestamp will be rounded down to the nearest segment boundary.         
        /// </summary>
        /// <value>For VOD content only. Indicates the start of the presentation window, in units of timescale. Given a timescale of \"1\", a value of \"N\" set here will          clip the first \"N\" seconds of content from the beginning of the video manifest.                   Examples:         timescale=1, startTimestamp=0, endTimestamp=10: The first 10 seconds of content will be included in the output.         timescale=1, startTimestamp=10, endTimestamp=70: The 60 seconds of content starting at 10 seconds will be included in the output.         timescale=10000000, startTimestamp=0, endTimestamp=100000000: The first 10 seconds of content will be included in the output.          In cases where the startTimestamp does not perfectly align with a segment boundary, the endTimestamp will be rounded down to the nearest segment boundary.         </value>
        [DataMember(Name = "startTimestamp", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startTimestamp")]
        public int? StartTimestamp { get; set; }

        /// <summary>
        /// Defines the unit of time for all the values in this object. The value is expressed in ticks per second.         The default value of 10,000,000 increments per second (or 10 MHz) is used if this parameter is not specified. IF you're a video         engineer doing Serious Business, consider setting this to 48,000 or 90,000 representing 90Khz and 48Khz respectively. If you're          a mere mortal, a value of 1 is sensible and would represent seconds.                  For example, with a timescale set to \"1\", the startTimestamp and endTimestamp values are expressed in seconds. So a startTimestamp of         10 and an endTimestamp of 20 would represent a 10 second window of content. Segments overlapping this window would be included in the          output.         
        /// </summary>
        /// <value>Defines the unit of time for all the values in this object. The value is expressed in ticks per second.         The default value of 10,000,000 increments per second (or 10 MHz) is used if this parameter is not specified. IF you're a video         engineer doing Serious Business, consider setting this to 48,000 or 90,000 representing 90Khz and 48Khz respectively. If you're          a mere mortal, a value of 1 is sensible and would represent seconds.                  For example, with a timescale set to \"1\", the startTimestamp and endTimestamp values are expressed in seconds. So a startTimestamp of         10 and an endTimestamp of 20 would represent a 10 second window of content. Segments overlapping this window would be included in the          output.         </value>
        [DataMember(Name = "timescale", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "timescale")]
        public int? Timescale { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PresentationTimeRange {\n");
            sb.Append("  EndTimestamp: ").Append(EndTimestamp).Append("\n");
            sb.Append("  ForceEndTimestamp: ").Append(ForceEndTimestamp).Append("\n");
            sb.Append("  LiveBackoffDuration: ").Append(LiveBackoffDuration).Append("\n");
            sb.Append("  PresentationWindowDuration: ").Append(PresentationWindowDuration).Append("\n");
            sb.Append("  StartTimestamp: ").Append(StartTimestamp).Append("\n");
            sb.Append("  Timescale: ").Append(Timescale).Append("\n");
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
