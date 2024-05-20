using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LiveOutputProperties
    {
        /// <summary>
        /// ISO 8601 timespan duration of the archive window length. This is duration that customer want to retain the recorded content.
        /// </summary>
        /// <value>ISO 8601 timespan duration of the archive window length. This is duration that customer want to retain the recorded content.</value>
        [DataMember(Name = "archiveWindowLength", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "archiveWindowLength")]
        public TimeSpan ArchiveWindowLength { get; set; }

        /// <summary>
        /// The name of the asset that the live output will write to.
        /// </summary>
        /// <value>The name of the asset that the live output will write to.</value>
        [DataMember(Name = "assetName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "assetName")]
        public string AssetName { get; set; }

        /// <summary>
        /// The exact time the live output was created.
        /// </summary>
        /// <value>The exact time the live output was created.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The description of the live output.
        /// </summary>
        /// <value>The description of the live output.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Hls
        /// </summary>
        [DataMember(Name = "hls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hls")]
        public LiveOutputHls Hls { get; set; }

        /// <summary>
        /// The exact time the live output was last modified.
        /// </summary>
        /// <value>The exact time the live output was last modified.</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The name of the manifest file. If not provided, the service will generate one automatically. This is the filename that will appear in playback URLs.
        /// </summary>
        /// <value>The name of the manifest file. If not provided, the service will generate one automatically. This is the filename that will appear in playback URLs.</value>
        [DataMember(Name = "manifestName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "manifestName")]
        public string ManifestName { get; set; }

        /// <summary>
        /// Not supported. The output snapshot time. This is the wall clock time, in unix epoch seconds, that the live output will begin recording from.
        /// </summary>
        /// <value>Not supported. The output snapshot time. This is the wall clock time, in unix epoch seconds, that the live output will begin recording from.</value>
        [DataMember(Name = "outputSnapTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "outputSnapTime")]
        [Obsolete] public int? OutputSnapTime { get; set; }

        /// <summary>
        /// The provisioning state of the live output.
        /// </summary>
        /// <value>The provisioning state of the live output.</value>
        [DataMember(Name = "provisioningState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "provisioningState")]
        public LiveOutputProvisioningState? ProvisioningState { get; private set; }

        /// <summary>
        /// The resource state of the live output.
        /// </summary>
        /// <value>The resource state of the live output.</value>
        [DataMember(Name = "resourceState", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resourceState")]
        public LiveOutputResourceState? ResourceState { get; private set; }

        /// <summary>
        /// Not supported.
        /// ISO 8601 timespan duration of the rewind window length during live playback.
        /// This is the amount of time that the live output will be able to rewind.
        /// </summary>
        /// <value>Not supported.          ISO 8601 timespan duration of the rewind window length during live playback.          This is the amount of time that the live output will be able to rewind.</value>
        [DataMember(Name = "rewindWindowLength", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rewindWindowLength")]
        [Obsolete] public TimeSpan? RewindWindowLength { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveOutputProperties {\n");
            sb.Append("  ArchiveWindowLength: ").Append(ArchiveWindowLength).Append("\n");
            sb.Append("  AssetName: ").Append(AssetName).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Hls: ").Append(Hls).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  ManifestName: ").Append(ManifestName).Append("\n");
            sb.Append("  OutputSnapTime: ").Append(OutputSnapTime).Append("\n");
            sb.Append("  ProvisioningState: ").Append(ProvisioningState).Append("\n");
            sb.Append("  ResourceState: ").Append(ResourceState).Append("\n");
            sb.Append("  RewindWindowLength: ").Append(RewindWindowLength).Append("\n");
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
