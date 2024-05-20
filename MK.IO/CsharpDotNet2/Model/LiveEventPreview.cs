// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class LiveEventPreview
    {
        /// <summary>
        /// Gets or Sets AccessControl
        /// </summary>
        public PreviewAccessControl AccessControl { get; set; }

        /// <summary>
        /// Not currently supported. Will be used to support DRM license aquisition for preview content.
        /// </summary>
        /// <value>Not currently supported. Will be used to support DRM license aquisition for preview content.</value>
        [Obsolete] public string AlternativeMediaId { get; set; }

        /// <summary>
        /// Populated server-side. The endpoints that are used for previewing the live event.
        /// </summary>
        /// <value>Populated server-side. The endpoints that are used for previewing the live event.</value>
        public List<LiveEventEndpoint> Endpoints { get; set; }

        /// <summary>
        /// The ID of the locator for the preview. This is automatically generated when the live event is created, and removed when the live Event is deleted.          The caller may specify a locator GUID, in which case the caller must ensure that the GUID is unique and not already used by another resource.
        /// </summary>
        /// <value>The ID of the locator for the preview. This is automatically generated when the live event is created, and removed when the live Event is deleted.          The caller may specify a locator GUID, in which case the caller must ensure that the GUID is unique and not already used by another resource.</value>
        public Guid? PreviewLocator { get; set; }

        /// <summary>
        /// The name of the DRM streaming policy for the live event preview. Defaults to Predefined_ClearStreamingOnly and no other value is presently supported.
        /// </summary>
        /// <value>The name of the DRM streaming policy for the live event preview. Defaults to Predefined_ClearStreamingOnly and no other value is presently supported.</value>
        public string StreamingPolicyName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventPreview {\n");
            sb.Append("  AccessControl: ").Append(AccessControl).Append("\n");
            sb.Append("  AlternativeMediaId: ").Append(AlternativeMediaId).Append("\n");
            sb.Append("  Endpoints: ").Append(Endpoints).Append("\n");
            sb.Append("  PreviewLocator: ").Append(PreviewLocator).Append("\n");
            sb.Append("  StreamingPolicyName: ").Append(StreamingPolicyName).Append("\n");
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
