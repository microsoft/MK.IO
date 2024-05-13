# Sample for transform and job operations with MK.IO SDK

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("mkiosubscriptionname", "mkiotoken");

// *********************
// transform operations
// *********************

// Create a transform
var transform = client.Transforms.CreateOrUpdate("simpletransform", new TransformProperties
            {
                Description = "Encoding to 720p single bitrate",
                Outputs =  new List<TransformOutput>
                {
                    new TransformOutput
                    {
                        Preset = new BuiltInStandardEncoderPreset(EncoderNamedPreset.H264SingleBitrate720p),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                }
            });


// ***************
// job operations
// ***************

// list all jobs
var jobs = client.Jobs.ListAll();

// create output asset
var outputAssetName = MKIOClient.GenerateUniqueName("asset");
var outputAsset = client.Assets.CreateOrUpdate(outputAssetName, outputAssetName, config["StorageName"], "output asset for job");
// create a job with the output asset created and with an asset as a source
var newJob = client.Jobs.Create(transform.Name, MKIOClient.GenerateUniqueName("job"), new JobProperties
    {
        Description = $"My Job using an asset source with transform {transform.Name}",
        Priority = JobPriorityType.Normal,
        Input = new JobInputAsset(
            "copy-ef2058b692-copy",
            new List<string> {
                "switch_1920x1080_AACAudio_3677.mp4"
            }),
        Outputs = new List<JobOutputAsset>()
        {
            new JobOutputAsset()
            {
                AssetName = outputAssetName
            }
        }
    }
    );

// job with http source as a source
var newJobH = client.Jobs.Create(transform.Name, MKIOClient.GenerateUniqueName("job"), new JobProperties
    {
        Description = $"My job using a https source with transform {transform.Name}",
        Priority = TransformOutputPriorityType.Normal,
        Input = new JobInputHttp(
            null,
            new List<string> {
                "https://myurltovideofile.mp4"
            }),
        Outputs = new List<JobOutputAsset>()
        {
            new JobOutputAsset()
            {
                AssetName = outputAssetName
            }
        }
    }
    );

// wait for the job to complete
while (newJobH.Properties.State == JobState.Queued || newJobH.Properties.State == JobState.Scheduled || newJobH.Properties.State == JobState.Processing)
{
    newJobH = client.Jobs.Get(tranform.Name, newJobH.Name);
    Console.WriteLine(jobHttp.Properties.State);
    Thread.Sleep(10000);
}


// Get a job
var job2 = client.Jobs.Get(tranform.Name, "testjob1");

// Cancel a job
client.Jobs.Cancel(tranform.Name, "testjob2");

// Delete a job
client.Jobs.Delete(tranform.Name, "testjob3");

```
