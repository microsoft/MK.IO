// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class ContentKeyPolicyFairPlayConfiguration : ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyFairPlayConfiguration(string ask, string fairPlayPfx, string fairPlayPfxPassword, long rentalDuration, RentalAndLeaseKeyType rentalAndLeaseKeyType)
        {
            Ask = ask;
            FairPlayPfx = fairPlayPfx;
            RentalDuration = rentalDuration;
            FairPlayPfxPassword = fairPlayPfxPassword;
            RentalAndLeaseKeyType = rentalAndLeaseKeyType;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyFairPlayConfiguration";

        /// <summary>
        /// The key that must be used as FairPlay Application Secret key. This needs to be base64 encoded.
        /// </summary>
        /// <value>The key that must be used as FairPlay Application Secret key. This needs to be base64 encoded.</value>
        public string Ask { get; set; }

        /// <summary>
        /// The Base64 representation of FairPlay certificate in PKCS 12 (pfx) format (including private key).
        /// </summary>
        /// <value>The Base64 representation of FairPlay certificate in PKCS 12 (pfx) format (including private key).</value>
        public string FairPlayPfx { get; set; }

        /// <summary>
        /// The password encrypting FairPlay certificate in PKCS 12 (pfx) format.
        /// </summary>
        /// <value>The password encrypting FairPlay certificate in PKCS 12 (pfx) format.</value>
        public string FairPlayPfxPassword { get; set; }

        /// <summary>
        /// Gets or Sets OfflineRentalConfiguration
        /// </summary>
        public ContentKeyPolicyFairPlayOfflineRentalConfiguration OfflineRentalConfiguration { get; set; }

        /// <summary>
        /// The rental and lease key type.
        /// </summary>
        /// <value>The rental and lease key type.</value>
        public RentalAndLeaseKeyType RentalAndLeaseKeyType { get; set; }

        /// <summary>
        /// The rental duration. Must be greater than or equal to 0.
        /// </summary>
        /// <value>The rental duration. Must be greater than or equal to 0.</value>
        public long RentalDuration { get; set; }
    }
}