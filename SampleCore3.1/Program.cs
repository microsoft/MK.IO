﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using MK.IO;
using System;
using System.Linq;

namespace SampleCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* you need to add an appsettings.json file with the following content:
            {
              "MKIOSubscriptionName": "yourMKIOsubscriptionname",
              "MKIOToken": "yourMKIOPersonalAPIToken",
            }
            */

            // load settings from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            Console.WriteLine($"Using '{config["MKIOSubscriptionName"]}' MK.IO subscription.");

            // **********************
            // MK.IO Client creation
            // **********************

            var client = new MKIOClient(config["MKIOSubscriptionName"], config["MKIOToken"]);

            MKIOClient.GenerateUniqueName("asset");

            try
            {
                var profile = client.Management.YourProfile.GetProfile();
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


            // Get subscription stats
            var stats = client.Account.GetSubscriptionStats();

            var subs = client.Account.ListAllSubscriptions();
            var sub = client.Account.GetSubscription();
            var locs = client.Account.ListAllLocations();

            var currentLocation = locs.Where(l => l.Metadata.Id == sub.Spec.LocationId).FirstOrDefault();
            Console.WriteLine($"Connected to '{sub.Spec.Name}' MK.IO instance in region '{currentLocation.Metadata.Name}'.");

            // pause the command line
            Console.ReadLine();
        }
    }
}
