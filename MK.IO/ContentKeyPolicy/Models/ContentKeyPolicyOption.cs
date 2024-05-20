// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    /// <summary>
    /// Represents a policy option.
    /// </summary>
    public class ContentKeyPolicyOption
    {
        public ContentKeyPolicyOption(string name, ContentKeyPolicyConfiguration configuration, ContentKeyPolicyRestriction restriction)
        {
            Name = name;
            Restriction = restriction;
            Configuration = configuration;
        }

        /// <summary>
        /// The key delivery configuration.
        /// </summary>
        /// <value>The key delivery configuration.</value>
        [JsonProperty("configuration")]
        public ContentKeyPolicyConfiguration Configuration { get; set; }

        /// <summary>
        /// The Policy Option description.
        /// </summary>
        /// <value>The Policy Option description.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The legacy Policy Option ID.
        /// </summary>
        /// <value>The legacy Policy Option ID.</value>
        [JsonProperty("policyOptionId")]
        public Guid? PolicyOptionId { get; private set; }

        /// <summary>
        /// The requirements that must be met to deliver keys with this configuration
        /// </summary>
        /// <value>The requirements that must be met to deliver keys with this configuration</value>
        [JsonProperty("restriction")]
        public ContentKeyPolicyRestriction Restriction { get; set; }
    }
}