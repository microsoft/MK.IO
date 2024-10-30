// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UserProfileSpecV1
    {
        /// <summary>
        /// Currently selected organization.
        /// </summary>
        /// <value>Currently selected organization.</value>
        [JsonProperty("activeOrganizationId")]
        public Guid ActiveOrganizationId { get; set; }

        /// <summary>
        /// Avatar.
        /// </summary>
        /// <value>Avatar.</value>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Company.
        /// </summary>
        /// <value>Company.</value>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Contact email address
        /// </summary>
        /// <value>Contact email address</value>
        [JsonProperty("contactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        /// <value>Country.</value>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Is this user active?
        /// </summary>
        /// <value>Is this user active?</value>
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Job Role.
        /// </summary>
        /// <value>Job Role.</value>
        [JsonProperty("jobRole")]
        public string JobRole { get; set; }

        /// <summary>
        /// Email address used for login
        /// </summary>
        /// <value>Email address used for login</value>
        [JsonProperty("loginEmail")]
        public string LoginEmail { get; set; }

        /// <summary>
        /// Full name.
        /// </summary>
        /// <value>Full name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Phone number including international dialling code
        /// </summary>
        /// <value>Phone number including international dialling code</value>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserProfileSpecV1 {\n");
            sb.Append("  ActiveOrganizationId: ").Append(ActiveOrganizationId).Append("\n");
            sb.Append("  Avatar: ").Append(Avatar).Append("\n");
            sb.Append("  Company: ").Append(Company).Append("\n");
            sb.Append("  ContactEmail: ").Append(ContactEmail).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  JobRole: ").Append(JobRole).Append("\n");
            sb.Append("  LoginEmail: ").Append(LoginEmail).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
