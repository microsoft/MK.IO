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
    public class JobProperties
    {
        /// <summary>
        /// Customer provided key, value pairs that will be returned in Job and JobOutput state events.
        /// </summary>
        /// <value>Customer provided key, value pairs that will be returned in Job and JobOutput state events.</value>
        [DataMember(Name = "correlationData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "correlationData")]
        public Dictionary<string, Object> CorrelationData { get; set; }

        /// <summary>
        /// The creation date and time of the Job. Set by the system.
        /// </summary>
        /// <value>The creation date and time of the Job. Set by the system.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The description of the Job.
        /// </summary>
        /// <value>The description of the Job.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The UTC date and time at which this Job finished processing
        /// </summary>
        /// <value>The UTC date and time at which this Job finished processing</value>
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The inputs of the Job.
        /// </summary>
        /// <value>The inputs of the Job.</value>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "input")]
        public JobInput Input { get; set; }

        /// <summary>
        /// The last modified date and time of the Job. Set by the system.
        /// </summary>
        /// <value>The last modified date and time of the Job. Set by the system.</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The outputs for the Job.
        /// </summary>
        /// <value>The outputs for the Job.</value>
        [DataMember(Name = "outputs", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "outputs")]
        public List<JobOutputAsset> Outputs { get; set; }

        /// <summary>
        /// Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.
        /// </summary>
        /// <value>Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.</value>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "priority")]
        public JobPriorityType Priority { get; set; } = JobPriorityType.Normal;

        /// <summary>
        /// The UTC date and time at which this Job started processing
        /// </summary>
        /// <value>The UTC date and time at which this Job started processing</value>
        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The current state of the job.
        /// </summary>
        /// <value>The current state of the job.</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "state")]
        public JobState State { get; private set; } = JobState.Queued;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobProperties {\n");
            sb.Append("  CorrelationData: ").Append(CorrelationData).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  Outputs: ").Append(Outputs).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
