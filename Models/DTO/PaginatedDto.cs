using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models.DTO
{
    /// <summary>
    /// DTO = Data Transfer Object, model untuk
    /// controller menerima data (request body)
    /// </summary>
    public class PaginatedDto
    {   

        // Required Parameter Example
        [JsonProperty("Parameter1")]
        public string Parameter1 { get; set; }


        // Optional Parameter Example
        [JsonProperty("Parameter2")]
        public string Parameter2 { get; set; }

        [JsonProperty("Page")]
        public int Page { get; set; }

        [JsonProperty("Size")]
        public int Size { get; set; }
    }
}