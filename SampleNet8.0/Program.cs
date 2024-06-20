// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

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
           // await SimpleEncodingAndPublishing.RunAsync();
            await SimpleLiveStreaming.RunAsync();
            // await GeneralTesting.RunAsync();
        }
    }
}

