// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace MK.IO.Operations
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Results { get; set; }
        public string? NextPageLink { get; set; }
    }
}