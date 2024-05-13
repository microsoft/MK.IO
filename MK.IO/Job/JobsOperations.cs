// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;
using Newtonsoft.Json;
using System.Net;

#if NET462
using System.Net.Http;
#endif

namespace MK.IO.Operations
{
    /// <summary>
    /// REST Client for MKIO
    /// https://mk.io/
    /// 
    /// </summary>
    internal class JobsOperations : IJobsOperations
    {
        //
        // jobs
        //

        private const string _allJobsApiUrl = MKIOClient._allJobsApiUrl;
        private const string _jobsApiUrl = MKIOClient._transformsApiUrl + "/{1}/jobs";
        private const string _jobApiUrl = _jobsApiUrl + "/{2}";

        /// <summary>
        /// Gets a reference to the AzureMediaServicesClient
        /// </summary>
        private MKIOClient Client { get; set; }

        /// <summary>
        /// Initializes a new instance of the JobsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        internal JobsOperations(MKIOClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public IEnumerable<JobSchema> ListAll(string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<JobSchema>>(async () => await ListAllAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<JobSchema>> ListAllAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<JobSchema> objectsSchema = [];
            var objectsResult = await ListAllAsPageAsync(orderBy, filter, top, cancellationToken);
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                objectsSchema.AddRange(objectsResult.Results);
                if (objectsResult.NextPageLink == null || (top != null && objectsSchema.Count >= top)) break;
                objectsResult = await ListAllAsPageNextAsync(objectsResult.NextPageLink, cancellationToken);
            }

            if (top != null && top < objectsSchema.Count)
            {
                return objectsSchema.Take((int)top);
            }

