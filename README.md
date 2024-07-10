# A .NET client SDK for MediaKind MK.IO

This project is an open source .NET SDK for [MediaKind MK.IO](https://mk.io). For maximum compatibility, it targets .NET 8.0, .NET Standard 2.0 and .NET Framework 4.6.2. 

[Link to MK.IO Nuget package](https://www.nuget.org/packages/MK.IO).

## Usage (C#, .NET)

### MK.IO Personal API Token

You need to use the new MK.IO Personal Access Tokens to connect to the API. This is a Json Web Token (JWT) also called Personal API Token.
You can create them in the MK.IO portal and revoke them if needed.

To create one :

1. Open a web browser and log into https://app.mk.io (sign in with Microsoft SSO).
1. Once you are logged in, click on your email in the drop-down menu in the top right corner. More details [here](https://docs.mk.io/docs/api-tokens).

For more information, please read this [article](https://docs.mk.io/docs/personal-access-tokens).

This SDK also brings token management features for the MK.IO API. You can use the SDK to create, list, revoke, and get details of your personal API tokens, using client.Management.YourProfile.

### Supported operations

In the current version, operations are supported for :

- Assets
- Streaming endpoints
- Streaming locators
- Storage accounts
- Content key policies
- Transforms, including with CVQ presets, converter presets and Thumbnail generation
- Jobs
- Live events
- Live outputs
- Asset filters
- Account filters
- Streaming policies
- Account (some methods were moved to Management/YourProfile)
- Management/YourProfile

### End-to-end sample code

#### File encoding

There is a documented end-to-end sample code available in the SampleNet8.0 project, in file [SimpleEncodingAndPublishing.cs](https://github.com/microsoft/MK.IO/blob/main/SampleNet8.0/SimpleEncodingAndPublishing.cs).

This sample code does the following :

- upload a mp4 file to a new asset using authentication in the browser (you need contribution role on the storage)
- create the output asset
- create/update a transform
- submit an encoding job
- create/update a transform for thumbnails
- submit a job to generate a thumbnails sprite
- create a download locator for the thumbnails sprite and thumbnails vtt and list the Urls
- create a streaming locator for the encoded asset
- create and start a streaming endpoint if there is none
- list the streaming urls and test player urls.
- clean the created resources if the user accepts

Run the SampleNet8.0 project to execute this sample code.

#### Live streaming

There is a documented end-to-end sample code for live streaming, in file [SimpleLiveStreaming.cs](https://github.com/microsoft/MK.IO/blob/main/SampleNet8.0/SimpleLiveStreaming.cs).

What the sample does :

- create a live event
- create a live output asset
- create a live output
- create a locator
- create and start a streaming endpoint if there is none
- list the streaming urls and test player urls.
- propose to the user to convert the live asset to a mp4 asset and create a download locator to download the mp4 file(s)
- clean the created resources if the user accepts

Edit Program.cs file in SampleNet8.0 to uncomment line `await SimpleLiveStreaming.RunAsync();`, comment `await SimpleEncodingAndPublishing.RunAsync();`, and run the sample project.

### Other examples

Here is an example on how to use the SDK to manage assets and streaming endpoints :

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("yourMKIOSubscriptionName", "yourMKIOPersonalAPIToken");

// get user profile info
var profile = client.Account.Management.YourProfile.GetProfile();

// Get subscription stats
var stats = client.Account.GetSubscriptionStats();

// Get monthly usage of MK.IO subscription
var monthlyUsage = client.Account.GetSubscriptionUsage();

// *****************
// asset operations
// *****************

// list assets
var mkioAssets = client.Assets.List();

// list assets with pages, 10 assets per page, sorted by creation date
var mkioAssetsResult = client.Assets.ListAsPage("properties/created desc", null, null, null, 10);
while (true)
{
    // do stuff here using mkioAssetsResult.Results

    if (mkioAssetsResult.NextPageLink == null) break;
    mkioAssetsResult = client.Assets.ListAsPageNext(mkioAssetsResult.NextPageLink);
}

// get asset
var mkasset = client.Assets.Get("myassetname");

// create a first asset, letting MK.IO generates a container name
var newAssetName = MKIOClient.GenerateUniqueName("asset");
var newasset = client.Assets.CreateOrUpdate(newAssetName, null, "storagename", "description of my asset");

// create another asset and use labels to tag it. Container name will be the nae of the asset
var newAssetName2 = MKIOClient.GenerateUniqueName("asset");
var newasset2 = client.Assets.CreateOrUpdate(
    newAssetName,
    newAssetName, // container name
    "storagename",
    "description of asset using labels",
    AssetContainerDeletionPolicyType.Retain,
    null,
    new Dictionary<string, string>() { { "typeAsset", "source" } }
    );

// list assets using labels filtering
var sourceEncodedAssets = client.Assets.List(label: new List<string> { "typeAsset=source" });

// delete created asset
client.Assets.Delete(newsasset.Name);

// get streaming locators for asset
var locatorsAsset = client.Assets.ListStreamingLocators("asset-1b510ee166");

// Get tracks and directory of an asset
var tracksAndDir = client.Assets.ListTracksAndDirListing("asset-ef2058b692");


// ******************************
// Streaming endpoint operations
// ******************************

// get streaming endpoint
var mkse = client.StreamingEndpoints.Get("streamingendpoint1");

// list streaming endpoints
var mkses = client.StreamingEndpoints.List();

// create streaming endpoint
var newSe = client.StreamingEndpoints.Create("streamingendpoint2", client.Account.GetSubscriptionLocation()!.Name, new StreamingEndpointProperties
            {
                Description = "my description",
                ScaleUnits = 0,
                CdnEnabled = false,
                Sku = new StreamingEndpointsCurrentSku
                {
                    Name = StreamingEndpointSkuType.Standard
                }
            });

// start, stop, delete streaming endpoint
client.StreamingEndpoints.Start("streamingendpoint1", true);
client.StreamingEndpoints.Stop("streamingendpoint1", true);
client.StreamingEndpoints.Delete("streamingendpoint1");
```

Additional samples are available :

- [storage operations](https://github.com/microsoft/MK.IO/blob/main/SampleStorageOperations.md)
- [transform and job operations](https://github.com/microsoft/MK.IO/blob/main/SampleTransformAndJobOperations.md)
- [account filter and asset filter operations](https://github.com/microsoft/MK.IO/blob/main/SampleFilterOperations.md)
- [content key policy and streaming locator operations](https://github.com/microsoft/MK.IO/blob/main/SampleContentKeyPolicyOperations.md)


Async operations are also supported. For example :

```csharp

// *****************
// asset operations
// *****************

// Retrieve assets with pages for better performances, sorted by names, with a batch of 10 assets in each page
var mkioAssetsResult = await client.Assets.ListAsPageAsync("name desc", null, null, null, 10);
while (true)
{
    // do stuff here using mkioAssetsResult.Results

    if (mkioAssetsResult.NextPageLink == null) break;
    mkioAssetsResult = await client.Assets.ListAsPageNextAsync(mkioAssetsResult.NextPageLink);
}


// ******************************
// Streaming endpoint operations
// ******************************

// get streaming endpoint
var mkse = await client.StreamingEndpoints.GetAsync("streamingendpoint1");

// list streaming endpoints
var mkses = await client.StreamingEndpoints.ListAsync();

// create streaming endpoint
var location = await client.Account.GetSubscriptionLocationAsync();
var newSe = await client.StreamingEndpoints.CreateAsync("streamingendpoint2", location!.Name, new StreamingEndpointProperties
            {
                Description = "my description",
                ScaleUnits = 0,
                CdnEnabled = false,
                Sku = new StreamingEndpointsCurrentSku
                {
                    Name = StreamingEndpointSkuType.Standard
                }
            });

// start, stop, delete streaming endpoint
await client.StreamingEndpoints.StartAsync("streamingendpoint1", true);
await client.StreamingEndpoints.StopAsync("streamingendpoint1", true);
await client.StreamingEndpoints.DeleteAsync("streamingendpoint2");

```

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
