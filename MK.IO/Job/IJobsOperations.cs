// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{
    public interface IJobsOperations
    {
        /// <summary>
        /// Retrieves a list of all Jobs in a subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<JobSchema> ListAll(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of all Jobs in a subscription.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<JobSchema>> ListAllAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of all Jobs in a subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<JobSchema> ListAllAsPage(string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of all Jobs in a subscription using pages.
        /// </summary>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<JobSchema>> ListAllAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of all Jobs in a subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<JobSchema> ListAllAsPageNext(string? nextPageLink);

        /// <summary>
        /// Retrieves a list of all Jobs in a subscription using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<JobSchema>> ListAllAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        IEnumerable<JobSchema> List(string transformName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<JobSchema>> ListAsync(string transformName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform using pages.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <returns></returns>
        PagedResult<JobSchema> ListAsPage(string transformName, string? orderBy = null, string? filter = null, int? top = null);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform using pages.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="orderBy">Specifies the key by which the result collection should be ordered.</param>
        /// <param name="filter">Restricts the set of items returned.</param>
        /// <param name="top">Specifies a non-negative integer that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value top.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<JobSchema>> ListAsPageAsync(string transformName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <returns></returns>
        PagedResult<JobSchema> ListAsPageNext(string? nextPageLink);

        /// <summary>
        /// Retrieves a list of Jobs for a Transform using pages.
        /// </summary>
        /// <param name="nextPageLink">Next page link.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<PagedResult<JobSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        void Delete(string transformName, string jobName);

        /// <summary>
        /// Delete a Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(string transformName, string jobName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an transform by name.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        JobSchema Get(string transformName, string jobName);

        /// <summary>
        /// Get an transform by name.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<JobSchema> GetAsync(string transformName, string jobName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        JobSchema Create(string transformName, string jobName, JobProperties properties);

        /// <summary>
        /// Create a new Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="properties"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<JobSchema> CreateAsync(string transformName, string jobName, JobProperties properties, CancellationToken cancellationToken = default);

#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <summary>
        /// Update an existing Job.
        /// Update is only supported for description and priority.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        JobSchema Update(string transformName, string jobName, JobProperties properties);

        /// <summary>
        /// Update an existing Job.
        /// Update is only supported for description and priority.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        Task<JobSchema> UpdateAsync(string transformName, string jobName, JobProperties properties, CancellationToken cancellationToken = default);
#endif

        /// <summary>
        /// Cancel an already running Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        void Cancel(string transformName, string jobName);

        /// <summary>
        /// Cancel an already running Job.
        /// </summary>
        /// <param name="transformName"></param>
        /// <param name="jobName"></param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task CancelAsync(string transformName, string jobName, CancellationToken cancellationToken = default);

    }
}