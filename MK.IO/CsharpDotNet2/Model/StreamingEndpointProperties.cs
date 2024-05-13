using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class StreamingEndpointProperties
    {
        /// <summary>
        /// Gets or Sets AccessControl
        /// </summary>
        [DataMember(Name = "accessControl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "accessControl")]
        public StreamingEndpointAccessControl AccessControl { get; set; }

        /// <summary>
        /// If CDN is enabled, the path that must be inserted after the hostname and before the locator, e.g. https://<hostName>/<cdnBasePath>/<locator>.
        /// </summary>
        /// <value>If CDN is enabled, the path that must be inserted after the hostname and before the locator, e.g. https://<hostName>/<cdnBasePath>/<locator>.</value>
        [DataMember(Name = "cdnBasePath", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cdnBasePath")]
        public string? CdnBasePath { get; private set; }

        /// <summary>
        /// Indicates if CDN is enabled for the streaming endpoint.
        /// </summary>
        /// <value>Indicates if CDN is enabled for the streaming endpoint.</value>
        [DataMember(Name = "cdnEnabled", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cdnEnabled")]
        public bool? CdnEnabled { get; set; }

        /// <summary>
        /// If CDN is enabled, the optional CDN profile name for the streaming endpoint.
        /// </summary>
        /// <value>If CDN is enabled, the optional CDN profile name for the streaming endpoint.</value>
        [DataMember(Name = "cdnProfile", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cdnProfile")]
        public string? CdnProfile { get; set; }

        /// <summary>
        /// If CDN is enabled, the CDN provider name for the streaming endpoint.
        /// </summary>
        /// <value>If CDN is enabled, the CDN provider name for the streaming endpoint.</value>
        [DataMember(Name = "cdnProvider", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cdnProvider")]
        public StreamingEndpointCdnProvider? CdnProvider { get; set; }

        /// <summary>
        /// The creation date and time of the streaming endpoint. Set by the system.
        /// </summary>
        /// <value>The creation date and time of the streaming endpoint. Set by the system.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// Gets or Sets CrossSiteAccessPolicies
        /// </summary>
        [DataMember(Name = "crossSiteAccessPolicies", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "crossSiteAccessPolicies")]
        public CrossSiteAccessPolicies CrossSiteAccessPolicies { get; set; }

        /// <summary>
        /// NOT SUPPORTED pending implementation of DNS validation.          Custom host names for the streaming endpoint. Must be unique within the region.          If not specified, a default hostname will be used. The best practice for custom DNS         is to use a CNAME pointing to the autogenerated hostname derived from the streaming endpoint name,         and to configure your CDN to deliver a HOST header to the origin server for routing purposes.
        /// </summary>
        /// <value>NOT SUPPORTED pending implementation of DNS validation.          Custom host names for the streaming endpoint. Must be unique within the region.          If not specified, a default hostname will be used. The best practice for custom DNS         is to use a CNAME pointing to the autogenerated hostname derived from the streaming endpoint name,         and to configure your CDN to deliver a HOST header to the origin server for routing purposes.</value>
        [DataMember(Name = "customHostNames", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customHostNames")]
        [Obsolete] public List<string> CustomHostNames { get; set; }

        /// <summary>
        /// The description of the streaming endpoint.
        /// </summary>
        /// <value>The description of the streaming endpoint.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The fqdn of the streaming endpoint. This is the output hostname and is always configured. To set a custom hostname, use the customHostNames property.
        /// </summary>
        /// <value>The fqdn of the streaming endpoint. This is the output hostname and is always configured. To set a custom hostname, use the customHostNames property.</value>
        [DataMember(Name = "hostName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hostName")]
        public string HostName { get; private set; }

        /// <summary>
        /// The last modified date and time of the streaming endpoint. Set by the system.
        /// </summary>
        /// <value>The last modified date and time of the streaming endpoint. Set by the system.</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The maximum amount of time that content will be cached, in seconds. This value is superceded by any ETAG values set by the infrastructure.
        /// </summary>
        /// <value>The maximum amount of time that content will be cached, in seconds. This value is superceded by any ETAG values set by the infrastructure.</value>
        [DataMember(Name = "maxCacheAge", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maxCacheAge")]
        public int? MaxCacheAge { get; set; }

        /// <summary>
        /// The provisioning state of the streaming endpoint. Set by the system. One of InProgress,Succeeded,Failed.
        /// </summary>
        /// <value>The provisioning state of the streaming endpoint. Set by the system. One of InProgress,Succeeded,Failed.</value>
        [DataMember(Name = "provisioningState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "provisioningState")]
        public StreamingEndpointProvisioningState ProvisioningState { get; private set; }

        /// <summary>
        /// The runtime state of the streaming endpoint. Set by the system. One of Running,Stopped,Deleted,Creating,Starting,Stopping,Deleting,Scaling.
        /// </summary>
        /// <value>The runtime state of the streaming endpoint. Set by the system. One of Running,Stopped,Deleted,Creating,Starting,Stopping,Deleting,Scaling.</value>
        [DataMember(Name = "resourceState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resourceState")]
        public StreamingEndpointResourceState ResourceState { get; private set; }

        /// <summary>
        /// The number of scale units for the streaming endpoint. This will determine your minimum scale. A value of 0 will result in the streaming endpoints using a Standard SKU.  A value greater than zero indicates that the 'Premium' SKUs will be provisioned.
        /// </summary>
        /// <value>The number of scale units for the streaming endpoint. This will determine your minimum scale. A value of 0 will result in the streaming endpoints using a Standard SKU.  A value greater than zero indicates that the 'Premium' SKUs will be provisioned.</value>
        [DataMember(Name = "scaleUnits", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scaleUnits")]
        public int? ScaleUnits { get; set; }

        /// <summary>
        /// Gets or Sets Sku
        /// </summary>
        [DataMember(Name = "sku", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sku")]
        public StreamingEndpointsCurrentSku Sku { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointProperties {\n");
            sb.Append("  AccessControl: ").Append(AccessControl).Append("\n");
            sb.Append("  CdnEnabled: ").Append(CdnEnabled).Append("\n");
            sb.Append("  CdnProfile: ").Append(CdnProfile).Append("\n");
            sb.Append("  CdnProvider: ").Append(CdnProvider).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CrossSiteAccessPolicies: ").Append(CrossSiteAccessPolicies).Append("\n");
            sb.Append("  CustomHostNames: ").Append(CustomHostNames).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  HostName: ").Append(HostName).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  MaxCacheAge: ").Append(MaxCacheAge).Append("\n");
            sb.Append("  ProvisioningState: ").Append(ProvisioningState).Append("\n");
            sb.Append("  ResourceState: ").Append(ResourceState).Append("\n");
            sb.Append("  ScaleUnits: ").Append(ScaleUnits).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
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
