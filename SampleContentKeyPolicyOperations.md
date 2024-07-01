# Sample for content key policy operations with MK.IO SDK

```csharp
using MK.IO;
using MK.IO.Models;

// **********************
// MK.IO Client creation
// **********************

var client = new MKIOClient("mkiosubscriptionname", "mkiotoken");

// ******************************
// content key policy operations
// ******************************

try
{
    ck = await client.ContentKeyPolicies.Get("testpolcreate");
    await client.ContentKeyPolicies.DeleteAsync("testpolcreate");
}
catch
{
}

// generate a symmetric key for the content key policy
var key = GenerateSymKeyAsBase64();

// create a new content key policy
var newpol = client.ContentKeyPolicies.Create(
    "testpolcreate",
    new ContentKeyPolicyProperties("My description",
    [
        new(
            "option1",
            new ContentKeyPolicyWidevineConfiguration("{}"),
            new ContentKeyPolicyTokenRestriction(
                "issuer",
                "audience",
                RestrictionTokenType.Jwt,
                new ContentKeyPolicySymmetricTokenKey(key),
                requiredClaims: new List<ContentKeyPolicyTokenClaim>()
                {
                    ContentKeyPolicyTokenClaim.ContentKeyIdentifierClaim
                }
                )
            )
    ])
    );


// ******************************
// Streaming locator operations
// ******************************

// list all locators in the subscription
var mklocators = client.StreamingLocators.List();

// list all locators of a specified asset
var mklocatorsasset= client.Assets.ListStreamingLocators("myassetname");

var mklocator = client.StreamingLocators.Create(
    MKIOClient.GenerateUniqueName("locator"),
    new StreamingLocatorProperties
    {
        AssetName = "copy-ef2058b692-copy",
        StreamingPolicyName = PredefinedStreamingPolicy.ClearStreamingOnly
    });

var mklocator2 = client.StreamingLocators.Get(mklocator.Name);

// get streaming paths for a locator
var pathsl = client.StreamingLocators.ListUrlPaths(mklocator.Name);

// delete a locator
client.StreamingLocators.Delete(mklocator.Name);


private static string GenerateSymKeyAsBase64()
{
    byte[] TokenSigningKey = new byte[40];
    var rng = RandomNumberGenerator.Create();
    rng.GetBytes(TokenSigningKey);
    return Convert.ToBase64String(TokenSigningKey);
}

```