            return objectsSchema;
        }

        /// <inheritdoc/>
        public PagedResult<JobSchema> ListAllAsPage(string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<JobSchema>> task = Task.Run(async () => await ListAllAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<JobSchema>> ListAllAsPageAsync(string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_allJobsApiUrl);
            return await Client.ListAsPageGenericAsync<JobSchema>(url, typeof(JobListResponseSchema), "all job", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<JobSchema> ListAllAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<JobSchema>> task = Task.Run(async () => await ListAllAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<JobSchema>> ListAllAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<JobSchema>(nextPageLink, typeof(JobListResponseSchema), "all job", cancellationToken);
        }

        /// <inheritdoc/>
        public IEnumerable<JobSchema> List(string transformName, string? orderBy = null, string? filter = null, int? top = null)
        {
            var task = Task.Run<IEnumerable<JobSchema>>(async () => await ListAsync(transformName, orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<JobSchema>> ListAsync(string transformName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            List<JobSchema> objectsSchema = [];
            var objectsResult = await ListAsPageAsync(transformName, orderBy, filter, top, cancellationToken);
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                objectsSchema.AddRange(objectsResult.Results);
                if (objectsResult.NextPageLink == null || (top != null && objectsSchema.Count >= top)) break;
                objectsResult = await ListAsPageNextAsync(objectsResult.NextPageLink, cancellationToken);
            }

            if (top != null && top < objectsSchema.Count)
            {
                return objectsSchema.Take((int)top);
            }

            return objectsSchema;
        }

        /// <inheritdoc/>
        public PagedResult<JobSchema> ListAsPage(string transformName, string? orderBy = null, string? filter = null, int? top = null)
        {
            Task<PagedResult<JobSchema>> task = Task.Run(async () => await ListAllAsPageAsync(orderBy, filter, top));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<JobSchema>> ListAsPageAsync(string transformName, string? orderBy = null, string? filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var url = Client.GenerateApiUrl(_jobsApiUrl, transformName);
            return await Client.ListAsPageGenericAsync<JobSchema>(url, typeof(JobListResponseSchema), "job", cancellationToken, orderBy, filter, top);
        }

        /// <inheritdoc/>
        public PagedResult<JobSchema> ListAsPageNext(string? nextPageLink)
        {
            Task<PagedResult<JobSchema>> task = Task.Run(async () => await ListAllAsPageNextAsync(nextPageLink));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<PagedResult<JobSchema>> ListAsPageNextAsync(string? nextPageLink, CancellationToken cancellationToken = default)
        {
            return await Client.ListAsPageNextGenericAsync<JobSchema>(nextPageLink, typeof(JobListResponseSchema), "job", cancellationToken);
        }

        /// <inheritdoc/>
        public JobSchema Get(string transformName, string jobName)
        {
            var task = Task.Run<JobSchema>(async () => await GetAsync(transformName, jobName));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<JobSchema> GetAsync(string transformName, string jobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotNullOrEmpty(jobName, nameof(jobName));

            var url = Client.GenerateApiUrl(_jobApiUrl, transformName, jobName);
            string responseContent = await Client.GetObjectContentAsync(url, cancellationToken);
            return JsonConvert.DeserializeObject<JobSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with job deserialization");
        }

        /// <inheritdoc/>
        public JobSchema Create(string transformName, string jobName, JobProperties properties)
        {
            var task = Task.Run<JobSchema>(async () => await CreateAsync(transformName, jobName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<JobSchema> CreateAsync(string transformName, string jobName, JobProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotNullOrEmpty(jobName, nameof(jobName));
            Argument.AssertNotContainsSpace(jobName, nameof(jobName));
            Argument.AssertNotMoreThanLength(jobName, nameof(jobName), 63);
            Argument.AssertNotNull(properties, nameof(properties));

            return await CreateOrUpdateAsync(transformName, jobName, properties, Client.CreateObjectPutAsync, cancellationToken);
        }

        internal async Task<JobSchema> CreateOrUpdateAsync(string transformName, string jobName, JobProperties properties, Func<string, string, CancellationToken, Task<string>> func, CancellationToken cancellationToken)
        {
            var url = Client.GenerateApiUrl(_jobApiUrl, transformName, jobName);
            // fix to make sure Odattype is set as we use the generated class
            foreach (var o in properties.Outputs)
            {
                o.OdataType = "#Microsoft.Media.JobOutputAsset";
            }
            var content = new JobSchema { Properties = properties };

            string responseContent = await func(url, content.ToJson(), cancellationToken);
            return JsonConvert.DeserializeObject<JobSchema>(responseContent, ConverterLE.Settings) ?? throw new Exception("Error with job deserialization");
        }

#if NETSTANDARD2_1_OR_GREATER || NET6_0_OR_GREATER
        /// <inheritdoc/>
        public JobSchema Update(string transformName, string jobName, JobProperties properties)
        {
            var task = Task.Run<JobSchema>(async () => await UpdateAsync(transformName, jobName, properties));
            return task.GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task<JobSchema> UpdateAsync(string transformName, string jobName, JobProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotNullOrEmpty(jobName, nameof(jobName));
            Argument.AssertNotContainsSpace(jobName, nameof(jobName));
            Argument.AssertNotMoreThanLength(jobName, nameof(jobName), 63);
            Argument.AssertNotNull(properties, nameof(properties));

            return await CreateOrUpdateAsync(transformName, jobName, properties, Client.UpdateObjectPatchAsync, cancellationToken);
        }
#endif

        /// <inheritdoc/>
        public void Cancel(string transformName, string jobName)
        {
            Task.Run(async () => await CancelAsync(transformName, jobName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task CancelAsync(string transformName, string jobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotNullOrEmpty(jobName, nameof(jobName));

            var url = Client.GenerateApiUrl(_jobApiUrl + "/cancelJob", transformName, jobName);
            await Client.ObjectContentAsync(url, HttpMethod.Post, cancellationToken);
        }

        /// <inheritdoc/>
        public void Delete(string transformName, string jobName)
        {
            Task.Run(async () => await DeleteAsync(transformName, jobName)).GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(string transformName, string jobName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(transformName, nameof(transformName));
            Argument.AssertNotNullOrEmpty(jobName, nameof(jobName));

            var url = Client.GenerateApiUrl(_jobApiUrl, transformName, jobName);
            await Client.ObjectContentAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}