// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    public class VodArguments
    {

        public VodArguments(List<Transcription> vodTranscription)
        {
            VodTranscription = vodTranscription;
        }

        public List<Transcription> VodTranscription { get; set; }
    }
}