using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TransformOutput
    {
        /// <summary>
        /// Defines what the service should do when one output fails. Continue to produce other outputs, or stop processing.
        /// </summary>
        /// <value>Defines what the service should do when one output fails. Continue to produce other outputs, or stop processing.</value>
        [DataMember(Name = "onError", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "onError")]
        public string OnError { get; set; }

        /// <summary>
        /// Preset that describes the operations that will be used to modify, transcode, or extract insights from the source file to generate the output. Only BultiInStandardEncoderPreset is supported currently.
        /// </summary>
        /// <value>Preset that describes the operations that will be used to modify, transcode, or extract insights from the source file to generate the output. Only BultiInStandardEncoderPreset is supported currently.</value>
        [DataMember(Name = "preset", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "preset")]
        public TransformPreset Preset { get; set; }

        /// <summary>
        /// Sets the relative priority of the TransformOutputs within a Transform
        /// </summary>
        /// <value>Sets the relative priority of the TransformOutputs within a Transform</value>
        [DataMember(Name = "relativePriority", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "relativePriority")]
        public TransformOutputPriorityType RelativePriority { get; set; } = TransformOutputPriorityType.Normal;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransformOutput {\n");
            sb.Append("  OnError: ").Append(OnError).Append("\n");
            sb.Append("  Preset: ").Append(Preset).Append("\n");
            sb.Append("  RelativePriority: ").Append(RelativePriority).Append("\n");
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
