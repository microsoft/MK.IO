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

    public class JobOutputAsset
    {
        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        public string OdataType { get; set; }

        /// <summary>
        /// The name of the input Asset
        /// </summary>
        /// <value>The name of the input Asset</value>
        public string AssetName { get; set; }

        /// <summary>
        /// The UTC date and time at which this Output finished processing.
        /// </summary>
        /// <value>The UTC date and time at which this Output finished processing.</value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        public JobError Error { get; set; }

        /// <summary>
        /// A label that is assigned to a JobOutput in order to help uniquely identify it.
        /// </summary>
        /// <value>A label that is assigned to a JobOutput in order to help uniquely identify it.</value>
        public string Label { get; set; }

        /// <summary>
        /// If the JobOutput is in a Processing state, this contains the Job completion percentage. The value is an estimate and not intended to be used to predict Job completion times.
        /// </summary>
        /// <value>If the JobOutput is in a Processing state, this contains the Job completion percentage. The value is an estimate and not intended to be used to predict Job completion times.</value>
        public int? Progress { get; set; }

        /// <summary>
        /// The UTC date and time at which this Output began processing.
        /// </summary>
        /// <value>The UTC date and time at which this Output began processing.</value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The current state of the job.
        /// </summary>
        /// <value>The current state of the job.</value>
        public string State { get; set; }


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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
