using Controller;
using DW.ELA.Utility.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace EliteLogAgent.DevTool
{
    internal static class MergedEventsGenerator
    {
        internal static void Generate(string eventName)
        {
            var player = new LogBurstPlayer(new SavedGamesDirectoryHelper().Directory, 10000);
            var events = player.Events
                .Where(e => e.Event == eventName)
                .Select(e => e.Raw)
                .ToList();

            var mergedEvent = events.Aggregate(Merge);
            var mergedEventText = Serialize.ToJson(mergedEvent);
        }

        private static JObject Merge(JObject j1, JObject j2)
        {
            var j = (JObject)j1.DeepClone();
            j.Merge(j2, mergeSettings);
            return j;
        }

        private static readonly JsonMergeSettings mergeSettings = new JsonMergeSettings
        {
            // union array values together to avoid duplicates
            MergeArrayHandling = MergeArrayHandling.Union
        };
    }
}