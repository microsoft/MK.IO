// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IAccountFiltersOperations
    {
        /// <summary>
        /// Returns a list of account filters in the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered. Specify a field name, and optionally asc or desc. Sorting is valid on the following field: name</param>
        /// <param name="filter">Restricts the set of items returned. Filters are valid on the following field: name</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<AccountFilterSchema> List(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of account filters in the subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered. Specify a field name, and optionally asc or desc. Sorting is valid on the following field: name</param>
        /// <param name="filter">Restricts the set of items returned. Filters are valid on the following field: name</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<AccountFilterSchema>> ListAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of account filters in the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered. Specify a field name, and optionally asc or desc. Sorting is valid on the following field: name</param>
        /// <param name="filter">Restricts the set of items returned. Filters are valid on the following field: name</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<AccountFilterSchema> ListAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Returns a list of account filters in the subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered. Specify a field name, and optionally asc or desc. Sorting is valid on the following field: name</param>
        /// <param name="filter">Restricts the set of items returned. Filters are valid on the following field: name</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<AccountFilterSchema>> ListAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of account filters in the subscription using next pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<AccountFilterSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Returns a list of account filters in the subscription using next pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<AccountFilterSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the account filter.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <returns></returns>
        void Delete(string accountFilterName);

        /// <summary>
        /// Delete the account filter.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string accountFilterName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an account filter by name.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <returns></returns>
        AccountFilterSchema Get(string accountFilterName);

        /// <summary>
        /// Get an account filter by name.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<AccountFilterSchema> GetAsync(string accountFilterName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create or Update an account filter.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        AccountFilterSchema CreateOrUpdate(string accountFilterName, MediaFilterProperties properties);

        /// <summary>
        /// Create or Update an account filter.
        /// </summary>
        /// <param name="accountFilterName"></param>
        /// <param name="properties"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<AccountFilterSchema> CreateOrUpdateAsync(string accountFilterName, MediaFilterProperties properties, CancellationToken cancellationToken = default);

    }
}
