// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using MK.IO.Models;

namespace MK.IO.Operations
{

    public interface IStorageAccountsOperations
    {
        /// <summary>
        /// List Storage Accounts
        /// </summary>
        /// <returns></returns>
        IEnumerable<StorageResponseSchema> List();

        /// <summary>
        /// List Storage Accounts
        /// </summary>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<IEnumerable<StorageResponseSchema>> ListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a Storage Account.
        /// The Storage Account must be in the same location as your subscription.
        /// The SAS token in the spec.azureStorageConfiguration.url field will be used to create a related Storage Credential object for you.
        /// </summary>
        /// <param name="storage">The specification of the Storage Account to be created.</param>
        /// <returns></returns>
        StorageResponseSchema Create(StorageSchema storage);

        /// <summary>
        /// Create a Storage Account.
        /// The Storage Account must be in the same location as your subscription.
        /// The SAS token in the spec.azureStorageConfiguration.url field will be used to create a related Storage Credential object for you.
        /// </summary>
        /// <param name="storage">The specification of the Storage Account to be created.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StorageResponseSchema> CreateAsync(StorageSchema storage, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete our record of your Storage Account. This operation does not delete the Storage Account itself.
        /// This operation will not complete successfully if any assets are associated with the Storage Account.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        void Delete(Guid storageAccountId);

        /// <summary>
        /// Delete our record of your Storage Account. This operation does not delete the Storage Account itself.
        /// This operation will not complete successfully if any assets are associated with the Storage Account.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid storageAccountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details on a single Storage Account
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <returns></returns>
        StorageResponseSchema Get(Guid storageAccountId);

        /// <summary>
        /// Returns details on a single Storage Account
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StorageResponseSchema> GetAsync(Guid storageAccountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a Storage Account.
        /// Only the description and privateLinkServiceConnection details are updatable.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="storage">The specification of the Storage Account to be updated.</param>
        /// <returns></returns>
        StorageResponseSchema Update(Guid storageAccountId, StorageSchema storage);

        /// <summary>
        /// Update a Storage Account.
        /// Only the description and privateLinkServiceConnection details are updatable.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="storage">The specification of the Storage Account to be updated.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<StorageResponseSchema> UpdateAsync(Guid storageAccountId, StorageSchema storage, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a list of Storage Credentials
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <returns></returns>
        List<CredentialResponseSchema> ListCredentials(Guid storageAccountId);

        /// <summary>
        /// Returns a list of Storage Credentials
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<List<CredentialResponseSchema>> ListCredentialsAsync(Guid storageAccountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a single Storage Credential. Any secret data will be sanitized in the response.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credentialId">The Credential Id.</param>
        /// <returns></returns>
        CredentialResponseSchema GetCredential(Guid storageAccountId, Guid credentialId);

        /// <summary>
        /// Returns a single Storage Credential. Any secret data will be sanitized in the response.
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credentialId">The Credential Id.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<CredentialResponseSchema> GetCredentialAsync(Guid storageAccountId, Guid credentialId, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>Creates a Storage Credential.</para>
        /// <para>You can add as many Storage Credentials as you like to a Storage Account.
        /// We will choose the Storage Credential with the longest expiry time when we need to access the Storage Account.
        /// Credentials are immutable once created - create a new Storage Credential record, then delete the old one, to change a Storage Credential.</para>
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credential">The Credential data.</param>
        /// <returns></returns>
        CredentialResponseSchema CreateCredential(Guid storageAccountId, CredentialSchema credential);

        /// <summary>
        /// <para>Creates a Storage Credential.</para>
        /// <para>You can add as many Storage Credentials as you like to a Storage Account.
        /// We will choose the Storage Credential with the longest expiry time when we need to access the Storage Account.
        /// Credentials are immutable once created - create a new Storage Credential record, then delete the old one, to change a Storage Credential.</para>
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credential">The Credential data.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task<CredentialResponseSchema> CreateCredentialAsync(Guid storageAccountId, CredentialSchema credential, CancellationToken cancellationToken = default);

        /// <summary>
        /// <para>Removes a Storage Credential from the Storage Account.</para>
        /// <para>If the Storage Credential is in use and no alternative Storage Credentials are available, the Storage Account will be inaccessible.</para>
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credentialId">The Credential Id.</param>
        /// <returns></returns>
        void DeleteCredential(Guid storageAccountId, Guid credentialId);

        /// <summary>
        /// <para>Removes a Storage Credential from the Storage Account.</para>
        /// <para>If the Storage Credential is in use and no alternative Storage Credentials are available, the Storage Account will be inaccessible.</para>
        /// </summary>
        /// <param name="storageAccountId">The Storage Account Id.</param>
        /// <param name="credentialId">The Credential Id.</param>
        /// <param name="cancellationToken">Optional System.Threading.CancellationToken to propagate notifications that the operation should be cancelled.</param>
        /// <returns></returns>
        Task DeleteCredentialAsync(Guid storageAccountId, Guid credentialId, CancellationToken cancellationToken = default);
    }
}