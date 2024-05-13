// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IAssetFiltersOperations
    {
        /// <summary>
        /// Retrieves a list of asset filters for a specified asset.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<AssetFilterSchema> List(string assetName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of asset filters for a specified asset.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<AssetFilterSchema>> ListAsync(string assetName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of asset filters for a specified asset using pages.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<AssetFilterSchema> ListAsPage(string assetName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of asset filters for a specified asset using pages.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<AssetFilterSchema>> ListAsPageAsync(string assetName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of asset filters for a specified asset using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<AssetFilterSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Retrieves a list of asset filters for a specified asset using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<AssetFilterSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the asset filter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <returns></returns>
        void Delete(string assetName, string filterName);

        /// <summary>
        /// Delete the asset filter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string assetName, string filterName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an asset filter by name.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <returns></returns>
        AssetFilterSchema Get(string assetName, string filterName);

        /// <summary>
        /// Get an asset filter by name.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<AssetFilterSchema> GetAsync(string assetName, string filterName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create or Update an asset filter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        AssetFilterSchema CreateOrUpdate(string assetName, string filterName, MediaFilterProperties properties);

        /// <summary>
        /// Create or Update an asset filter.
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="filterName"></param>
        /// <param name="properties"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<AssetFilterSchema> CreateOrUpdateAsync(string assetName, string filterName, MediaFilterProperties properties, CancellationToken cancellationToken = default);
    }
}
