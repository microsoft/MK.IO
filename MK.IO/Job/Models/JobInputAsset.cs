﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class JobInputAsset : JobInput
    {

        public JobInputAsset(string assetName, List<string> files)
        {
            AssetName = assetName;
            Files = files;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.JobInputAsset";

        /// <summary>
        /// The name of the input Asset
        /// </summary>
        /// <value>The name of the input Asset</value>
        public string AssetName { get; set; }

        /// <summary>
        /// (NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will end. Defaults to the end of the input media.
        /// </summary>
        /// <value>(NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will end. Defaults to the end of the input media.</value>
        [Obsolete] public JobInputTime? End { get; set; }

        /// <summary>
        /// List of files. Required for JobInputAsset.
        /// </summary>
        /// <value>List of files. Required for JobInputAsset.</value>
        public List<string> Files { get; set; }

        /// <summary>
        /// Defines a list of InputDefinitions
        /// </summary>
        /// <value>Defines a list of InputDefinitions</value>
        public List<InputFileDiscriminator> InputDefinitions { get; set; }

        /// <summary>
        /// A label that is assigned to a JobInputClip
        /// </summary>
        /// <value>A label that is assigned to a JobInputClip</value>
        public string Label { get; set; }

        /// <summary>
        /// (NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will start. Defaults to the beginning of the input media.
        /// </summary>
        /// <value>(NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will start. Defaults to the beginning of the input media.</value>
        [Obsolete] public JobInputTime? Start { get; set; }
    }
}