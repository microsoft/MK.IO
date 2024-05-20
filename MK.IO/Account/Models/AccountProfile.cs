// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MK.IO.Models
{
    public partial class AccountProfile
    {
        public static AccountProfile FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AccountProfile>(json, ConverterLE.Settings) ?? throw new Exception("Error with account profile deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }


        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("spec")]
        public UserInfo Spec { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }
    }


    public class ByPermission
    {
        [JsonProperty("user")]
        public List<string> User { get; set; }

        [JsonProperty("admin")]
        public List<string> Admin { get; set; }
    }


    public class Metadata
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Permissions
    {
        [JsonProperty("by_scope")]
        public JObject ByScope { get; set; }

        [JsonProperty("by_permission")]
        public ByPermission ByPermission { get; set; }
    }


    public class UserInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("signup_problem")]
        public object SignupProblem { get; set; }

        [JsonProperty("customer_id")]
        public Guid CustomerId { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }
    }
}