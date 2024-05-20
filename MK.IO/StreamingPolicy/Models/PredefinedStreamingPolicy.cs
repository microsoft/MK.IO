// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    /// <summary> The built-in preset to be used with streaming locator. </summary>
    public readonly partial struct PredefinedStreamingPolicy
    {
        //
        // Summary:
        //     Predefined Streaming Policy which supports clear streaming only
        public static readonly string ClearStreamingOnly = "Predefined_ClearStreamingOnly";

        //
        // Summary:
        //     Predefined Streaming Policy which supports download only
        public static readonly string DownloadOnly = "Predefined_DownloadOnly";

        //
        // Summary:
        //     Predefined Streaming Policy which supports download and clear streaming
        public static readonly string DownloadAndClearStreaming = "Predefined_DownloadAndClearStreaming";

        //
        // Summary:
        //     Predefined Streaming Policy which supports envelope encryption
        public static readonly string ClearKey = "Predefined_ClearKey";

        //
        // Summary:
        //     Predefined Streaming Policy which supports envelope and cenc encryption
        public static readonly string MultiDrmCencStreaming = "Predefined_MultiDrmCencStreaming";

        //
        // Summary:
        //     Predefined Streaming Policy which supports clear key, cenc and cbcs encryption
        public static readonly string MultiDrmStreaming = "Predefined_MultiDrmStreaming";
    }
}