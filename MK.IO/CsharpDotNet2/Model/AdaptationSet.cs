// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AdaptationSet
    {
        /// <summary>
        /// Gets or Sets Accessibility
        /// </summary>

        public List<Accessibility> Accessibility { get; set; }

        /// <summary>
        /// Gets or Sets ContentType
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets MaxFrameRate
        /// </summary>
        public string MaxFrameRate { get; set; }

        /// <summary>
        /// Gets or Sets MaxHeight
        /// </summary>
        public string MaxHeight { get; set; }

        /// <summary>
        /// Gets or Sets MaxWidth
        /// </summary>
        public string MaxWidth { get; set; }

        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets Par
        /// </summary>
        public string Par { get; set; }

        /// <summary>
        /// Gets or Sets Representation
        /// </summary>
        public List<Representation> Representation { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        public List<Role> Role { get; set; }

        /// <summary>
        /// Gets or Sets SegmentAlignment
        /// </summary>
        public string SegmentAlignment { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AdaptationSet {\n");
            sb.Append("  Accessibility: ").Append(Accessibility).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MaxFrameRate: ").Append(MaxFrameRate).Append("\n");
            sb.Append("  MaxHeight: ").Append(MaxHeight).Append("\n");
            sb.Append("  MaxWidth: ").Append(MaxWidth).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Par: ").Append(Par).Append("\n");
            sb.Append("  Representation: ").Append(Representation).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  SegmentAlignment: ").Append(SegmentAlignment).Append("\n");
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
