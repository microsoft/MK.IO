// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;
using System.Security.Cryptography;

namespace Sample
{
    public class Program
    {
        static void Main()
        {
            // MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            await SimpleEncodingAndPublishing.RunAsync();
            // await SimpleLiveStreaming.RunAsync();
            // await GeneralTesting.RunAsync();
        }
    }
}

