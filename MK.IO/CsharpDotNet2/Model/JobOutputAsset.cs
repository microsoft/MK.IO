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
    public class JobOutputAsset
    {
        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [DataMember(Name = "@odata.type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "@odata.type")]
        public string OdataType { get; set; }

        /// <summary>
        /// The name of the input Asset
        /// </summary>
        /// <value>The name of the input Asset</value>
        [DataMember(Name = "assetName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "assetName")]
        public string AssetName { get; set; }

        /// <summary>
        /// The UTC date and time at which this Output finished processing.
        /// </summary>
        /// <value>The UTC date and time at which this Output finished processing.</value>
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "error")]
        public JobError Error { get; set; }

        /// <summary>
        /// A label that is assigned to a JobOutput in order to help uniquely identify it.
        /// </summary>
        /// <value>A label that is assigned to a JobOutput in order to help uniquely identify it.</value>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// If the JobOutput is in a Processing state, this contains the Job completion percentage. The value is an estimate and not intended to be used to predict Job completion times.
        /// </summary>
        /// <value>If the JobOutput is in a Processing state, this contains the Job completion percentage. The value is an estimate and not intended to be used to predict Job completion times.</value>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "progress")]
        public int? Progress { get; set; } = 0;

        /// <summary>
        /// The UTC date and time at which this Output began processing.
        /// </summary>
        /// <value>The UTC date and time at which this Output began processing.</value>
        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The current state of the job.
        /// </summary>
        /// <value>The current state of the job.</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "state")]
        public JobState State { get; set; } = JobState.Queued;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobOutputAsset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  AssetName: ").Append(AssetName).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
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
