# Sample for live operations with MK.IO SDK

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("mkiosubscriptionname", "mkiotoken");

// *********************************
// live event and output operations
// *********************************

var list_le = client.LiveEvents.List();

// Creation
var liveEvent = client.LiveEvents.Create(MKIOClient.GenerateUniqueName("liveevent"), "francecentral", new LiveEventProperties
{
    Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.RTMP },
    StreamOptions = ["Default"],
    Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
});

// create live output asset
var nameOutputAsset = MKIOClient.GenerateUniqueName("liveoutput");
var liveOutputAsset = client.Assets.CreateOrUpdate(nameOutputAsset, "asset-" + nameOutputAsset, config["StorageName"], "live output asset");

var lo = client.LiveOutputs.Create(liveEvent.Name, MKIOClient.GenerateUniqueName("liveOutput"), new LiveOutputProperties
{
    ArchiveWindowLength = new TimeSpan(0,5,0),
    AssetName = nameOutputAsset
});

// live outputs listing for this live event
var liveOutputs = client.LiveOutputs.List(liveEvent.Name);

if (liveOutputs.Count == 1)
{
    var looo = client.LiveOutputs.Get(le.Name, liveOutputs.First().Name);
}

// Delete
client.LiveEvents.Delete("liveevent4");

```
