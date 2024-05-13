# Sample for filter operations with MK.IO SDK

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("mkiosubscriptionname", "mkiotoken");

// ************************
// asset filter operations
// ************************

var assetFilters = client.AssetFilters.List("liveoutput-c4debfe5");

var assetFilter1 = client.AssetFilters.Get("liveoutput-c4debfe5", assetFilters.First().Name);

// This asset filter includes all audio tracks with mp4a, and all video tracks that are between 0 and 1 Mbps
var assetFilter = client.AssetFilters.CreateOrUpdate("liveoutput-c4debfe5", MKIOClient.GenerateUniqueName("filter"), new MediaFilterProperties
{
    PresentationTimeRange = new PresentationTimeRange
    {
        Timescale = 10000000
    },
    Tracks = new List<FilterTrackSelection>()
    {
        new FilterTrackSelection
        {
            TrackSelections = new List<FilterTrackPropertyCondition>()
            {
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.Type,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterPropertyTypeValue.Video
                },
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.Bitrate,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = "0-1048576"
                }
            },
        },
        new FilterTrackSelection
        {
            TrackSelections = new List<FilterTrackPropertyCondition>()
            {
                new FilterTrackPropertyCondition
                    {
                    Property = FilterTrackPropertyType.Type,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterTrackPropertyTypeValue.Audio
                },
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.FourCC,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterTrackPropertyFourCCValue.mp4a
                }
            }
        }
    }
});


client.AssetFilters.Delete("liveoutput-c4debfe5", assetFilter.Name);

// **************************
// account filter operations
// **************************

var accountfilters = client.AccountFilters.List();

// This account filter includes all audio tracks with mp4a, and all video tracks that are between 0 and 1 Mbps
var accountFilter = client.AccountFilters.CreateOrUpdate("filter123", new MediaFilterProperties
{
    PresentationTimeRange = new PresentationTimeRange
    {
        Timescale = 10000000
    },
    Tracks = new List<FilterTrackSelection>()
    {
        new FilterTrackSelection
        {
            TrackSelections = new List<FilterTrackPropertyCondition>()
            {
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.Type,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterTrackPropertyTypeValue.Video
                },
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.Bitrate,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = "0-1048576"
                }
            },
        },
        new FilterTrackSelection
        {
            TrackSelections = new List<FilterTrackPropertyCondition>()
            {
                new FilterTrackPropertyCondition
                    {
                    Property = FilterTrackPropertyType.Type,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterTrackPropertyTypeValue.Audio
                },
                new FilterTrackPropertyCondition
                {
                    Property = FilterTrackPropertyType.FourCC,
                    Operation = FilterTrackPropertyCompareOperation.Equal,
                    Value = FilterTrackPropertyFourCCValue.mp4a
                }
            }
        }
    }
});

client.AccountFilters.Delete("filter123");

```
