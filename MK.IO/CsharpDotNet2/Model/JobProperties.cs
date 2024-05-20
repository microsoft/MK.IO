// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class JobProperties
    {
        /// <summary>
        /// Customer provided key, value pairs that will be returned in Job and JobOutput state events.
        /// </summary>
        /// <value>Customer provided key, value pairs that will be returned in Job and JobOutput state events.</value>
        public Dictionary<string, Object> CorrelationData { get; set; }

        /// <summary>
        /// The creation date and time of the Job. Set by the system.
        /// </summary>
        /// <value>The creation date and time of the Job. Set by the system.</value>
        [JsonInclude]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The description of the Job.
        /// </summary>
        /// <value>The description of the Job.</value>
        public string Description { get; set; }

        /// <summary>
        /// The UTC date and time at which this Job finished processing
        /// </summary>
        /// <value>The UTC date and time at which this Job finished processing</value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// The inputs of the Job.
        /// </summary>
        /// <value>The inputs of the Job.</value>
        public JobInput Input { get; set; }

        /// <summary>
        /// The last modified date and time of the Job. Set by the system.
        /// </summary>
        /// <value>The last modified date and time of the Job. Set by the system.</value>
        [JsonInclude]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The outputs for the Job.
        /// </summary>
        /// <value>The outputs for the Job.</value>
        public List<JobOutputAsset> Outputs { get; set; }

        /// <summary>
        /// Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.
        /// </summary>
        /// <value>Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.</value>
        public JobPriorityType Priority { get; set; } = JobPriorityType.Normal;

        /// <summary>
        /// The UTC date and time at which this Job started processing
        /// </summary>
        /// <value>The UTC date and time at which this Job started processing</value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The current state of the job.
        /// </summary>
        /// <value>The current state of the job.</value>
        [JsonInclude]
        public JobState State { get; private set; }


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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
