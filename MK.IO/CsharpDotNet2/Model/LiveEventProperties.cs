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

    public class LiveEventProperties
    {
        /// <summary>
        /// The time when the live event was created.
        /// </summary>
        /// <value>The time when the live event was created.</value>
        [JsonInclude]
        public string Created { get; private set; }

        /// <summary>
        /// Gets or Sets CrossSiteAccessPolicies
        /// </summary>
        public CrossSiteAccessPolicies CrossSiteAccessPolicies { get; set; }

        /// <summary>
        /// An optional description for the live event.
        /// </summary>
        /// <value>An optional description for the live event.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Encoding
        /// </summary>
        public LiveEventEncoding Encoding { get; set; }

        /// <summary>
        /// Applied when useStaticHostname=true to specify the first part of the hostname for all input and preview addresses.
        /// </summary>
        /// <value>Applied when useStaticHostname=true to specify the first part of the hostname for all input and preview addresses.</value>
        public string HostnamePrefix { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        public LiveEventInput Input { get; set; }

        /// <summary>
        /// The last time the live event was modified.
        /// </summary>
        /// <value>The last time the live event was modified.</value>
        [JsonInclude]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// Not currently supported. The name of the pipeline the LiveEvent will execute.
        /// </summary>
        /// <value>Not currently supported. The name of the pipeline the LiveEvent will execute.</value>
        [Obsolete] public string Pipeline { get; set; }

        /// <summary>
        /// Gets or Sets Preview
        /// </summary>
        public LiveEventPreview Preview { get; set; }

        /// <summary>
        /// The current provisioning state of the resource. One of 'InProgress', 'Succeeded', or 'Failed'
        /// </summary>
        /// <value>The current provisioning state of the resource. One of 'InProgress', 'Succeeded', or 'Failed'</value>
        [JsonInclude]
        public LiveEventProvisioningState? ProvisioningState { get; private set; }

        /// <summary>
        /// The current state of the resource. One of 'Stopped', 'Starting', 'Running', 'Stopping', or 'Deleting'.
        /// </summary>
        /// <value>The current state of the resource. One of 'Stopped', 'Starting', 'Running', 'Stopping', or 'Deleting'.</value>
        [JsonInclude]
        public LiveEventResourceState? ResourceState { get; private set; }

        /// <summary>
        /// A list of streaming options for the live event. One of 'Default' or 'LowLatency'. Only one value permitted in the list.
        /// </summary>
        /// <value>A list of streaming options for the live event. One of 'Default' or 'LowLatency'. Only one value permitted in the list.</value>
        public List<string> StreamOptions { get; set; }

        /// <summary>
        /// Not currently supported. Transcription settings for the live event.
        /// </summary>
        /// <value>Not currently supported. Transcription settings for the live event.</value>
        public List<Object> Transcriptions { get; set; }

        /// <summary>
        /// A boolean value that indicates whether a static hostname is assigned to input and preview endpoints. If not set, will default to 'false' and IP addresses will be provided.
        /// </summary>
        /// <value>A boolean value that indicates whether a static hostname is assigned to input and preview endpoints. If not set, will default to 'false' and IP addresses will be provided.</value>
        public bool? UseStaticHostname { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventProperties {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CrossSiteAccessPolicies: ").Append(CrossSiteAccessPolicies).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Encoding: ").Append(Encoding).Append("\n");
            sb.Append("  HostnamePrefix: ").Append(HostnamePrefix).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  Pipeline: ").Append(Pipeline).Append("\n");
            sb.Append("  Preview: ").Append(Preview).Append("\n");
            sb.Append("  ProvisioningState: ").Append(ProvisioningState).Append("\n");
            sb.Append("  ResourceState: ").Append(ResourceState).Append("\n");
            sb.Append("  StreamOptions: ").Append(StreamOptions).Append("\n");
            sb.Append("  Transcriptions: ").Append(Transcriptions).Append("\n");
            sb.Append("  UseStaticHostname: ").Append(UseStaticHostname).Append("\n");
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
