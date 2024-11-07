// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    public class Transcription
    {
        public Transcription(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}