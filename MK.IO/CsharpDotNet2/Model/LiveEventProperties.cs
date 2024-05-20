using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LiveEventProperties
    {
        /// <summary>
        /// The time when the live event was created.
        /// </summary>
        /// <value>The time when the live event was created.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// Gets or Sets CrossSiteAccessPolicies
        /// </summary>
        [DataMember(Name = "crossSiteAccessPolicies", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "crossSiteAccessPolicies")]
        public CrossSiteAccessPolicies CrossSiteAccessPolicies { get; set; }

        /// <summary>
        /// An optional description for the live event.
        /// </summary>
        /// <value>An optional description for the live event.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Encoding
        /// </summary>
        [DataMember(Name = "encoding", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "encoding")]
        public LiveEventEncoding Encoding { get; set; }

        /// <summary>
        /// Applied when useStaticHostname=true to specify the first part of the hostname for all input and preview addresses.
        /// </summary>
        /// <value>Applied when useStaticHostname=true to specify the first part of the hostname for all input and preview addresses.</value>
        [DataMember(Name = "hostnamePrefix", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hostnamePrefix")]
        public string HostnamePrefix { get; set; }

        /// <summary>
        /// Gets or Sets Input
        /// </summary>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "input")]
        public LiveEventInput Input { get; set; }

        /// <summary>
        /// The last time the live event was modified.
        /// </summary>
        /// <value>The last time the live event was modified.</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// Not currently supported. The name of the pipeline the LiveEvent will execute.
        /// </summary>
        /// <value>Not currently supported. The name of the pipeline the LiveEvent will execute.</value>
        [DataMember(Name = "pipeline", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pipeline")]
        [Obsolete] public string Pipeline { get; set; }

        /// <summary>
        /// Gets or Sets Preview
        /// </summary>
        [DataMember(Name = "preview", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "preview")]
        public LiveEventPreview Preview { get; set; }

        /// <summary>
        /// The current provisioning state of the resource. One of 'InProgress', 'Succeeded', or 'Failed'
        /// </summary>
        /// <value>The current provisioning state of the resource. One of 'InProgress', 'Succeeded', or 'Failed'</value>
        [DataMember(Name = "provisioningState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "provisioningState")]
        public LiveEventProvisioningState? ProvisioningState { get; private set; }

        /// <summary>
        /// The current state of the resource. One of 'Stopped', 'Starting', 'Running', 'Stopping', or 'Deleting'.
        /// </summary>
        /// <value>The current state of the resource. One of 'Stopped', 'Starting', 'Running', 'Stopping', or 'Deleting'.</value>
        [DataMember(Name = "resourceState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resourceState")]
        public LiveEventResourceState? ResourceState { get; private set; }

        /// <summary>
        /// A list of streaming options for the live event. One of 'Default' or 'LowLatency'. Only one value permitted in the list.
        /// </summary>
        /// <value>A list of streaming options for the live event. One of 'Default' or 'LowLatency'. Only one value permitted in the list.</value>
        [DataMember(Name = "streamOptions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "streamOptions")]
        public List<string> StreamOptions { get; set; }

        /// <summary>
        /// Not currently supported. Transcription settings for the live event.
        /// </summary>
        /// <value>Not currently supported. Transcription settings for the live event.</value>
        [DataMember(Name = "transcriptions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "transcriptions")]
        public List<Object> Transcriptions { get; set; }

        /// <summary>
        /// A boolean value that indicates whether a static hostname is assigned to input and preview endpoints. If not set, will default to 'false' and IP addresses will be provided.
        /// </summary>
        /// <value>A boolean value that indicates whether a static hostname is assigned to input and preview endpoints. If not set, will default to 'false' and IP addresses will be provided.</value>
        [DataMember(Name = "useStaticHostname", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "useStaticHostname")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
