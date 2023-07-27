using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models
{
    /// <summary>
    /// Model digunakan untuk membentuk response body
    /// dari result sebuah endpoint
    /// </summary>
    public class Model
    {
        [JsonProperty("Item1")]
        public string Item1 { get; set; }
    }
}