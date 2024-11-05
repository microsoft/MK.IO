// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SelectVideoTrackByAttribute : TrackDiscriminator
    {
        public SelectVideoTrackByAttribute(TrackAttributeType attribute, TrackFilterType filter, string filterValue)
        {
            Attribute = attribute;
            Filter = filter;
            FilterValue = filterValue;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonProperty(PropertyName = "@odata.type")]
        internal override string OdataType => "SelectVideoTrackByAttribute";

        /// <summary>
        /// The TrackAttribute to filter the tracks by.
        /// </summary>
        /// <value>The TrackAttribute to filter the tracks by.</value>
        [DataMember(Name = "attribute", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "attribute")]
        public TrackAttributeType Attribute { get; set; }

        /// <summary>
        /// The type of AttributeFilter to apply to the TrackAttribute in order to select the tracks.
        /// </summary>
        /// <value>The type of AttributeFilter to apply to the TrackAttribute in order to select the tracks.</value>
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filter")]
        public TrackFilterType Filter { get; set; }

        /// <summary>
        /// The value to filter the tracks by.
        /// </summary>
        /// <value>The value to filter the tracks by.</value>
        [DataMember(Name = "filterValue", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filterValue")]
        public string FilterValue { get; set; }
    }
}
