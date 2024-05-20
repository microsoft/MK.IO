// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public partial class AccountProfile
    {
        public static AccountProfile FromJson(string json)
        {
            return JsonSerializer.Deserialize<AccountProfile>(json, ConverterLE.Settings) ?? throw new Exception("Error with account profile deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }


        public Metadata Metadata { get; set; }

        public UserInfo Spec { get; set; }

        public string Kind { get; set; }
    }


    public class ByPermission
    {
        public List<string> User { get; set; }

        public List<string> Admin { get; set; }
    }


    public class Metadata
    {
        public string Id { get; set; }
    }

    public class Permissions
    {
        [JsonPropertyName("by_scope")]
        public JsonElement ByScope { get; set; }

        [JsonPropertyName("by_permission")]
        public ByPermission ByPermission { get; set; }
    }


    public class UserInfo
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("signup_problem")]
        public object SignupProblem { get; set; }

        [JsonPropertyName("customer_id")]
        public Guid CustomerId { get; set; }

        public Permissions Permissions { get; set; }
    }
}