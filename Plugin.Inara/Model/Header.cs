﻿using DW.ELA.Utility.Json;
using Newtonsoft.Json;
using Utility;

namespace DW.ELA.Plugin.Inara.Model
{
    public class Header
    {
        public Header(string commander, string apiKey)
        {
            CommanderName = commander;
            ApiKey = apiKey;
        }

        // Input fields
        [JsonProperty("appName")]
        public readonly string AppName = AppInfo.Name;
        [JsonProperty("appVersion")]
        public readonly string AppVersion = AppInfo.Version;
        [JsonProperty("isDeveloped")]
        public readonly bool IsDeveloped = false;
        [JsonProperty("APIkey")]
        public string ApiKey { get; }
        [JsonProperty("commanderName")]
        public string CommanderName { get; }

        // Output fields
        [JsonProperty("eventStatus")]
        public int? EventStatus { get; internal set; }
        [JsonProperty("eventStatusText")]
        public string EventStatusText { get; internal set; }

        public override string ToString() => Serialize.ToJson(this);
    }
}
