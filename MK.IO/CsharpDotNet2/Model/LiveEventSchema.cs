

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class LiveEventSchema
    {
        /// <summary>
        /// The location of the live event. This must match the configured location for your account.
        /// </summary>
        /// <value>The location of the live event. This must match the configured location for your account.</value>
        public string Location { get; set; }

        /// <summary>
        /// The name of the resource
        /// </summary>
        /// <value>The name of the resource</value>
        [JsonInclude]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        public LiveEventProperties Properties { get; set; }

        /// <summary>
        /// A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.
        /// </summary>
        /// <value>A dictionary of tags associated with the live event. Maximum number of tags: 16. Maximum length of a tag: 256 characters.</value>
        public Dictionary<string, string> Tags { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventSchema {\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
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
