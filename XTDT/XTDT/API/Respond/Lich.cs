﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XTDT.API.Respond
{
    public class Lich
    {
        [JsonProperty("tiet")]
        public string Tiet { get; set; }

        [JsonProperty("thu")]
        public int Thu { get; set; }

        [JsonProperty("phong")]
        public string Phong { get; set; }

        [JsonProperty("tuan")]
        public string Tuan { get; set; }
    }
}
