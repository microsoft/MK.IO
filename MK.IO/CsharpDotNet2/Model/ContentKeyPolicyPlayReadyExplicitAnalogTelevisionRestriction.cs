// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;



namespace MK.IO.Models
{

    /// <summary>
    /// Configures the Explicit Analog Television Output Restriction control bits. For further details see the PlayReady Compliance Rules.
    /// </summary>

    public class ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction
    {
        /// <summary>
        /// Indicates whether this restriction is enforced on a Best Effort basis.
        /// </summary>
        /// <value>Indicates whether this restriction is enforced on a Best Effort basis.</value>
        public bool? BestEffort { get; set; }

        /// <summary>
        /// Configures the restriction control bits. Must be between 0 and 3 inclusive.
        /// </summary>
        /// <value>Configures the restriction control bits. Must be between 0 and 3 inclusive.</value>
        public int? ConfigurationData { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction {\n");
            sb.Append("  BestEffort: ").Append(BestEffort).Append("\n");
            sb.Append("  ConfigurationData: ").Append(ConfigurationData).Append("\n");
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
