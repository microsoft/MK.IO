// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface ITransformsOperations
    {
        /// <summary>
        /// Retrieves a list of transforms for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<TransformSchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of transforms for the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Filters the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<TransformSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of transforms for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<TransformSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of transforms for the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<TransformSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of transforms for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<TransformSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Retrieves a list of transforms for the subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<TransformSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a Transform.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        void Delete(string transformName);

        /// <summary>
        /// Delete a Transform.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string transformName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a Transform by name.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        /// <returns></returns>
        TransformSchema Get(string transformName);

        /// <summary>
        /// Get a Transform by name.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<TransformSchema> GetAsync(string transformName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create or Update a new Transform.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        /// <param name="properties">he properties of the transform</param>
        /// <returns></returns>
        TransformSchema CreateOrUpdate(string transformName, TransformProperties properties);

        /// <summary>
        /// Create or Update a new Transform.
        /// </summary>
        /// <param name="transformName">The name of the transform.</param>
        /// <param name="properties">he properties of the transform</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<TransformSchema> CreateOrUpdateAsync(string transformName, TransformProperties properties, CancellationToken cancellationToken = default);
    }
}