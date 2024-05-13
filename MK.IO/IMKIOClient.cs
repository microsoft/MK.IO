// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Operations;

namespace MK.IO
{
    /// <summary>
    /// REST Base Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    public interface IMKIOClient
    {
        /// <summary>
        /// Gets the ISubscriptionOperations.
        /// </summary>
        IAccountOperations Account { get; }

        /// <summary>
        /// The Storage Accounts API provides a means of defining and retrieving Storage Accounts, and associating and managing Storage Credentials for a Storage Account.
        /// </summary>
        IStorageAccountsOperations StorageAccounts { get; }

        /// <summary>
        /// The Assets API is central to managing content in this system. An Asset in this API represents a direct link between the application
        /// and a storage container where content is stored. Ondemand Jobs and LiveEvent LiveOutputs both output encoded content into an Asset.
        /// </summary>
        IAssetsOperations Assets { get; }

        /// <summary>
        /// The Live Events API allows you to create and manage live events.
        /// </summary>
        ILiveEventsOperations LiveEvents { get; }

        /// <summary>
        /// Live Outputs are how video from a LiveEvent is written to an Asset. A Live Event on its own will encode video, but will not write that video
        /// to a permanent location. This is what Live Outputs achieve. A single Live Event can have multiple Live Outputs, for instance you may elect to have
        /// one output storing a 2 minute rolling buffer of content for a traditional live stream, and a second output with a 24-hour rolling buffer for
        /// a catchup service.
        /// </summary>
        ILiveOutputsOperations LiveOutputs { get; }

        /// <summary>
        /// Gets the IJobsOperations.
        /// </summary>
        IJobsOperations Jobs { get; }

        /// <summary>
        /// Streaming Endpoints are the thing that connects your clients to your content. Streaming Endpoints are
        /// tied to a subscription and must reside in the same location as everything else in the subscription.
        /// They do not have a direct relationship to any other API. Instead, ALL Streaming *Locators* are accessible
        /// via any Streaming Endpoint in a subscription. When you create a Streaming Endpoint, you get a DNS name
        /// that you can use to access your content. Combined with the *listPaths* API on the Streaming Locators API,
        /// you can construct a full URL to your content.
        /// </summary>
        IStreamingEndpointsOperations StreamingEndpoints { get; }

        /// <summary>
        /// Gets the ITransformsOperations.
        /// </summary>
        ITransformsOperations Transforms { get; }

        /// <summary>
        /// Streaming Locators are used to publish content for streaming.
        /// If you want to filter profiles or add security, this is the place.
        /// </summary>
        IStreamingLocatorsOperations StreamingLocators { get; }

        /// <summary>
        /// To specify encryption options on your stream, you need to create a Streaming Policy and associate it with your
        /// Streaming Locator. You create the Content Key Policy to configure how the content key (that provides secure access
        /// to your Assets) is delivered to end clients. You need to set the requirements (restrictions) on the Content Key
        /// Policy that must be met in order for keys with the specified configuration to be delivered to clients. The content
        /// key policy is not needed for clear streaming or downloading.
        /// </summary>
        IContentKeyPoliciesOperations ContentKeyPolicies { get; }

        /// <summary>
        /// Gets the IAccountFiltersOperations.
        /// </summary>
        IAccountFiltersOperations AccountFilters { get; }

        /// <summary>
        /// Asset filters allow for just-in-time filtering of the contents of a video manifest. This is useful, for instance, when you want to present
        /// specific language tracks to a user based on their language preferences, or when you need to suppress certain tracks from being presented to
        /// devices that lack support, or when you want to present a specific bitrate to users when a stream starts.
        /// Asset filters are applied to a specific asset, and are evaluated at the time of playback. They are not applied to the underlying asset itself,
        /// and multiple filters can be applied to a single asset. Filters are applied in the order they are created, with multiple filters being OR'd together
        /// to produce the final result.
        /// </summary>
        IAssetFiltersOperations AssetFilters { get; }

        /// <summary>
        /// Streaming Policies are the starting point for securing content. A default set of streaming policies is provided, which should be sufficient for most use cases.
        /// </summary>
        IStreamingPoliciesOperations StreamingPolicies { get; }
    }
}