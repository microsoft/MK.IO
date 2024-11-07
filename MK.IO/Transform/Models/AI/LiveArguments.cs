// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    public class LiveArguments
    {
        public LiveArguments(List<Transcription> liveTranscription)
        {
            LiveTranscription = liveTranscription;
        }

        public List<Transcription> LiveTranscription { get; set; }
    }
}