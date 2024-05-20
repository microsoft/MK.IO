// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class ContentKeyPolicyPlayReadyLicense
    {
        
        public ContentKeyPolicyPlayReadyLicense(PlayReadyContentType contentType, PlayReadyLicenseType licenseType, PlayReadySecurityLevel securityLevel, bool? allowTestDevices, PlayReadyContentKeyLocation contentKeyLocation, ContentKeyPolicyPlayReadyPlayRight playRight)
        {
            ContentType = contentType;
            LicenseType = licenseType;
            SecurityLevel = securityLevel;
            AllowTestDevices = allowTestDevices;
            ContentKeyLocation = contentKeyLocation;
            PlayRight = playRight;
        }
  
        /// <summary>
        /// A flag indicating whether test devices can use the license.
        /// </summary>
        /// <value>A flag indicating whether test devices can use the license.</value>
        public bool? AllowTestDevices { get; set; }

        /// <summary>
        /// The begin date of license
        /// </summary>
        /// <value>The begin date of license</value>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// The content key location.
        /// </summary>
        /// <value>The content key location.</value>
        public PlayReadyContentKeyLocation ContentKeyLocation { get; set; }

        /// <summary>
        /// The PlayReady content type.
        /// </summary>
        /// <value>The PlayReady content type.</value>
        public PlayReadyContentType ContentType { get; set; }

        /// <summary>
        /// The expiration date of license.
        /// </summary>
        /// <value>The expiration date of license.</value>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// The grace period of license.
        /// </summary>
        /// <value>The grace period of license.</value>
        public string GracePeriod { get; set; }

        /// <summary>
        /// The license type.
        /// </summary>
        /// <value>The license type.</value>
        public PlayReadyLicenseType LicenseType { get; set; }

        /// <summary>
        /// Gets or Sets PlayRight
        /// </summary>
        public ContentKeyPolicyPlayReadyPlayRight PlayRight { get; set; }

        /// <summary>
        /// The relative begin date of license.
        /// </summary>
        /// <value>The relative begin date of license.</value>
        public string RelativeBeginDate { get; set; }

        /// <summary>
        /// The security level.
        /// </summary>
        /// <value>The security level.</value>
        public PlayReadySecurityLevel SecurityLevel { get; set; }

        /// <summary>
        /// The relative expiration date of license.
        /// </summary>
        /// <value>The relative expiration date of license.</value>
        public string RelativeExpirationDate { get; set; }
    }
}